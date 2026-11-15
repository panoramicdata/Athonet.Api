using System.Text.Json;

namespace Athonet.Api.Test;

public class NamedIdentifiedItemTests
{
	[Fact]
	public void Serialisation_RoundTripsBothProperties()
	{
		var item = new ClosedSubscriberGroup { Id = 7, Name = "p1" };

		var json = JsonSerializer.Serialize(item);
		var deserialized = JsonSerializer.Deserialize<ClosedSubscriberGroup>(json)!;

		_ = deserialized.Id.Should().Be(7);
		_ = deserialized.Name.Should().Be("p1");
	}
}
