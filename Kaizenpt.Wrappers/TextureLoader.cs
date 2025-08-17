using Kaizenpt.Consts;
using Kaizenpt.Wrappers.Meta;

namespace Kaizenpt.Wrappers;

[TypeWrapper(MappedClass.TextureLoader)]
public class TextureLoader : StaticWrapper<TextureLoader>
{
	public static void LoadTexturesNoCallbacks()
	{
		_ = CallStatic(MappedFunction.LoadTexturesNoCallbacksFunction)!;
	}
}
