using System.Diagnostics;

namespace Kaizenpt.Wrappers.Meta;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class TypeWrapperAttribute(string innerTypeName) : Attribute
{
	public string InnerTypeName { get; } = innerTypeName;

	public Type InnerType { get; } =
		Type.GetType($"{innerTypeName}, Game")
		?? throw new FindMemberException($@"Failed to find type ""{innerTypeName}"" in assembly ""Game""");
}

[AttributeUsage(AttributeTargets.Method)]
internal sealed class MethodWrapperAttribute(string innerMethodName) : Attribute
{
	public string InnerMethodName { get; private set; } = innerMethodName;

	public static object Stub()
	{
		throw new UnreachableException("Method intended to be reverse patched");
	}
}
