using Kaizenpt.Wrappers.Meta;
using static Kaizenpt.Consts;

namespace Kaizenpt.Wrappers;

[TypeWrapper("Puzzle")]
public class Puzzle : NonStaticWrapper<Puzzle>
{
	internal Puzzle(object inner)
		: base(inner) { }

	public int GetId()
	{
		return (int)Get(PuzzleIdFunction)!;
	}
}
