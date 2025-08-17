using Kaizenpt.Consts;
using Kaizenpt.Wrappers.Meta;

namespace Kaizenpt.Wrappers;

[TypeWrapper(MappedClass.TexturePathHelperClass)]
public class TexturePathHelper : StaticWrapper<TexturePathHelper>
{
	public static void InitMainGameTexturePaths()
	{
		new InitGameTexturePaths(CallStatic(MappedFunction.InitGameTexturePathsInstanceFunction)!)
			.InitMainGameTexturePaths();
	}
}

[TypeWrapper(MappedClass.InitGameTexturePathsClass)]
internal sealed class InitGameTexturePaths : NonStaticWrapper<InitGameTexturePaths>
{
	internal InitGameTexturePaths(object inner)
		: base(inner) { }

	public void InitMainGameTexturePaths()
	{
		_ = Call(MappedFunction.InitMainGameTexturePathsFunction);
	}
}
