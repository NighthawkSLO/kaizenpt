namespace Kaizenpt;

public static partial class Consts
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
	public const string GameLogicStaticInstanceField = "#=qZPQSy2W0dAye577g3hFglA==";

	/// <summary>
	/// GameLogic field for the current platform (Windows/other).
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the GameLogic class<br/>
	/// 2. First private field, is a private enum type, should be right below instance field<br/>
	/// <br/>
	/// Possible enum values:<br/>
	/// 1 if windows, 0 otherwise
	/// </remarks>
	public const string GameLogicPlatformField = "#=qqvF9clevUelG0s3_w0EpgEdDxkzdr$uvliuQIy2luT0=";

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
	public const string FontLoaderHelperClass = "#=q32bWV2iLSSano80V1Tu6XQ==";

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
	public const string FontLoaderHelperFunction = "#=qeWSI59tv4MYJgm4fbp6GtQ==";

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
	public const string GameLogicInitializeFontsFunction = "#=qPlSyRt8l34OgQFwoK7jbXcRsTgsvSkrc66rcbZVfFJs=";

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
	public const string GameLogicInitializePuzzlesFunction = "#=qrwNy0Kr2blfsfhx7fyllUARM2$TOIXFE8XQD$iROwg4=";
}
