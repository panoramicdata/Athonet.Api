using Microsoft.Extensions.Logging;
using System.Threading;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Athonet.Api.Test;

public class BaseTest : TestBed<Fixture>
{
	public BaseTest(ITestOutputHelper testOutputHelper, Fixture fixture) : base(testOutputHelper, fixture)
	{
		var loggerFactory = fixture.GetService<ILoggerFactory>(testOutputHelper)
			?? throw new InvalidOperationException("LoggerFactory is null");

		Logger = loggerFactory.CreateLogger(GetType());

		// Load config
		var config = JsonSerializer.Deserialize<TestConfiguration>(
			File.ReadAllText("../../../appsettings.json"),
			new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
			?? throw new InvalidOperationException("Failed to deserialize test configuration");
		var credentials = config.Credentials.Single(c => c.CredentialId == config.ActiveCredentialId);

		var options = new AthonetClientOptions
		{
			Username = credentials.Username,
			Password = credentials.Password,
			Certificate = X509CertificateLoader.LoadPkcs12FromFile(credentials.CertificateFile, credentials.CertificatePassword),
			Hostname = credentials.Hostname,
			Port = credentials.Port,
			IgnoreSslCertificateErrors = true,
			UserAgent = "Athonet.Api-Unit-Test",
			StoreLastRequestAndResponse = true
		};
		options.Validate();

		// Create client
		Client = new AthonetClient(options, Logger);
	}

	protected static CancellationToken CancellationToken => TestContext.Current.CancellationToken;

	protected AthonetClient Client { get; set; }

	protected ILogger Logger { get; }
}
