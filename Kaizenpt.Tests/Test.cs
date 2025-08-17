using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace Kaizenpt.Tests;

internal static class Test
{
	[Test]
	public static void Simulate()
	{
		Program.Initialize(
			Environment.GetEnvironmentVariable("KAIZEN_DIR")
				?? throw new MissingEnvironmentVariableException(@"Environment variable ""KAIZEN_DIR"" not set")
		);

		JObject expectedResults = JObject.Parse(File.ReadAllText("resources/expected_results.json"))!;
		foreach (string solutionFile in Directory.EnumerateFiles("resources/solutions", "*.solution", SearchOption.AllDirectories))
		{
			TestContext.Progress.WriteLine($@"Running solution ""{solutionFile}""");

			string expectedResultKey = Path.GetRelativePath("resources/solutions", solutionFile)
				.Replace(".solution", "", StringComparison.Ordinal)
				.Replace("\\", "/", StringComparison.Ordinal);
			SolutionData? expectedResult = expectedResults[expectedResultKey]?.ToObject<SolutionData>();
			Assert.That(
				expectedResult,
				Is.Not.Null,
				$@"Failed to find solution key ""{expectedResultKey}"" in ""resources/expected_results.json"""
			);

			Stopwatch stopwatch = Stopwatch.StartNew();
			SolutionData result = Program.Simulate(solutionFile);
			stopwatch.Stop();
			TestContext.Progress.WriteLine($@"Solution ""{solutionFile}"" finished in {stopwatch.Elapsed}");

			result.SolutionFile = null; // Remove the file path from the result for comparison

			Assert.That(result, Is.EqualTo(expectedResult));
		}
	}
}
