namespace Kaizenpt;

public static partial class Consts
{
	/// <summary>
	/// The class representing a byte array of a solution file.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Solution class<br/>
	/// 2. Look for the static function that returns <c>Maybe&lt;Solution&gt;</c><br/>
	/// 3. Find the type of the argument passed to the function
	/// </remarks>
	public const string FileBytesClass = "#=qepLM_qbhIkWWJzfjrTAEOw==";

	/// <summary>
	/// Solution function that creates a solution from a byte array.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Solution class<br/>
	/// 2. Look for the <c>static Maybe&lt;Solution&gt;</c> function<br/>
	/// </remarks>
	public const string SolutionFromFileBytesFunction = "#=qPzhxQKTDxkU7knj2Fqk0mQ==";

	/// <summary>
	/// Solution field that contains the Puzzle instance.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Solution class<br/>
	/// 2. Look for the field of type <c>Puzzle</c><br/>
	/// </remarks>
	public const string SolutionPuzzleField = "#=qlxk240mnlkFA1DGDBGJ4FQ==";

	/// <summary>
	/// Solution field that contains the Factory instance.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Solution class<br/>
	/// 2. Look for the field of type <c>Factory</c><br/>
	/// </remarks>
	public const string SolutionFactoryField = "#=q5LqqljzNtmnhgkPPIsi28w==";

	/// <summary>
	/// Factory function that returns the length of all placed instructions (location of last instruction)
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Factory class<br/>
	/// 2. Look for the function of type <c>int</c> with no arguments that checks <c>this.#abcdef123456.Count == 0</c><br/>
	///    and calls <c>return this.#abcdef123456.Keys.Max(...</c><br/>
	///    The field it references is type <c>Dictionary&lt;Index2, Instructions&gt;</c>
	/// </remarks>
	public const string FactoryInstructionLenFunction = "#=q$GC2gP4iPWnyRqxOSKma7OwNAkMR6GF3Xd$14D9ZRcw=";
}
