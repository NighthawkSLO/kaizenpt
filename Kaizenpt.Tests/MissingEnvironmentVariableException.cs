namespace Kaizenpt.Tests;

internal sealed class MissingEnvironmentVariableException : Exception
{
	public MissingEnvironmentVariableException() { }

	public MissingEnvironmentVariableException(string? message)
		: base(message) { }

	public MissingEnvironmentVariableException(string? message, Exception? innerException)
		: base(message, innerException) { }
}
