namespace Kaizenpt;

public static partial class Consts
{
	/// <summary>
	/// Sim function that runs the simulation for the specified number of steps.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Sim class<br/>
	/// 2. Look for the function that has arguments <c>(int, int, bool, bool)</c> and returns <c>SimAnimation[]</c><br/>
	/// </remarks>
	public const string SimulationRunFunction = "#=qT_EiNywhPKKSZOK2aupk2w==";

	/// <summary>
	/// Sim field that has a value when the simulation is finished.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Sim class<br/>
	/// 2. Look for the field of type <c>Maybe&lt;int&gt;</c><br/>
	/// </remarks>
	public const string SimulationFinishedField = "#=qV6uhqlyxH2ILyFRnIf9zGQ==";

	/// <summary>
	/// Sim function that indicates if the simulation has errors.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Sim class<br/>
	/// 2. Look for the <c>bool</c> function with no arguments that has <c>return this.#abcdef123456.Count > 0</c>. The field it's counting is type <c>List&lt;SimError&gt;</c><br/>
	/// </remarks>
	public const string SimulationHasErrorsFunction = "#=qsBPHuuhI91aPw0mvfm33DA==";

	/// <summary>
	/// Sim field for the size of the used area.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Sim class<br/>
	/// 2. Look for the field of type <c>Range2</c>
	/// </remarks>
	public const string SimulationUsedAreaField = "#=qOYwJnSBom50QBfyBwWju5g==";
}
