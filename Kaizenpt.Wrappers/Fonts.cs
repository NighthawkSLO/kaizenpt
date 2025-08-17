using Kaizenpt.Wrappers.Meta;
using static Kaizenpt.Consts;

namespace Kaizenpt.Wrappers;

[TypeWrapper(FontLoaderHelperClass)]
public class FontLoaderHelper : StaticWrapper<FontLoaderHelper>
{
	public static void DoStuff()
	{
		_ = CallStatic(FontLoaderHelperFunction)!;
	}
}
