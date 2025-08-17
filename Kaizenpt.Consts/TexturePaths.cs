namespace Kaizenpt;

public static partial class Consts
{
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
	public const string TexturePathHelperClass = "#=qS$i4WfLZLxaQVtCrg2UNPw==";

	/// <summary>
	/// The function from <see cref="TexturePathHelperClass"/> for the game texture path initialization.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Puzzle class<br/>
	/// 2. Look for the <c>static void</c> function that initializes all the puzzles<br/>
	/// 3. At the top of the function it first loads the helper class data into a variable<br/>
	/// 4. This is the function called from the static class
	/// </remarks>
	public const string InitGameTexturePathsInstanceFunction = "#=qaFaONyv3tnoxdSiHxVJh6A==";

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
	public const string InitGameTexturePathsClass = "#=qBsOb885pSa59xsry5$LyiXtLiwAKDep6Cywji_g95hI=";

	/// <summary>
	/// The function that initializes main game texture paths - everything except loading screen, which is a separate function.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Puzzle class<br/>
	/// 2. Look for the <c>static void</c> function that initializes all the puzzles<br/>
	/// 3. At the top of the function it first loads the helper class data into a variable<br/>
	/// 4. Find the last accessed field of that assignmentt<br/>
	/// 5. Analyze the functions that read from this field, find the one in <see cref="InitGameTexturePathsClass"/>
	/// </remarks>
	public const string InitMainGameTexturePathsFunction = "#=qkJH0sYJuzm$VjtyPoz7lSw==";

	/// <summary>
	/// The index within <see cref="InitMainGameTexturePathsFunction"/> that starts assigning to the Product texture paths.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Puzzle class<br/>
	/// 2. Look for the <c>static void</c> function that initializes all the puzzles<br/>
	/// 3. At the top of the function it first loads the helper class data into a variable<br/>
	/// 4. Find the last accessed field of that assignment<br/>
	/// 5. Analyze the functions that read from this field, find the one in <see cref="InitGameTexturePathsClass"/>t<br/>
	/// 6. Get the IL instruction index of the first assignment to the field in the function
	/// </remarks>
	public const int InitProductTexturePathsStart = 9651;

	/// <summary>
	/// The index within <see cref="InitMainGameTexturePathsFunction"/> that ends assigning to the Product texture paths.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Puzzle class<br/>
	/// 2. Look for the <c>static void</c> function that initializes all the puzzles<br/>
	/// 3. At the top of the function it first loads the helper class data into a variable<br/>
	/// 4. Find the last accessed field of that assignment<br/>
	/// 5. Analyze the functions that read from this field, find the one in <see cref="InitGameTexturePathsClass"/>t<br/>
	/// 6. Get the IL instruction index past the last assignment to the field in the function
	/// </remarks>
	public const int InitProductTexturePathsEnd = 11108;
}
