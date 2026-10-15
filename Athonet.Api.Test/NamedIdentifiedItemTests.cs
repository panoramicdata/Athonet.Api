using System.Text.Json;

namespace Athonet.Api.Test;

public class NamedIdentifiedItemTests
{
	[Fact]
	public void Serialisation_RoundTripsBothProperties()
	{
		var profile = new UsimProfile { Id = 7, Name = "p1" };

		var json = JsonSerializer.Serialize(profile);
		var deserialized = JsonSerializer.Deserialize<UsimProfile>(json)!;

		_ = deserialized.Id.Should().Be(7);
		_ = deserialized.Name.Should().Be("p1");
	}
}
