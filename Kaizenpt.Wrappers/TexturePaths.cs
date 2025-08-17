using Kaizenpt.Wrappers.Meta;
using static Kaizenpt.Consts;

namespace Kaizenpt.Wrappers;

[TypeWrapper(TexturePathHelperClass)]
public class TexturePathHelper : StaticWrapper<TexturePathHelper>
{
	public static void InitMainGameTexturePaths()
	{
		new InitGameTexturePaths(CallStatic(InitGameTexturePathsInstanceFunction)!)
			.InitMainGameTexturePaths();
	}
}

[TypeWrapper(InitGameTexturePathsClass)]
internal sealed class InitGameTexturePaths : NonStaticWrapper<InitGameTexturePaths>
{
	internal InitGameTexturePaths(object inner)
		: base(inner) { }

	public void InitMainGameTexturePaths()
	{
		_ = Call(InitMainGameTexturePathsFunction);
	}
}
