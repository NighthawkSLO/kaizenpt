using Kaizenpt.Wrappers.Meta;
using static Kaizenpt.Consts;

namespace Kaizenpt.Wrappers;

[TypeWrapper("TextureLoader")]
public class TextureLoader : StaticWrapper<TextureLoader>
{
	public static void LoadTexturesNoCallbacks()
	{
		_ = CallStatic(LoadTexturesNoCallbacksFunction)!;
	}
}

[TypeWrapper(TextureHelperClass)]
public class TextureHelper : StaticWrapper<TextureHelper>
{
	public static void DoStuff(int platform)
	{
		_ = CallStatic(TextureHelperFunction, platform)!;
	}
}
