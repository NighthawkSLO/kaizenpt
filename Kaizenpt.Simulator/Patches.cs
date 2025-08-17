using HarmonyLib;

namespace Kaizenpt.Simulator;

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
