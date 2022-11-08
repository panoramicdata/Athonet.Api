namespace Athonet.Api.Test.Config;

internal class TestConfiguration
{
	public string ActiveCredentialId { get; set; }
	public TestCredential[] Credentials { get; set; }
}

internal class TestCredential
{
	public string CredentialId { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public string CertificateFile { get; set; }
	public string Hostname { get; set; }
	public int Port { get; set; } = 446;
	public string CertificatePassword { get; set; }
}
