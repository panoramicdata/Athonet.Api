using System.Text.Json;

namespace Athonet.Api.Test;

public class UsimProfileTests
{
	[Fact]
	public void Serialisation_RoundTripsAllProperties()
	{
		var profile = new UsimProfile
		{
			Id = 7,
			Name = "profile",
			UeAmbrUplink = 100,
			UeAmbrDownlink = 200,
			Default = true,
			RoamingAllowed = 1,
			SubscriptionDataFlags = 3,
			ChargingCharacteristics = 9,
			S6aNam = 3,
			S6dgrNam = 2,
			RegionalSubscriptionsProfile = new { Area = "EU" }
		};

		var json = JsonSerializer.Serialize(profile);
		var deserialized = JsonSerializer.Deserialize<UsimProfile>(json)!;

		_ = deserialized.Id.Should().Be(7);
		_ = deserialized.Name.Should().Be("profile");
		_ = deserialized.UeAmbrUplink.Should().Be(100);
		_ = deserialized.UeAmbrDownlink.Should().Be(200);
		_ = deserialized.Default.Should().BeTrue();
		_ = deserialized.RoamingAllowed.Should().Be(1);
		_ = deserialized.SubscriptionDataFlags.Should().Be(3);
		_ = deserialized.ChargingCharacteristics.Should().Be(9);
		_ = deserialized.S6aNam.Should().Be(3);
		_ = deserialized.S6dgrNam.Should().Be(2);
		_ = deserialized.RegionalSubscriptionsProfile.Should().NotBeNull();
	}
}
