using Kaizenpt.Consts;
using Kaizenpt.Wrappers.Meta;

namespace Kaizenpt.Wrappers;

[TypeWrapper(MappedClass.FactoryClass)]
public class Factory : NonStaticWrapper<Factory>
{
	internal Factory(object inner)
		: base(inner) { }

	public int GetInstructionLength()
	{
		return (int)Call(MappedFunction.FactoryInstructionLenFunction)!;
	}

	public IEnumerable<Tool> GetTools()
	{
		IEnumerable<object> objects = (IEnumerable<object>)Call(MappedFunction.FactoryToolsFunction)!;
		return objects.Select(obj => new Tool(obj));
	}
}
