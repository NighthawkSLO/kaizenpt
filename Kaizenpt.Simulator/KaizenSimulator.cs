using System.Reflection;
using Kaizenpt.Wrappers;

namespace Kaizenpt.Simulator;

public class KaizenSimulator
{
	public KaizenSimulator(string kaizenDirectory, RendererType rendererType)
	{
		var cwd = Directory.GetCurrentDirectory();
		try
		{
			Directory.SetCurrentDirectory(kaizenDirectory);
			Wrappers.Meta.Globals.KaizenDirectory = kaizenDirectory;
			AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
			{
				string? assemblyFileName = args.Name.Split(',')[0] switch
				{
					"Game" => "Kaizen.exe",
					"Steamworks.NET" => "Steamworks.NET.dll",
					_ => null,
				};
				return assemblyFileName is not null
					? Assembly.LoadFile(Path.Join(kaizenDirectory, assemblyFileName))
					: null;
			};

			HarmonyLib.Harmony harmony = new(nameof(KaizenSimulator));
			harmony.PatchAll(Assembly.GetExecutingAssembly());

			GameLogic gameLogic = new();
			gameLogic.SetStaticInstanceToSelf();
			gameLogic.SetRenderer(rendererType);
			Renderer.Initialize(rendererType);
			gameLogic.CreateWindow(nameof(KaizenSimulator), 1366, 768, 0); // Only needed if using OpenGL
			TexturePathHelper.InitMainGameTexturePaths();
			TextureLoader.LoadTexturesNoCallbacks();
			FontLoaderHelper.DoStuff();
			gameLogic.InitializeFonts();
			gameLogic.InitializePuzzles();
		}
		finally
		{
			Directory.SetCurrentDirectory(cwd);
		}
	}

#pragma warning disable CA1822
	public SolutionData Simulate(string solutionFile)
	{
		Solution? solution = Solution.FromFile(solutionFile);
		if (solution == null)
		{
			return new SolutionData
			{
				SolutionFile = solutionFile,
				PuzzleId = null,
				Statistics = null
			};
		}

		Puzzle puzzle = solution.GetPuzzle();
		Factory factory = solution.GetFactory();

		// At least 2 steps for puzzles with no instructions (portable radio)
		int maxSteps = Math.Max(2, factory.GetInstructionLength() + 1);

		Sim sim = Sim.FromSolution(solution);
		sim.Run(maxSteps);

		int solvedOnStep = sim.GetSolvedOnStep();

		if (solvedOnStep < 0)
		{
			return new SolutionData
			{
				SolutionFile = solutionFile,
				PuzzleId = puzzle.GetId(),
				Statistics = null
			};
		}

		Index2 usedArea = sim.GetUsedArea();
		int width = usedArea.GetX();
		int height = usedArea.GetY();
		int area = width * height;

		List<Tool> tools = [.. factory.GetTools()];
		int cost = tools.Sum(tool => tool.GetCost());

		return new SolutionData
		{
			SolutionFile = solutionFile,
			PuzzleId = puzzle.GetId(),
			Statistics = new SolutionStatistics
			{
				Time = solvedOnStep,
				Cost = cost,
				Size = area,
				Width = width,
				Height = height,
			}
		};
	}
#pragma warning restore CA1822
}
