using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Athonet.Api.Exceptions;

namespace Athonet.Api.Test;

public class AthonetClientTests
{
	private static AthonetClientOptions Options()
	{
#pragma warning disable SYSLIB0026
		return new AthonetClientOptions
		{
			Username = "user",
			Password = "pass",
			Certificate = new X509Certificate2(),
			Hostname = "example.invalid",
			Port = 443,
			UserAgent = "test-agent",
			IgnoreSslCertificateErrors = true,
			StoreLastRequestAndResponse = true
		};
#pragma warning restore SYSLIB0026
	}

	[Fact]
	public void Constructor_NullOptions_ThrowsArgumentNullException()
	{
		var exception = Record.Exception(() => new AthonetClient((AthonetClientOptions)null!));

		_ = exception.Should().BeOfType<ArgumentNullException>();
	}

	[Theory]
	[InlineData(false, true, true)]
	[InlineData(true, false, true)]
	[InlineData(true, true, false)]
	public void Constructor_InvalidOptions_ThrowsConfigurationException(bool withUsername, bool withPassword, bool withCertificate)
	{
		var options = Options();
		if (!withUsername) { options.Username = null; }
		if (!withPassword) { options.Password = null; }
		if (!withCertificate) { options.Certificate = null; }

		var exception = Record.Exception(() => new AthonetClient(options));

		_ = exception.Should().BeOfType<ConfigurationException>();
	}

	[Fact]
	public void Constructor_ValidOptions_PopulatesInterfaces()
	{
		using var client = new AthonetClient(Options());

		_ = client.Hss.Should().NotBeNull();
		_ = client.Mogw.Should().NotBeNull();
		_ = client.LastHttpRequest.Should().BeNull();
		_ = client.LastHttpResponse.Should().BeNull();
	}

	[Fact]
	public void Constructor_ValidOptions_WithLogger_PopulatesInterfaces()
	{
		using var client = new AthonetClient(Options(), new NullLogger<AthonetClient>());

		_ = client.Hss.Should().NotBeNull();
		_ = client.Mogw.Should().NotBeNull();
	}

	[Fact]
	public void Dispose_IsIdempotent()
	{
		var client = new AthonetClient(Options());
		client.Dispose();
		client.Dispose();

		_ = true.Should().BeTrue();
	}
}
