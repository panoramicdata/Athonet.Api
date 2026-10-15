using System.Text.Json;

namespace Athonet.Api.Test;

public class EventTests
{
	[Fact]
	public void Defaults_AreDocumentedValues()
	{
		var evt = new Event();

		_ = evt.Layer.Should().Be(EventLayer.Unknown);
		_ = evt.Type.Should().Be(EventType.Unknown);
		_ = evt.UnixTimestamp.Should().Be(0);
		_ = evt.UnixTimestampMs.Should().Be(0);
		_ = evt.Id.Should().Be(0);
		_ = evt.EventDetails.Should().NotBeNull();
		_ = evt.Process.Should().BeEmpty();
		_ = evt.EventMessage.Should().BeNull();
	}

	[Fact]
	public void Serialisation_RoundTripsScalarAndObjectProperties()
	{
		var evt = new Event
		{
			Layer = EventLayer.NetworkAcessStratumLayer,
			Type = EventType.Attach,
			UnixTimestamp = 1700000000,
			UnixTimestampMs = 1_700_000_000_500,
			Id = 42,
			EventDetails = new EventDetails { Proc = "p" },
			Process = "proc",
			EventMessage = "msg"
		};

		var json = JsonSerializer.Serialize(evt);
		var deserialized = JsonSerializer.Deserialize<Event>(json)!;

		_ = deserialized.Layer.Should().Be(EventLayer.NetworkAcessStratumLayer);
		_ = deserialized.Type.Should().Be(EventType.Attach);
		_ = deserialized.UnixTimestamp.Should().Be(1700000000);
		_ = deserialized.UnixTimestampMs.Should().Be(1_700_000_000_500);
		_ = deserialized.Id.Should().Be(42);
		_ = deserialized.EventDetails.Should().NotBeNull();
		_ = deserialized.EventDetails!.Proc.Should().Be("p");
		_ = deserialized.Process.Should().Be("proc");
		_ = deserialized.EventMessage.Should().Be("msg");
	}
}
