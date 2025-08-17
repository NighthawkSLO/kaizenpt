using Kaizenpt.Consts;

namespace Kaizenpt.Wrappers.Meta;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class TypeWrapperAttribute(MappedClass innerClass) : Attribute
{
	public MappedClass InnerClass { get; } = innerClass;

	public Type InnerType => MappedMembers.MappedTypes[InnerClass];
}
