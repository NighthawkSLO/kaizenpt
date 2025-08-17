namespace Kaizenpt;

public static partial class Consts
{
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
	public const string RendererClass = "#=qHAdUMBQyGQDfNMkZGy1u4A==";

	/// <summary>
	/// Initialize function from a static helper class that initializes the graphics library.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Entry point<br/>
	/// 2. Game logic initialization function<br/>
	/// 3. The function called that references the current renderer (<see cref="GameLogicRendererField"/>)<br/>
	/// 4. Verify that the function is <c>static void</c> and has an enum argument<br/>
	/// </remarks>
	public const string RendererInitializeFunction = "#=qycqiEjFGSqlug8foaFMujg==";
}
