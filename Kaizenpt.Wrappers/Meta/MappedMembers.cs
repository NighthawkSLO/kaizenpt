using System.Reflection;
using HarmonyLib;
using Kaizenpt.Consts;

namespace Kaizenpt.Wrappers.Meta;

public static class MappedMembers
{
	private static bool _initialized;
	private static Dictionary<MappedFunction, MethodInfo>? _mappedFunctions;
	private static Dictionary<MappedField, FieldInfo>? _mappedFields;
	private static Dictionary<MappedClass, Type>? _mappedTypes;
	private static Dictionary<MappedProperty, PropertyInfo>? _mappedProperties;

	public static IReadOnlyDictionary<MappedFunction, MethodInfo> MappedFunctions
	{
		get
		{
			if (!_initialized)
			{
				InitMappedMembers();
				_initialized = true;
			}

			return _mappedFunctions!;
		}
	}

	public static IReadOnlyDictionary<MappedField, FieldInfo> MappedFields
	{
		get
		{
			if (!_initialized)
			{
				InitMappedMembers();
				_initialized = true;
			}

			return _mappedFields!;
		}
	}

	public static IReadOnlyDictionary<MappedClass, Type> MappedTypes
	{
		get
		{
			if (!_initialized)
			{
				InitMappedMembers();
				_initialized = true;
			}

			return _mappedTypes!;
		}
	}

	public static IReadOnlyDictionary<MappedProperty, PropertyInfo> MappedProperties
	{
		get
		{
			if (!_initialized)
			{
				InitMappedMembers();
				_initialized = true;
			}

			return _mappedProperties!;
		}
	}

