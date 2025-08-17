namespace Kaizenpt.Consts;

public enum MappedFunction
{
	/// <summary>
	/// Factory function that returns all tools.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Factory class<br/>
	/// 2. Look for the function at the start that returns a field <c>this.#abcdef123456</c><br/>
	/// 3. Verify that the function is <c>IEnumerable&lt;Tool&gt;</c> and has no arguments.
	/// </remarks>
	FactoryToolsFunction,

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
	FactoryInstructionLenFunction,

	/// <summary>
	/// The helper function that does some needed font/language related stuff for GameLogic instance.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Entry point<br/>
	/// 2. Game logic initialization function<br/>
	/// 3. Find the other function that also writes to the static GameLogic instance <c>GameLogic.#abcdef123456 = this</c>.<br/>
	/// 4. Find the function that is called right after the GameLogic instance is set<br/>
	/// 5. Verify that the function is in a class that has a lot of language related functionality.<br/>
	/// 6. Verify that the function is <c>void</c> and has no arguments.
	/// </remarks>
	FontLoaderHelperFunction,

	/// <summary>
	/// GameLogic function that initializes fonts.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Entry point<br/>
	/// 2. Game logic initialization function<br/>
	/// 3. Find the other function that also writes to the static GameLogic instance <c>GameLogic.#abcdef123456 = this</c>.<br/>
	/// 4. Find the function that is called right after the helper function for setting font/language related stuff.<br/>
	/// 5. Verify that the function references FontLoader.<br/>
	/// 6. Verify that the function is <c>void</c> and has no arguments.
	/// </remarks>
	GameLogicInitializeFontsFunction,

	/// <summary>
	/// GameLogic function that initializes puzzles and puzzle prerequisites.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Entry point<br/>
	/// 2. Game logic initialization function<br/>
	/// 3. Find the other function that also writes to the static GameLogic instance <c>GameLogic.#abcdef123456 = this</c>.<br/>
	/// 4. Find the function that is called after initializing fonts.<br/>
	/// 5. Verify that the function references Puzzle.<br/>
	/// 6. Verify that the function is <c>void</c> and has no arguments.
	/// </remarks>
	GameLogicInitializePuzzlesFunction,

	/// <summary>
	/// TMaybe&lt;int&gt; function that checks if the value is present.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Maybe class<br/>
	/// 2. Look for the function at the start that returns a field <c>this.#abcdef123456</c><br/>
	/// 3. Verify that the function is <c>bool</c> and has no arguments.
	/// </remarks>
	MaybeIntIsSomeFunction,

	/// <summary>
	/// Maybe&lt;int&gt; function that unwraps the value.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Maybe class<br/>
	/// 2. Look for the function that checks <c>!IsSome()</c> and throws <c>InvalidOperationException</c>, and returns the T field if available<br/>
	/// 3. Verify that the function is <c>T</c> and has no arguments.
	/// </remarks>
	MaybeIntUnwrapFunction,

	/// <summary>
	/// TMaybe&lt;Solution&gt; function that checks if the value is present.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Maybe class<br/>
	/// 2. Look for the function at the start that returns a field <c>this.#abcdef123456</c><br/>
	/// 3. Verify that the function is <c>bool</c> and has no arguments.
	/// </remarks>
	MaybeSolutionIsSomeFunction,

	/// <summary>
	/// Maybe&lt;Solution&gt; function that unwraps the value.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Maybe class<br/>
	/// 2. Look for the function that checks <c>!IsSome()</c> and throws <c>InvalidOperationException</c>, and returns the T field if available<br/>
	/// 3. Verify that the function is <c>T</c> and has no arguments.
	/// </remarks>
	MaybeSolutionUnwrapFunction,

	/// <summary>
	/// Sim function that runs the simulation for the specified number of steps.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Sim class<br/>
	/// 2. Look for the function that has arguments <c>(int, int, bool, bool)</c> and returns <c>SimAnimation[]</c><br/>
	/// </remarks>
	SimulationRunFunction,

	/// <summary>
	/// Sim function that indicates if the simulation has errors.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Sim class<br/>
	/// 2. Look for the <c>bool</c> function with no arguments that has <c>return this.#abcdef123456.Count > 0</c>. The field it's counting is type <c>List&lt;SimError&gt;</c><br/>
	/// </remarks>
	SimulationHasErrorsFunction,

	/// <summary>
	/// Solution function that creates a solution from a byte array.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Solution class<br/>
	/// 2. Look for the <c>static Maybe&lt;Solution&gt;</c> function<br/>
	/// </remarks>
	SolutionFromFileBytesFunction,

	/// <summary>
	/// The function from <see cref="MappedClass.TexturePathHelperClass"/> for the game texture path initialization.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Puzzle class<br/>
	/// 2. Look for the <c>static void</c> function that initializes all the puzzles<br/>
	/// 3. At the top of the function it first loads the helper class data into a variable<br/>
	/// 4. This is the function called from the static class
	/// </remarks>
	InitGameTexturePathsInstanceFunction,

	/// <summary>
	/// The function that initializes main game texture paths - everything except loading screen, which is a separate function.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Puzzle class<br/>
	/// 2. Look for the <c>static void</c> function that initializes all the puzzles<br/>
	/// 3. At the top of the function it first loads the helper class data into a variable<br/>
	/// 4. Find the last accessed field of that assignmentt<br/>
	/// 5. Analyze the functions that read from this field, find the one in <see cref="MappedClass.InitGameTexturePathsClass"/>
	/// </remarks>
	InitMainGameTexturePathsFunction,

	/// <summary>
	/// TextureLoader function that loads textures from the initialized texture paths (like <see cref="MappedClass.TexturePathHelperClass"/>) without callbacks.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the TextureLoader class<br/>
	/// 2. Look for the <c>static bool</c> function with no arguments. It only returns another TextureLoader function with predefined (empty) callbacks<br/>
	/// </remarks>
	LoadTexturesNoCallbacksFunction,

	/// <summary>
	/// Tool function that returns the cost.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Tool class<br/>
	/// 2. Look for the function that returns an integer
	/// </remarks>
	ToolCostFunction,

	/// <summary>
	/// Initialize function from a static helper class that initializes the graphics library.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Entry point<br/>
	/// 2. Game logic initialization function<br/>
	/// 3. The function called that references the current renderer (<see cref="MappedField.GameLogicRendererField"/>)<br/>
	/// 4. Verify that the function is <c>static void</c> and has an enum argument<br/>
	/// </remarks>
	RendererInitializeFunction,

	/// <summary>
	/// GameLogic function that creates a window.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the GameLogic class<br/>
	/// 2. Find the function with <c>(string, int, int, int)</c> arguments. Inside, it should call SDL_CreateWindow
	/// </remarks>
	GameLogicCreateWindowFunction,
}
