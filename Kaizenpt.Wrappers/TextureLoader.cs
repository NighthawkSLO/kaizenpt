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
