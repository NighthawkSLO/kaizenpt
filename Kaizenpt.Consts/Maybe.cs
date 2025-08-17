namespace Kaizenpt;

public static partial class Consts
{
	/// <summary>
	/// TMaybe&lt;T&gt; function that checks if the value is present.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Maybe class<br/>
	/// 2. Look for the function at the start that returns a field <c>this.#abcdef123456</c><br/>
	/// 3. Verify that the function is <c>bool</c> and has no arguments.
	/// </remarks>
	public const string MaybeIsSomeFunction = "#=qXmfAL30t6WSce83ReYNZOQ==";

	/// <summary>
	/// Maybe&lt;T&gt; function that unwraps the value.
	/// </summary>
	/// <remarks>
	/// How to find:<br/>
	/// 1. Find the Maybe class<br/>
	/// 2. Look for the function that checks <c>!IsSome()</c> and throws <c>InvalidOperationException</c>, and returns the T field if available<br/>
	/// 3. Verify that the function is <c>T</c> and has no arguments.
	/// </remarks>
	public const string MaybeUnwrapFunction = "#=qhVIz$6ydPoTwj1Z6PACv1g==";
}
