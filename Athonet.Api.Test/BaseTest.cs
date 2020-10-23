using Athonet.Api.Test.Config;
using Divergic.Logging.Xunit;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Xunit.Abstractions;

namespace Athonet.Api.Test
{
	public class BaseTest
	{
		public BaseTest(ITestOutputHelper testOutputHelper)
		{
			// Create logger
			Logger = testOutputHelper.BuildLogger();

			// Load config
			var config = JsonConvert.DeserializeObject<TestConfiguration>(File.ReadAllText("../../../appsettings.json"));
			var credentials = config.Credentials.Single(c => c.CredentialId == config.ActiveCredentialId);

			var options = new AthonetClientOptions
			{
				Username = credentials.Username,
				Password = credentials.Password,
				Certificate = new X509Certificate2(credentials.CertificateFile, credentials.CertificatePassword),
				Hostname = credentials.Hostname,
				Port = credentials.Port,
				IgnoreSslCertificateErrors = true,
				UserAgent = "Athonet.Api-Unit-Test",
				StoreLastRequestAndResponse = true
			};
			options.Validate();

			// Create client
			Client = new AthonetClient(options,
			Logger);
		}

		protected AthonetClient Client { get; set; }
		protected ICacheLogger Logger { get; }
	}
}
