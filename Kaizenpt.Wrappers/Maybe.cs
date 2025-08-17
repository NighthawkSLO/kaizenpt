using Kaizenpt.Wrappers.Meta;
using static Kaizenpt.Consts;

[TypeWrapper("Maybe`1[[System.Int32, mscorlib]]")]
internal sealed class MaybeInt : NonStaticWrapper<MaybeInt>
{
	internal MaybeInt(object inner)
		: base(inner) { }

	public bool IsSome()
	{
		return (bool)Call(MaybeIsSomeFunction)!;
	}

	public int Unwrap()
	{
		return (int)Call(MaybeUnwrapFunction)!;
	}
}

[TypeWrapper("Maybe`1[[Solution, Game]]")]
internal sealed class MaybeSolution : NonStaticWrapper<MaybeSolution>
{
	internal MaybeSolution(object inner)
		: base(inner) { }

	public bool IsSome()
	{
		return (bool)Call(MaybeIsSomeFunction)!;
	}

	public object Unwrap()
	{
		return Call(MaybeUnwrapFunction)!;
	}
}
