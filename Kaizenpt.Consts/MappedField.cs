namespace Kaizenpt.Consts;

public enum MappedField
{
	/// <summary>
	/// The static instance field of the GameLogic class.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Entry point<br/>
	/// 2. Game logic initialization function<br/>
	/// 3. The field at the start that is written to with <c>GameLogic.#abcdef123456 = this</c>.
	/// </remarks>
	GameLogicStaticInstanceField,

	/// <summary>
	/// GameLogic field for the current renderer.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the GameLogic class<br/>
	/// 2. First private field, is a private enum type, should be right below instance field<br/>
	/// <br/>
	/// Possible enum values:<br/>
	/// 0 - OpenGL, 1 - Direct3D
	/// </remarks>
	GameLogicRendererField,

	/// <summary>
	/// Sim field that has a value when the simulation is finished.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Sim class<br/>
	/// 2. Look for the field of type <c>Maybe&lt;int&gt;</c><br/>
	/// </remarks>
	SimulationFinishedField,

	/// <summary>
	/// Sim field for the size of the used area.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Sim class<br/>
	/// 2. Look for the field of type <c>Range2</c>
	/// </remarks>
	SimulationUsedAreaField,

	/// <summary>
	/// Solution field that contains the Puzzle instance.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Solution class<br/>
	/// 2. Look for the field of type <c>Puzzle</c><br/>
	/// </remarks>
	SolutionPuzzleField,

	/// <summary>
	/// Solution field that contains the Factory instance.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Solution class<br/>
	/// 2. Look for the field of type <c>Factory</c><br/>
	/// </remarks>
	SolutionFactoryField,

	/// <summary>
	/// Puzzle field that returns the id of the puzzle.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Puzzle class<br/>
	/// 2. Find the <c>static void</c> function with no arguments that creates all the static puzzles<br/>
	/// 3. Look for the integers being assigned to a field on ContentType&lt;Puzzle&gt; construction<br/>
	/// 4. Find the field the integers are being assigned to.
	/// </remarks>
	PuzzleIdField,

	/// <summary>
	/// The X field of Index2.
	/// </summary>
	Index2X,

	/// <summary>
	/// The Y field of Index2.
	/// </summary>
	Index2Y,
}
