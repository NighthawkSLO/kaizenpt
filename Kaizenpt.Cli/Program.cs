using System.Globalization;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using CommandLine;
using CommandLine.Text;
using Kaizenpt.Simulator;
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

		[Option('r', "renderer",
			HelpText = "The renderer type to use (OpenGl or Direct3D). OpenGl is the default.",
			Default = RendererType.OpenGl,
			Required = false
		)]
		public RendererType Renderer { get; set; }
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
		var simulator = new KaizenSimulator(arguments.KaizenDirectory, arguments.Renderer);

		IEnumerable<string> solutionPaths = arguments.UseDirectory
			? arguments.SolutionPaths.SelectMany(path =>
				Directory.EnumerateFiles(path, "*.solution", SearchOption.AllDirectories)
			)
			: arguments.SolutionPaths;

		Console.WriteLine(JsonConvert.SerializeObject(solutionPaths.Distinct().Select(simulator.Simulate)));
	}
}
