using Kaizenpt.Wrappers.Meta;
using static Kaizenpt.Consts;

namespace Kaizenpt.Wrappers;

[TypeWrapper("Solution")]
public class Solution : NonStaticWrapper<Solution>
{
	internal Solution(object inner)
		: base(inner) { }

	public static Solution? FromFile(string filename)
	{
		try
		{
			MaybeSolution solution = new(CallStatic(SolutionFromFileBytesFunction, FileBytes.FromFile(filename).Inner)!);
			return solution.IsSome() ? new Solution(solution.Unwrap()) : null;
		}
		catch (IndexOutOfRangeException)
		{
			// If the file is invalid, the function will throw an IndexOutOfRangeException
			return null;
		}
	}

	public Puzzle GetPuzzle()
	{
		return new(Get(SolutionPuzzleField)!);
	}

	public Factory GetFactory()
	{
		return new(Get(SolutionFactoryField)!);
	}
}

[TypeWrapper(FileBytesClass)]
internal sealed class FileBytes : NonStaticWrapper<FileBytes>
{
	internal FileBytes(object inner)
		: base(inner) { }

	public static FileBytes FromFile(string filename)
	{
		return new FileBytes(CallConstructor(File.ReadAllBytes(filename))!);
	}
}
