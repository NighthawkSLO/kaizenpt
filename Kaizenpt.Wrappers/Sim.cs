using System.Diagnostics.CodeAnalysis;
using Kaizenpt.Consts;
using Kaizenpt.Wrappers.Meta;

namespace Kaizenpt.Wrappers;

[TypeWrapper(MappedClass.SimClass)]
public class Sim : NonStaticWrapper<Sim>
{
	internal Sim(object inner)
		: base(inner) { }

	public static Sim FromSolution([NotNull] Solution solution)
	{
		return new Sim(CallConstructor(solution.Inner!)!)!;
	}

	public void Run(int steps)
	{
		_ = Call(MappedFunction.SimulationRunFunction, steps, 0, false, false)!;
	}

	public int GetSolvedOnStep()
	{
		MaybeInt finished = new(Get(MappedField.SimulationFinishedField)!);
		return finished.IsSome() ? 1 + finished.Unwrap() : -1;
	}

	public Index2 GetUsedArea()
	{
		return new Range2(Get(MappedField.SimulationUsedAreaField)!).GetSize();
	}

	public bool HasErrors => (bool)Call(MappedFunction.SimulationHasErrorsFunction)!;
}

[TypeWrapper(MappedClass.Range2Class)]
internal sealed class Range2 : NonStaticWrapper<Range2>
{
	internal Range2(object inner)
		: base(inner) { }

	public Index2 GetSize()
	{
		return new(Get(MappedProperty.Range2Size)!);
	}
}

[TypeWrapper(MappedClass.Index2Class)]
public class Index2 : NonStaticWrapper<Index2>
{
	internal Index2(object inner)
		: base(inner) { }

	public int GetX()
	{
		return (int)Get(MappedField.Index2X)!;
	}

	public int GetY()
	{
		return (int)Get(MappedField.Index2Y)!;
	}
}
