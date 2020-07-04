using System.Security;

namespace Athonet.Api.Test.Config
{
	internal class TestConfiguration
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string CertificateFile { get; set; }
		public string HssPcrfHaHostname { get; set; }
		public string CertificatePassword { get; set; }
	}
}
