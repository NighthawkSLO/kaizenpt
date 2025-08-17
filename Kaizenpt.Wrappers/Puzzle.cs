using Kaizenpt.Consts;
using Kaizenpt.Wrappers.Meta;

namespace Kaizenpt.Wrappers;

[TypeWrapper(MappedClass.PuzzleClass)]
public class Puzzle : NonStaticWrapper<Puzzle>
{
	internal Puzzle(object inner)
		: base(inner) { }

	public int GetId()
	{
		return (int)Get(MappedField.PuzzleIdField)!;
	}
}
