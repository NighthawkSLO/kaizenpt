using Kaizenpt.Consts;
using Kaizenpt.Wrappers.Meta;

namespace Kaizenpt.Wrappers;

[TypeWrapper(MappedClass.MaybeIntClass)]
internal sealed class MaybeInt : NonStaticWrapper<MaybeInt>
{
	internal MaybeInt(object inner)
		: base(inner) { }

	public bool IsSome()
	{
		return (bool)Call(MappedFunction.MaybeIntIsSomeFunction)!;
	}

	public int Unwrap()
	{
		return (int)Call(MappedFunction.MaybeIntUnwrapFunction)!;
	}
}

[TypeWrapper(MappedClass.MaybeSolutionClass)]
internal sealed class MaybeSolution : NonStaticWrapper<MaybeSolution>
{
	internal MaybeSolution(object inner)
		: base(inner) { }

	public bool IsSome()
	{
		return (bool)Call(MappedFunction.MaybeSolutionIsSomeFunction)!;
	}

	public object Unwrap()
	{
		return Call(MappedFunction.MaybeSolutionUnwrapFunction)!;
	}
}
