using System.Reflection;

namespace Kaizenpt.Wrappers.Meta;

public abstract class NonStaticWrapper<T>(object inner) : Wrapper<T>
{
	protected internal object Inner { get; private set; } = inner;

	protected object? Get(string fieldName)
	{
		return Utils.Get(Inner, fieldName);
	}

	protected void Set(string fieldName, object? value)
	{
		Utils.Set(Inner, fieldName, value);
	}

	protected object? GetProperty(string propertyName)
	{
		return Utils.GetProperty(Inner, propertyName);
	}

	protected void SetProperty(string propertyName, object? value)
	{
		Utils.SetProperty(Inner, propertyName, value);
	}

	protected object? Call(string methodName, params object[] arguments)
	{
		return Utils.WithWorkingDirectory(
			Globals.KaizenDirectory!,
			() => Utils.CallNonStatic(Inner, methodName, arguments)
		);
	}

	protected static object? CallConstructor(params object[] arguments)
	{
		return Utils.CallConstructor(WrappedType, arguments);
	}
}

public abstract class StaticWrapper<T> : Wrapper<T>
{
	internal StaticWrapper()
	{
		throw new MethodAccessException("Types inheriting from StaticWrapper should not be instantiated.");
	}
}

public class Wrapper<T>
{
	private static readonly Type? _wrappedType = GetWrappedType();
	protected static Type WrappedType => _wrappedType!;

	static Wrapper()
	{
		HarmonyLib.Harmony harmony = new(nameof(T));
		foreach (MethodInfo method in typeof(T).GetMethods(BindingFlags.NonPublic | BindingFlags.Static))
		{
			MethodWrapperAttribute? wrapperAttribute = method.GetCustomAttribute<MethodWrapperAttribute>();
			if (wrapperAttribute is not null)
			{
				_ = harmony
					.CreateReversePatcher(WrappedType.GetMethod(wrapperAttribute.InnerMethodName), method)
					.Patch();
			}
		}
	}

	private static Type? GetWrappedType()
	{
		TypeWrapperAttribute? classWrapperAttribute = typeof(T).GetCustomAttribute<TypeWrapperAttribute>();
		return classWrapperAttribute is not null
			? classWrapperAttribute.InnerType
			: throw new MissingAttributeException($"Missing {nameof(TypeWrapperAttribute)} on {typeof(T).FullName}");
	}

	protected static object? GetStatic(string fieldName)
	{
		return Utils.GetStatic(WrappedType, fieldName);
	}

	protected static void SetStatic(string fieldName, object? value)
	{
		Utils.SetStatic(WrappedType, fieldName, value);
	}

	protected static object? CallStatic(string methodName, params object[] arguments)
	{
		return Utils.WithWorkingDirectory(
			Globals.KaizenDirectory!,
			() => Utils.CallStatic(WrappedType, methodName, arguments)
		);
	}
}
