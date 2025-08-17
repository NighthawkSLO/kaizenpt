using Kaizenpt.Consts;
using Kaizenpt.Wrappers.Meta;

namespace Kaizenpt.Wrappers;

[TypeWrapper(MappedClass.SolutionClass)]
public class Solution : NonStaticWrapper<Solution>
{
	internal Solution(object inner)
		: base(inner) { }

#pragma warning disable CA1031
	public static Solution? FromFile(string filename)
	{
		try
		{
			MaybeSolution solution = new(CallStatic(MappedFunction.SolutionFromFileBytesFunction, FileBytes.FromFile(filename).Inner!)!);
			return solution.IsSome() ? new Solution(solution.Unwrap()) : null;
		}
		catch (Exception)
		{
			// If the file is invalid, the function will throw an IndexOutOfRangeException
			return null;
		}
	}
#pragma warning restore CA1031

	public Puzzle GetPuzzle()
	{
		return new(Get(MappedField.SolutionPuzzleField)!);
	}

	public Factory GetFactory()
	{
		return new(Get(MappedField.SolutionFactoryField)!);
	}
}

[TypeWrapper(MappedClass.FileBytesClass)]
internal sealed class FileBytes : NonStaticWrapper<FileBytes>
{
	internal FileBytes(object inner)
		: base(inner) { }

	public static FileBytes FromFile(string filename)
	{
		return new FileBytes(CallConstructor(File.ReadAllBytes(filename))!);
	}
}
