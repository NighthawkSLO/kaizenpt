using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Kaizenpt.Simulator;

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record SolutionData : IEquatable<SolutionData>
{
	[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
	public string? SolutionFile { get; set; }


	[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
	public int? PuzzleId { get; set; }

	[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
	public SolutionStatistics? Statistics { get; set; }
}

[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public record SolutionStatistics
{
	public required int Time { get; set; }

	public required int Cost { get; set; }

	public required int Size { get; set; }

	public required int Width { get; set; }

	public required int Height { get; set; }
}
