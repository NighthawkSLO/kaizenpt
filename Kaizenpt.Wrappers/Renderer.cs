using Kaizenpt.Wrappers.Meta;
using static Kaizenpt.Consts;

namespace Kaizenpt.Wrappers;

[TypeWrapper(RendererClass)]
public class Renderer : StaticWrapper<Renderer>
{
	public static void Initialize(RendererType type)
	{
		_ = CallStatic(RendererInitializeFunction, type)!;
	}
}
