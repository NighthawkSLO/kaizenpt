using Kaizenpt.Wrappers.Meta;
using static Kaizenpt.Consts;

namespace Kaizenpt.Wrappers;

[TypeWrapper("Tool")]
public class Tool : NonStaticWrapper<Tool>
{
	internal Tool(object inner)
		: base(inner) { }

	public int GetCost()
	{
		return (int)Call(ToolCostFunction)!;
	}
}
