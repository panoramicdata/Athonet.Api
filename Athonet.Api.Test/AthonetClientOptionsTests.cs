using Athonet.Api.Exceptions;

namespace Athonet.Api.Test;

public class AthonetClientOptionsTests
{
#pragma warning disable SYSLIB0026
	private static AthonetClientOptions ValidOptions() => new()
	{
		Username = "user",
		Password = "pass",
		Certificate = new X509Certificate2(),
	};
#pragma warning restore SYSLIB0026

	[Fact]
	public void Defaults_AreAsDocumented()
	{
		var options = new AthonetClientOptions();

		_ = options.Port.Should().Be(446);
		_ = options.IgnoreSslCertificateErrors.Should().BeFalse();
		_ = options.StoreLastRequestAndResponse.Should().BeFalse();
		_ = options.UserAgent.Should().Be("Athonet.Api-nuget-package");
		_ = options.Username.Should().BeNull();
		_ = options.Password.Should().BeNull();
		_ = options.Certificate.Should().BeNull();
		_ = options.Hostname.Should().BeNull();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("   ")]
	public void Validate_MissingUsername_ThrowsConfigurationException(string? username)
	{
		var options = ValidOptions();
		options.Username = username;

		var exception = Record.Exception(options.Validate);

		_ = exception.Should().BeOfType<ConfigurationException>();
		_ = exception!.Message.Should().Contain("Username");
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("   ")]
	public void Validate_MissingPassword_ThrowsConfigurationException(string? password)
	{
		var options = ValidOptions();
		options.Password = password;

		var exception = Record.Exception(options.Validate);

		_ = exception.Should().BeOfType<ConfigurationException>();
		_ = exception!.Message.Should().Contain("Password");
	}

	[Fact]
	public void Validate_MissingCertificate_ThrowsConfigurationException()
	{
		var options = ValidOptions();
		options.Certificate = null;

		var exception = Record.Exception(options.Validate);

		_ = exception.Should().BeOfType<ConfigurationException>();
		_ = exception!.Message.Should().Contain("Certificate");
	}

	[Fact]
	public void Validate_AllPresent_DoesNotThrow()
	{
		var options = ValidOptions();

		var exception = Record.Exception(options.Validate);

		_ = exception.Should().BeNull();
	}
}
