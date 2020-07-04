using Athonet.Api.Test.Config;
using Divergic.Logging.Xunit;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Security;
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

			var options = new AthonetClientOptions
			{
				Username = config.Username,
				Password = config.Password,
				Certificate = new X509Certificate2(config.CertificateFile, config.CertificatePassword),
				HssPcrfHaHostname = config.HssPcrfHaHostname,
				IgnoreSslCertificateErrors = true
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
