using Kaizenpt.Wrappers.Meta;
using static Kaizenpt.Consts;

namespace Kaizenpt.Wrappers;

[TypeWrapper("GameLogic")]
public class GameLogic : NonStaticWrapper<GameLogic>
{
	public GameLogic(object inner)
		: base(inner) { }

	public GameLogic()
		: base(CallConstructor()!) { }

	public void SetStaticInstanceToSelf()
	{
		SetStatic(GameLogicStaticInstanceField, Inner);
	}

	public void SetRenderer(RendererType type)
	{
		Set(GameLogicRendererField, type);
	}

	public void CreateWindow(string title, int width, int height, int display)
	{
		_ = Call(GameLogicCreateWindowFunction, title, width, height, display)!;
	}

	public void InitializeFonts()
	{
		_ = Call(GameLogicInitializeFontsFunction)!;
	}

	public void InitializePuzzles()
	{
		_ = Call(GameLogicInitializePuzzlesFunction)!;
	}
}
