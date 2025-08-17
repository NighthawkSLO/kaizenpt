using Kaizenpt.Consts;
using Kaizenpt.Wrappers.Meta;

namespace Kaizenpt.Wrappers;

[TypeWrapper(MappedClass.FontLoaderHelperClass)]
public class FontLoaderHelper : StaticWrapper<FontLoaderHelper>
{
	public static void DoStuff()
	{
		_ = CallStatic(MappedFunction.FontLoaderHelperFunction)!;
	}
}
