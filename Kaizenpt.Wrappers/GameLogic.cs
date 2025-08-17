using Kaizenpt.Consts;
using Kaizenpt.Wrappers.Meta;

namespace Kaizenpt.Wrappers;

[TypeWrapper(MappedClass.GameLogicClass)]
public class GameLogic : NonStaticWrapper<GameLogic>
{
	public GameLogic(object inner)
		: base(inner) { }

	public GameLogic()
		: base(CallConstructor()!) { }

	public void SetStaticInstanceToSelf()
	{
		SetStatic(MappedField.GameLogicStaticInstanceField, Inner);
	}

	public void SetPlatform(int value)
	{
		Set(MappedField.GameLogicPlatformField, value);
	}

	public void InitializeFonts()
	{
		_ = Call(MappedFunction.GameLogicInitializeFontsFunction)!;
	}

	public void InitializePuzzles()
	{
		_ = Call(MappedFunction.GameLogicInitializePuzzlesFunction)!;
	}
}
