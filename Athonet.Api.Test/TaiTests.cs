namespace Athonet.Api.Test;

public class TaiTests
{
	[Fact]
	public void String_Succeeds()
		=> AssertTaiIsParsed("tac-lb83.tac-hb00.tac.epc.mnc340.mcc311.3gppnetwork.org");

	[Fact]
	public void Tai_Succeeds()
		=> AssertTaiIsParsed(new Tai
		{
			Plmn = "311340",
			Tac = 131
		});

	[Fact]
	public void JObject_Succeeds()
		=> AssertTaiIsParsed(JsonDocument.Parse("{ \"plmn\": \"311340\", \"tac\": 131 }").RootElement);

	private static void AssertTaiIsParsed(object taiRaw)
	{
		var evt = new EventDetails
		{
			TaiRaw = taiRaw
		};

		_ = evt.Tai.Should().BeOfType<Tai>();
		_ = evt.Tai.Plmn.Should().Be("311340");
		_ = evt.Tai.Tac.Should().Be(131);
	}
}
