namespace Kaizenpt.Consts;

public enum MappedClass
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
	FileBytesClass,

	/// <summary>
	/// The helper class that does some needed font/language related stuff for GameLogic instance.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Entry point<br/>
	/// 2. Game logic initialization function<br/>
	/// 3. Find the other function that also writes to the static GameLogic instance <c>GameLogic.#abcdef123456 = this</c>.<br/>
	/// 4. Find the function that is called right after the GameLogic instance is set<br/>
	/// 5. Verify that the function is in a class that has a lot of language related functionality.<br/>
	/// 6. Verify that the function is <c>void</c> and has no arguments.
	/// 7. This is the <c>static class</c> of the function
	/// </remarks>
	FontLoaderHelperClass,

	/// <summary>
	/// The class containing static helper functions that get the correct field of the GameLogic instance for texture path initialization.
	/// <br/>
	/// We only need the game textures field, there's also one for fonts and some other things that I'm not sure what they're for.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Puzzle class<br/>
	/// 2. Look for the <c>static void</c> function that initializes all the puzzles<br/>
	/// 3. At the top of the function it first loads the helper class data into a variable<br/>
	/// 4. This is the class at the start of the function call chain
	/// </remarks>
	TexturePathHelperClass,

	/// <summary>
	/// The class responsible for initializing paths to game texture files.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Puzzle class<br/>
	/// 2. Look for the <c>static void</c> function that initializes all the puzzles<br/>
	/// 3. At the top of the function it first loads the helper class data into a variable<br/>
	/// 4. This is the return type of the function called from the static class
	/// </remarks>
	InitGameTexturePathsClass,

	/// <summary>
	/// Class with name Factory.
	/// </summary>
	FactoryClass,

	/// <summary>
	/// Class with name GameLogic.
	/// </summary>
	GameLogicClass,

	/// <summary>
	/// Generic class Maybe&lt;T&gt;.
	/// </summary>
	MaybeGenericClass,

	/// <summary>
	/// Maybe&lt;Solution&gt; class.
	/// </summary>
	MaybeSolutionClass,

	/// <summary>
	/// Maybe&lt;int&gt; class.
	/// </summary>
	MaybeIntClass,

	/// <summary>
	/// Class with name Puzzle.
	/// </summary>
	PuzzleClass,

	/// <summary>
	/// Class with name Solution.
	/// </summary>
	SolutionClass,

	/// <summary>
	/// Class with name Sim.
	/// </summary>
	SimClass,

	/// <summary>
	/// Class with name Tool.
	/// </summary>
	ToolClass,

	/// <summary>
	/// Class with name Bounds2.
	/// </summary>
	Bounds2Class,

	/// <summary>
	/// Class with name Range2.
	/// </summary>
	Range2Class,

	/// <summary>
	/// Class with name Index2.
	/// </summary>
	Index2Class,

	/// <summary>
	/// Class with name TextureLoader.
	/// </summary>
	TextureLoader,

	/// <summary>
	/// A static helper class that initializes the graphics library
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Entry point<br/>
	/// 2. Game logic initialization function<br/>
	/// 3. The function called that references the current renderer (<see cref="GameLogicRendererField"/>)<br/>
	/// 4. Verify that the function is <c>static void</c> and has an enum argument<br/>
	/// 5. This is the <c>static class</c> of the function
	/// </remarks>
	RendererClass,
}