	private static void InitMappedMembers()
	{
		var gameLogicType = Globals.KaizenAssembly.GetType("GameLogic")!;
		var gameLogicStaticInstanceField = gameLogicType
			.GetFields(BindingFlags.Public | BindingFlags.Static)
			.Single(field => field.FieldType == gameLogicType); // GameLogicStaticInstanceField

		var rendererTypeField = gameLogicType
			.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
			.Single(x => x.FieldType.IsEnum); //GameLogicPlatformField
		var fontLoaderHelperClass = gameLogicType.Assembly.GetTypes().Single(x => x.IsStatic() && x
			.GetFields(BindingFlags.Public | BindingFlags.Static)
			.Any(y => y.FieldType.Name == "Language")); // FontLoaderHelperClass;
		var fontLoaderHelperFunction = fontLoaderHelperClass
			.GetMethods(BindingFlags.Public | BindingFlags.Static).Single(x => x.ReturnType == typeof(void));
		var gameLogicInitializeFontsFunction =
			gameLogicType
				.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
				.Where(x => x.ReturnType == typeof(void) && x.GetParameters().Length == 0).Single(x =>
					x.GetMethodBody()!.ExceptionHandlingClauses.Count == 0 &&
					x.GetMethodBody()!.LocalVariables.Count == 0 &&
					x.GetMethodBody()!.GetILAsByteArray()!.Length == 33);

		var gameLogicInitializePuzzlesFunction =
			gameLogicType
				.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
				.Where(x => x.ReturnType == typeof(void) && x.GetParameters().Length == 0).Single(x =>
					x.GetMethodBody()!.ExceptionHandlingClauses.Count == 0 &&
					x.GetMethodBody()!.LocalVariables.Count == 0 &&
					x.GetMethodBody()!.GetILAsByteArray()!.Length == 31);

		var puzzleClass = gameLogicType.Assembly.GetTypes().Single(x => x.Name == "Puzzle");
		var puzzleIdField = puzzleClass.GetFields(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.FieldType == typeof(int) && x.DeclaringType!.Name != "Puzzle");

		var factoryClass = gameLogicType.Assembly.GetTypes().Single(x => x.Name == "Factory");
		var toolClass = gameLogicType.Assembly.GetTypes().Single(x => x.Name == "Tool");
		var toolEnumerableClass = typeof(IEnumerable<>).MakeGenericType(toolClass);
		var factoryToolsFunction = factoryClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.ReturnType == toolEnumerableClass);
		var factoryInstructionLenFunction = factoryClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.ReturnType == typeof(int) && x.Name != "GetHashCode");
		var solutionClass = gameLogicType.Assembly.GetTypes().Single(x => x.Name == "Solution");
		var maybeClass = gameLogicType.Assembly.GetTypes().Single(x => x.Name == "Maybe`1");
		var maybeSolutionClass = maybeClass.MakeGenericType(solutionClass);
		var maybeIntClass = maybeClass.MakeGenericType(typeof(int));
		var maybeIntIsSomeFunction = maybeIntClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.ReturnType == typeof(bool) && x.GetParameters().Length == 0);
		var maybeIntUnwrapFunction = maybeIntClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.ReturnType == typeof(int) && x.GetParameters().Length == 0 && x.Name != "GetHashCode");
		var maybeSolutionIsSomeFunction = maybeSolutionClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.ReturnType == typeof(bool) && x.GetParameters().Length == 0);
		var maybeSolutionUnwrapFunction = maybeSolutionClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.ReturnType == solutionClass && x.GetParameters().Length == 0);

		var simClass = gameLogicType.Assembly.GetTypes().Single(x => x.Name == "Sim");
		var simAnimationClass = gameLogicType.Assembly.GetTypes().Single(x => x.Name == "SimAnimation");
		var simulationRunFunction = simClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.ReturnType == simAnimationClass.MakeArrayType());
		var simulationFinishedField = simClass.GetFields(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.FieldType == maybeIntClass);
		var simulationHasErrorsFunction = simClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.ReturnType == typeof(bool) && x.GetParameters().Length == 0);
		var range2Class = gameLogicType.Assembly.GetTypes().Single(x => x.Name == "Range2");
		var simulationUsedAreaField = simClass.GetFields(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.FieldType == range2Class);

		var solutionFromFileBytesFunction = solutionClass.GetMethods(BindingFlags.Public | BindingFlags.Static)
			.Single(x => x.ReturnType == maybeClass.MakeGenericType(solutionClass));
		var fileBytesClass = solutionFromFileBytesFunction.GetParameters().Single().ParameterType;
		var solutionPuzzleField = solutionClass.GetFields(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.FieldType == puzzleClass);
		var solutionFactoryField = solutionClass.GetFields(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.FieldType == factoryClass);
		var texturePathHelperClass = gameLogicType.Assembly.GetTypes().Single(x =>
			x.IsStatic() && x.GetMethods(BindingFlags.Public | BindingFlags.Static).All(y => y.ReturnType.IsClass) &&
			x.GetMethods(BindingFlags.Public | BindingFlags.Static).DistinctBy(y => y.ReturnType).Count() ==
			x.GetMethods(BindingFlags.Public | BindingFlags.Static).Length &&
			x.GetMethods(BindingFlags.Public | BindingFlags.Static).Length == 5);

		var texturePathHelperClassMethodReturnTypes = texturePathHelperClass
			.GetMethods(BindingFlags.Public | BindingFlags.Static).Select(x => x.ReturnType).ToArray();
		var initGameTexturePathsClass = texturePathHelperClassMethodReturnTypes.Single(x =>
			x.GetFields(BindingFlags.Public | BindingFlags.Instance).Any(y => y.FieldType.Name == "Texture"));
		var initGameTexturePathsInstanceFunction = texturePathHelperClass
			.GetMethods(BindingFlags.Public | BindingFlags.Static)
			.Single(x => x.ReturnType == initGameTexturePathsClass);
		var initMainGameTexturePathsFunction =
			initGameTexturePathsClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
				.Where(x => x.ReturnType == typeof(void))
				.OrderByDescending(x => x.GetMethodBody()!.GetILAsByteArray()!.Length)
				.First(); // The function is a chonker.
		var textureLoaderClass = gameLogicType.Assembly.GetTypes().Single(x => x.Name == "TextureLoader");
		var loadTexturesNoCallbacksFunction = textureLoaderClass.GetMethods(BindingFlags.Public | BindingFlags.Static)
			.Single(x => x.ReturnType == typeof(bool) && x.GetParameters().Length == 0);

		var bounds2Class = gameLogicType.Assembly.GetTypes().Single(x => x.Name == "Bounds2");
		var textureHelperClass = gameLogicType.Assembly.GetTypes().Single(x =>
			x.IsStatic() && x.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).Any(y =>
				y.ReturnType == typeof(bool) && y.GetParameters().Length == 2 &&
				y.GetParameters().All(z => z.ParameterType == bounds2Class)));
		var textureHelperFunction = textureHelperClass.GetMethods(BindingFlags.Public | BindingFlags.Static)
			.Single(x => x.ReturnType == typeof(void) && x.GetParameters().Length == 1 &&
			             x.GetParameters()[0].ParameterType.IsEnum && x.GetMethodBody()!.MaxStackSize == 2);

		var toolCostFunction = toolClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.ReturnType == typeof(int) && x.Name != "GetHashCode");

		var range2SizeProperty = range2Class.GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.Single(x => x.Name == "Size");

		var index2Class = gameLogicType.Assembly.GetTypes().Single(x => x.Name == "Index2");
		var index2X = index2Class.GetFields(BindingFlags.Public | BindingFlags.Instance).Single(x => x.Name == "X");
		var index2Y = index2Class.GetFields(BindingFlags.Public | BindingFlags.Instance).Single(x => x.Name == "Y");

		_mappedFunctions = new Dictionary<MappedFunction, MethodInfo>
		{
			[MappedFunction.FactoryToolsFunction] = factoryToolsFunction,
			[MappedFunction.FactoryInstructionLenFunction] = factoryInstructionLenFunction,
			[MappedFunction.FontLoaderHelperFunction] = fontLoaderHelperFunction,
			[MappedFunction.GameLogicInitializeFontsFunction] = gameLogicInitializeFontsFunction,
			[MappedFunction.GameLogicInitializePuzzlesFunction] = gameLogicInitializePuzzlesFunction,
			[MappedFunction.MaybeIntIsSomeFunction] = maybeIntIsSomeFunction,
			[MappedFunction.MaybeIntUnwrapFunction] = maybeIntUnwrapFunction,
			[MappedFunction.MaybeSolutionIsSomeFunction] = maybeSolutionIsSomeFunction,
			[MappedFunction.MaybeSolutionUnwrapFunction] = maybeSolutionUnwrapFunction,
			[MappedFunction.SimulationRunFunction] = simulationRunFunction,
			[MappedFunction.SimulationHasErrorsFunction] = simulationHasErrorsFunction,
			[MappedFunction.SolutionFromFileBytesFunction] = solutionFromFileBytesFunction,
			[MappedFunction.InitGameTexturePathsInstanceFunction] = initGameTexturePathsInstanceFunction,
			[MappedFunction.InitMainGameTexturePathsFunction] = initMainGameTexturePathsFunction,
			[MappedFunction.LoadTexturesNoCallbacksFunction] = loadTexturesNoCallbacksFunction,
			[MappedFunction.TextureHelperFunction] = textureHelperFunction,
			[MappedFunction.ToolCostFunction] = toolCostFunction,
		};

		_mappedFields = new Dictionary<MappedField, FieldInfo>
		{
			[MappedField.GameLogicStaticInstanceField] = gameLogicStaticInstanceField,
			[MappedField.GameLogicPlatformField] = rendererTypeField,
			[MappedField.SimulationFinishedField] = simulationFinishedField,
			[MappedField.SimulationUsedAreaField] = simulationUsedAreaField,
			[MappedField.SolutionPuzzleField] = solutionPuzzleField,
			[MappedField.SolutionFactoryField] = solutionFactoryField,
			[MappedField.PuzzleIdField] = puzzleIdField,
			[MappedField.Index2X] = index2X,
			[MappedField.Index2Y] = index2Y,
		};

		_mappedTypes = new Dictionary<MappedClass, Type>
		{
			[MappedClass.FileBytesClass] = fileBytesClass,
			[MappedClass.FontLoaderHelperClass] = fontLoaderHelperClass,
			[MappedClass.TexturePathHelperClass] = texturePathHelperClass,
			[MappedClass.InitGameTexturePathsClass] = initGameTexturePathsClass,
			[MappedClass.TextureHelperClass] = textureHelperClass,
			[MappedClass.FactoryClass] = factoryClass,
			[MappedClass.SolutionClass] = solutionClass,
			[MappedClass.SimClass] = simClass,
			[MappedClass.Range2Class] = range2Class,
			[MappedClass.Index2Class] = index2Class,
			[MappedClass.Bounds2Class] = bounds2Class,
			[MappedClass.ToolClass] = toolClass,
			[MappedClass.MaybeGenericClass] = maybeClass,
			[MappedClass.MaybeSolutionClass] = maybeSolutionClass,
			[MappedClass.PuzzleClass] = puzzleClass,
			[MappedClass.GameLogicClass] = gameLogicType,
			[MappedClass.MaybeIntClass] = maybeIntClass,
			[MappedClass.TextureLoader] = textureLoaderClass,
		};

		_mappedProperties = new Dictionary<MappedProperty, PropertyInfo>
		{
			[MappedProperty.Range2Size] = range2SizeProperty,
		};

		VerifyAllMembersMapped();
	}

#pragma warning disable CA2201
	private static void VerifyAllMembersMapped()
	{
		foreach (var mappedFunction in Enum.GetValues<MappedFunction>())
		{
			if (!_mappedFunctions!.ContainsKey(mappedFunction))
			{
				throw new Exception($"Mapped function {mappedFunction} is not mapped.");
			}
		}

		foreach (var mappedField in Enum.GetValues<MappedField>())
		{
			if (!_mappedFields!.ContainsKey(mappedField))
			{
				throw new Exception($"Mapped field {mappedField} is not mapped.");
			}
		}

		foreach (var mappedClass in Enum.GetValues<MappedClass>())
		{
			if (!_mappedTypes!.ContainsKey(mappedClass))
			{
				throw new Exception($"Mapped class {mappedClass} is not mapped.");
			}
		}

		foreach (var mappedProperty in Enum.GetValues<MappedProperty>())
		{
			if (!_mappedProperties!.ContainsKey(mappedProperty))
			{
				throw new Exception($"Mapped property {mappedProperty} is not mapped.");
			}
		}
	}
#pragma warning restore CA2201
}
