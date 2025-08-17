using System.Reflection;

namespace Kaizenpt.Wrappers.Meta;

public static class Globals
{
	public static string? KaizenDirectory { get; set; }

	public static Assembly KaizenAssembly => Assembly.LoadFile(Path.Join(KaizenDirectory, "Kaizen.exe"));
}
