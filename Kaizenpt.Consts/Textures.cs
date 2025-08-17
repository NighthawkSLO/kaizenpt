namespace Kaizenpt;

public static partial class Consts
{
	/// <summary>
	/// TextureLoader function that loads textures from the initialized texture paths (like <see cref="TexturePathHelperClass"/>) without callbacks.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the TextureLoader class<br/>
	/// 2. Look for the <c>static bool</c> function with no arguments. It only returns another TextureLoader function with predefined (empty) callbacks<br/>
	/// </remarks>
	public const string LoadTexturesNoCallbacksFunction = "#=qTjdlBvw$dX7LxbDsNhPGhA==";

	/// <summary>
	/// A static helper class that does a needed texture related thing based on current platform.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Entry point<br/>
	/// 2. Game logic initialization function<br/>
	/// 3. The function called that references the current platform (<see cref="GameLogicPlatformField"/>)<br/>
	/// 4. Verify that the function is <c>static void</c> and has an enum argument<br/>
	/// 5. This is the <c>static class</c> of the function
	/// </remarks>
	public const string TextureHelperClass = "#=qHAdUMBQyGQDfNMkZGy1u4A==";

	/// <summary>
	/// A function from a static helper class that does a needed texture related thing based on current platform.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Entry point<br/>
	/// 2. Game logic initialization function<br/>
	/// 3. The function called that references the current platform (<see cref="GameLogicPlatformField"/>)<br/>
	/// 4. Verify that the function is <c>static void</c> and has an enum argument<br/>
	/// </remarks>
	public const string TextureHelperFunction = "#=qycqiEjFGSqlug8foaFMujg==";
}
