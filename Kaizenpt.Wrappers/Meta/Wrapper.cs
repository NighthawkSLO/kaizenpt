using System.Reflection;
using Kaizenpt.Consts;

namespace Kaizenpt.Wrappers.Meta;

public abstract class NonStaticWrapper<T>(object inner) : Wrapper<T>(inner)
{
	protected static object? CallConstructor(params object[] arguments)
	{
		ConstructorInfo constructor =
			WrappedType.GetConstructor([.. arguments.Select(a => a.GetType())])
			?? throw new FindMemberException($@"Failed to find constructor for type ""${WrappedType.AssemblyQualifiedName}""");
		return constructor.Invoke(BindingFlags.DoNotWrapExceptions, null, arguments, null);
	}
}

public abstract class StaticWrapper<T> : Wrapper<T>
{
}

public class Wrapper<T>
{
	public Wrapper(object inner)
	{
		Inner = inner;
	}

	public Wrapper()
	{
		Inner = null;
	}

	protected static Type WrappedType { get; } = GetWrappedType();

	public object? Inner { get; }

	protected object? Get(MappedField field)
	{
		var fieldInfo = MappedMembers.MappedFields[field];
		return fieldInfo.GetValue(Inner);
	}

	protected void Set(MappedField field, object? value)
	{
		var fieldInfo = MappedMembers.MappedFields[field];
		fieldInfo.SetValue(Inner, value);
	}

	protected object? Get(MappedProperty property)
	{
		var propertyInfo = MappedMembers.MappedProperties[property];
		return propertyInfo.GetValue(Inner);
	}

	protected object? Call(MappedFunction method, params object[] arguments)
	{
		var methodInfo = MappedMembers.MappedFunctions[method];
		return methodInfo.Invoke(Inner, arguments);
	}

	private static Type GetWrappedType()
	{
		TypeWrapperAttribute? classWrapperAttribute = typeof(T).GetCustomAttribute<TypeWrapperAttribute>();
		return classWrapperAttribute is not null
			? classWrapperAttribute.InnerType
			: throw new MissingAttributeException($"Missing {nameof(TypeWrapperAttribute)} on {typeof(T).FullName}");
	}

	protected static object? GetStatic(MappedField field)
	{
		var fieldInfo = MappedMembers.MappedFields[field];
		return fieldInfo.GetValue(null);
	}

	protected static void SetStatic(MappedField field, object? value)
	{
		var fieldInfo = MappedMembers.MappedFields[field];
		fieldInfo.SetValue(null, value);
	}

	protected static object? CallStatic(MappedFunction function, params object[] arguments)
	{
		var methodInfo = MappedMembers.MappedFunctions[function];
		return methodInfo.Invoke(null, arguments);
	}
}
