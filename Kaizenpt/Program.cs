using System.Globalization;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using CommandLine;
using CommandLine.Text;
using Newtonsoft.Json;
using Kaizenpt.Wrappers;

namespace Kaizenpt;

[SuppressMessage("Microsoft.Performance", "CA1515")]
public static class Program
{
	[SuppressMessage("Microsoft.Performance", "CA1812")]
	private sealed class Arguments
	{
		[Value(
			0,
			MetaName = "solution-path",
			HelpText = "The path to the solution file(s) or folder(s) to be validated.",
			Required = true
		)]
		public required IEnumerable<string> SolutionPaths { get; set; }

		[Option(
			'e',
			"kaizen-directory",
			HelpText = "A path to the root directory of Kaizen.",
			Required = true
		)]
		public required string KaizenDirectory { get; set; }

		[Option(
			'd',
			"use-directory",
			HelpText = "Whether to use directories for input instead of files.",
			Required = false
		)]
		public bool UseDirectory { get; set; }
	}

	private static void Main(string[] args)
	{
		CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
		Parser parser = new(p => p.HelpWriter = null);
		ParserResult<Arguments> parserResult = parser.ParseArguments<Arguments>(args);
		_ = parserResult
			.WithParsed(InnerMain)
			.WithNotParsed(_ =>
				Console.Error.Write(
					HelpText.AutoBuild(
						parserResult,
						h =>
						{
							h.AdditionalNewLineAfterOption = false;
							return h;
						}
					)
				)
			);
		parser.Dispose();
	}

	private static void InnerMain(Arguments arguments)
	{
		Initialize(arguments.KaizenDirectory);

		IEnumerable<string> solutionPaths = arguments.UseDirectory
			? arguments.SolutionPaths.SelectMany(
				path => Directory.EnumerateFiles(path, "*.solution", SearchOption.AllDirectories)
			)
			: arguments.SolutionPaths;

		Console.WriteLine(JsonConvert.SerializeObject(solutionPaths.Distinct().Select(Simulate)));
	}

	public static void Initialize(string kaizenDirectory)
	{
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

		HarmonyLib.Harmony harmony = new(nameof(Program));
		harmony.PatchAll(Assembly.GetExecutingAssembly());

		int platform = 1;

		Wrappers.Meta.Globals.KaizenDirectory = kaizenDirectory;
		GameLogic gameLogic = new();
		gameLogic.SetStaticInstanceToSelf();
		gameLogic.SetRenderer(rendererType);
		Renderer.Initialize(rendererType);
		gameLogic.CreateWindow(nameof(Program), 1366, 768, 0); // Only needed if using OpenGL
		TexturePathHelper.InitMainGameTexturePaths();
		TextureLoader.LoadTexturesNoCallbacks();
		FontLoaderHelper.DoStuff();
		gameLogic.InitializeFonts();
		gameLogic.InitializePuzzles();
	}

	public static SolutionData Simulate(string solutionFile)
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

		Simulation simulation = Simulation.FromSolution(solution);
		simulation.Run(maxSteps);

		int solvedOnStep = simulation.GetSolvedOnStep();

		if (solvedOnStep < 0)
		{
			return new SolutionData()
			{
				SolutionFile = solutionFile,
				PuzzleId = puzzle.GetId(),
				Statistics = null
			};
		}

		Index2 usedArea = simulation.GetUsedArea();
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
}
