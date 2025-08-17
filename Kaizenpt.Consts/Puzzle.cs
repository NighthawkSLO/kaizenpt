namespace Kaizenpt;

public static partial class Consts
{
	/// <summary>
	/// Puzzle function that returns the id of the puzzle.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Puzzle class<br/>
	/// 2. Find the <c>static void</c> function with no arguments that creates all the static puzzles<br/>
	/// 3. Look for the integers being assigned to a field on ContentType&lt;Puzzle&gt; construction<br/>
	/// 4. Find the field the integers are being assigned to.
	/// </remarks>
	public const string PuzzleIdFunction = "#=qb5KVcWZ4tal127LIcnXzzA==";
}
