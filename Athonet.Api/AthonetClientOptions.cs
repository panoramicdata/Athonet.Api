using Athonet.Api.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace Athonet.Api
{
	/// <summary>
	/// Information required to connect to the Athonet API
	/// </summary>
	public class AthonetClientOptions
	{
		/// <summary>
		/// Username
		/// </summary>
		public string? Username { get; set; }

		/// <summary>
		/// Password
		/// </summary>
		public string? Password { get; set; }

		/// <summary>
		/// Certificate
		/// </summary>
		public X509Certificate2? Certificate { get; set; }

		/// <summary>
		/// The HSS/PCRF HA hostname
		/// </summary>
		public string? HssPcrfHaHostname { get; set; }

		/// <summary>
		/// Whether to ignore SSL certificate errors
		/// </summary>
		public bool IgnoreSslCertificateErrors { get; set; }

		/// <summary>
		/// Validate the options
		/// </summary>
		public void Validate()
		{
			if (string.IsNullOrWhiteSpace(Username))
			{
				throw new ConfigurationException("Missing Username");
			}

			if (string.IsNullOrWhiteSpace(Password))
			{
				throw new ConfigurationException("Missing Password");
			}

			if (Certificate is null)
			{
				throw new ConfigurationException("Missing Certificate");
			}
		}
	}
}