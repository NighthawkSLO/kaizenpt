using System.Diagnostics.CodeAnalysis;
using Kaizenpt.Wrappers.Meta;
using static Kaizenpt.Consts;

namespace Kaizenpt.Wrappers;

[TypeWrapper("Sim")]
public class Simulation : NonStaticWrapper<Simulation>
{
	internal Simulation(object inner)
		: base(inner) { }

	public static Simulation FromSolution([NotNull] Solution solution)
	{
		return new Simulation(CallConstructor(solution.Inner)!)!;
	}

	public void Run(int steps)
	{
		_ = Call(SimulationRunFunction, steps, 0, false, false)!;
	}

	public int GetSolvedOnStep()
	{
		MaybeInt finished = new(Get(SimulationFinishedField)!);
		return finished.IsSome() ? 1 + finished.Unwrap() : -1;
	}

	public Index2 GetUsedArea()
	{
		return new Range2(Get(SimulationUsedAreaField)!).GetSize();
	}

	public bool HasErrors => (bool)Call(SimulationHasErrorsFunction)!;
}

[TypeWrapper("Range2")]
internal sealed class Range2 : NonStaticWrapper<Range2>
{
	internal Range2(object inner)
		: base(inner) { }

	public Index2 GetSize()
	{
		return new(GetProperty("Size")!);
	}
}

[TypeWrapper("Index2")]
public class Index2 : NonStaticWrapper<Index2>
{
	internal Index2(object inner)
		: base(inner) { }

	public int GetX()
	{
		return (int)Get("X")!;
	}

	public int GetY()
	{
		return (int)Get("Y")!;
	}
}
