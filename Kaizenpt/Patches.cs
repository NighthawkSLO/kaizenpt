using HarmonyLib;
using static Kaizenpt.Consts;

namespace Kaizenpt;

[HarmonyPatch]
internal static class PatchGameLogicStaticConstructor
{
	/// <summary>
	/// Patches the game logic static constructor to do nothing
	/// </summary>
	/// <returns></returns>
	[HarmonyPatch("GameLogic, Game", null, MethodType.StaticConstructor)]
	[HarmonyPrefix]
	public static bool GameLogicStaticConstructorPrefix()
	{
		return false;
	}
}

[HarmonyPatch]
internal static class PatchTextureLoading
{
	/// <summary>
	/// Patches the texture loading so that we only load puzzle related textures (Products)
	/// </summary>
	/// <param name="instructions"></param>
	/// <returns></returns>
	[HarmonyPatch(InitGameTexturePathsClass + ", Game", InitMainGameTexturePathsFunction)]
	[HarmonyTranspiler]
	public static IEnumerable<CodeInstruction> TranspileLoadAllTextures(
		IEnumerable<CodeInstruction> instructions
	)
	{
		return instructions
			.Skip(InitProductTexturePathsStart)
			.Take(InitProductTexturePathsEnd - InitProductTexturePathsStart);
	}
}
