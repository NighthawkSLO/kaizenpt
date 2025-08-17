using Kaizenpt.Consts;
using Kaizenpt.Wrappers.Meta;

namespace Kaizenpt.Wrappers;

[TypeWrapper(MappedClass.ToolClass)]
public class Tool : NonStaticWrapper<Tool>
{
	internal Tool(object inner)
		: base(inner) { }

	public int GetCost()
	{
		return (int)Call(MappedFunction.ToolCostFunction)!;
	}
}
