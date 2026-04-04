namespace Athonet.Api.Test.Config;

internal class TestConfiguration
{
	public required string ActiveCredentialId { get; set; }
	public required TestCredential[] Credentials { get; set; }
}

internal class TestCredential
{
	public required string CredentialId { get; set; }
	public required string Username { get; set; }
	public required string Password { get; set; }
	public required string CertificateFile { get; set; }
	public required string Hostname { get; set; }
	public int Port { get; set; } = 446;
	public required string CertificatePassword { get; set; }
}
