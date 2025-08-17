using Kaizenpt.Wrappers.Meta;
using static Kaizenpt.Consts;

namespace Kaizenpt.Wrappers;

[TypeWrapper("Factory")]
public class Factory : NonStaticWrapper<Factory>
{
	internal Factory(object inner)
		: base(inner) { }

	public int GetInstructionLength()
	{
		return (int)Call(FactoryInstructionLenFunction)!;
	}

	public IEnumerable<Tool> GetTools()
	{
		IEnumerable<object> objects = (IEnumerable<object>)Call(FactoryToolsFunction)!;
		return objects.Select(obj => new Tool(obj));
	}
}
