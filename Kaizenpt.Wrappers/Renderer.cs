using Kaizenpt.Consts;
using Kaizenpt.Wrappers.Meta;

namespace Kaizenpt.Wrappers;

[TypeWrapper(MappedClass.RendererClass)]
public class Renderer : StaticWrapper<Renderer>
{
	public static void Initialize(RendererType type)
	{
		_ = CallStatic(MappedFunction.RendererInitializeFunction, type);
	}
}
