using System.Net.Http;
using System.Text;

namespace Athonet.Api.Test;

public class EventDetailsTests
{
	[Fact]
	public void Tai_WhenTaiRawIsNull_ReturnsNull()
	{
		var details = new EventDetails { TaiRaw = null };

		_ = details.Tai.Should().BeNull();
	}

	[Fact]
	public void Tai_WhenTaiRawIsTai_ReturnsSameInstance()
	{
		var tai = new Tai { Plmn = "311340", Tac = 42 };
		var details = new EventDetails { TaiRaw = tai };

		_ = details.Tai.Should().BeSameAs(tai);
	}

	[Fact]
	public void Tai_WhenTaiRawIsJsonElement_ParsesTai()
	{
		var jsonElement = JsonDocument.Parse("""{"plmn":"311340","tac":42}""").RootElement;
		var details = new EventDetails { TaiRaw = jsonElement };

		_ = details.Tai.Should().NotBeNull();
		_ = details.Tai!.Plmn.Should().Be("311340");
		_ = details.Tai.Tac.Should().Be(42);
	}

	[Fact]
	public void Tai_WhenTaiRawIsMatchingString_ParsesTai()
	{
		var details = new EventDetails { TaiRaw = "tac-lb83.tac-hb00.tac.epc.mnc340.mcc311.3gppnetwork.org" };

		_ = details.Tai.Should().NotBeNull();
		_ = details.Tai!.Plmn.Should().Be("311340");
		_ = details.Tai.Tac.Should().Be(0x0083);
	}

	[Fact]
	public void Tai_WhenTaiRawIsNonMatchingString_ThrowsFormatException()
	{
		var details = new EventDetails { TaiRaw = "nonsense" };

		var exception = Record.Exception(() => _ = details.Tai);

		_ = exception.Should().BeOfType<FormatException>();
	}

	[Fact]
	public void Tai_WhenTaiRawIsUnsupported_ThrowsJsonException()
	{
		var details = new EventDetails { TaiRaw = 12345 };

		var exception = Record.Exception(() => _ = details.Tai);

		_ = exception.Should().BeOfType<JsonException>();
	}

	[Fact]
	public void Serialisation_RoundTripsScalarProperties()
	{
		var details = new EventDetails
		{
			Layer = EventLayer.GTP,
			Proc = "proc1",
			Type = EventType.Attach,
			Ip = "10.0.0.1",
			UnixTimestamp = 1700000000,
			ENodeBName = "enodeb1",
			Cause = "cause1",
			Imsi = "123456789012345",
			BearerId = "42",
			Apn = "apn1",
			Imei = "352099001761481",
			Msisdn = "+15551234567",
			Rat = "eUTRAN",
			Srv = "srv1",
			Username = "user1",
			MmeHostname = "mme1",
			MmeRealMName = "realm1",
			Interface = "if1"
		};

		var json = JsonSerializer.Serialize(details);
		var deserialized = JsonSerializer.Deserialize<EventDetails>(json)!;

		_ = deserialized.Layer.Should().Be(EventLayer.GTP);
		_ = deserialized.Proc.Should().Be("proc1");
		_ = deserialized.Type.Should().Be(EventType.Attach);
		_ = deserialized.Ip!.ToString().Should().Be("10.0.0.1");
		_ = deserialized.UnixTimestamp.Should().Be(1700000000);
		_ = deserialized.ENodeBName.Should().Be("enodeb1");
		_ = deserialized.Cause.Should().Be("cause1");
		_ = deserialized.Imsi.Should().Be("123456789012345");
		_ = deserialized.BearerId.Should().Be("42");
		_ = deserialized.Apn.Should().Be("apn1");
		_ = deserialized.Imei.Should().Be("352099001761481");
		_ = deserialized.Msisdn.Should().Be("+15551234567");
		_ = deserialized.Rat.Should().Be("eUTRAN");
		_ = deserialized.Srv.Should().Be("srv1");
		_ = deserialized.Username.Should().Be("user1");
		_ = deserialized.MmeHostname.Should().Be("mme1");
		_ = deserialized.MmeRealMName.Should().Be("realm1");
		_ = deserialized.Interface.Should().Be("if1");
	}

	[Fact]
	public void Serialisation_RoundTripsListAndObjectProperties()
	{
		var details = new EventDetails
		{
			GlobalENodeBId = new GlobalENodeBId { Plmn = "311340", HomeENodeBId = 7 },
			Ecgi = new Ecgi { Plmn = "311340", Cellid = 9 },
			PgwIp = new List<string> { "10.0.0.1", "10.0.0.2" },
			UserAddr = new List<string> { "192.168.0.1" },
			UnixTimestampMs = 1_700_000_000_123
		};

		var json = JsonSerializer.Serialize(details);
		var deserialized = JsonSerializer.Deserialize<EventDetails>(json)!;

		_ = deserialized.GlobalENodeBId.Should().NotBeNull();
		_ = deserialized.GlobalENodeBId!.Plmn.Should().Be("311340");
		_ = deserialized.GlobalENodeBId.HomeENodeBId.Should().Be(7);
		_ = deserialized.Ecgi.Should().NotBeNull();
		_ = deserialized.Ecgi!.Plmn.Should().Be("311340");
		_ = deserialized.Ecgi.Cellid.Should().Be(9);
		_ = deserialized.PgwIp.Should().BeEquivalentTo(new[] { "10.0.0.1", "10.0.0.2" });
		_ = deserialized.UserAddr.Should().BeEquivalentTo(new[] { "192.168.0.1" });
		_ = deserialized.UnixTimestampMs.Should().Be(1_700_000_000_123);
	}
}
