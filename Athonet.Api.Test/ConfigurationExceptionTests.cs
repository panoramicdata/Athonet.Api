namespace Athonet.Api.Test;

public class ConfigurationExceptionTests
{
	[Fact]
	public void MessageConstructor_SetsMessage()
	{
		var exception = new Athonet.Api.Exceptions.ConfigurationException("some message");

		_ = exception.Message.Should().Be("some message");
		_ = exception.InnerException.Should().BeNull();
	}

	[Fact]
	public void MessageAndInnerConstructor_SetsBoth()
	{
		var inner = new InvalidOperationException("inner");
		var exception = new Athonet.Api.Exceptions.ConfigurationException("outer", inner);

		_ = exception.Message.Should().Be("outer");
		_ = exception.InnerException.Should().BeSameAs(inner);
	}
}
