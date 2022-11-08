namespace Athonet.Api.Test;

public class HssTests : BaseTest
{
	public HssTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
	}

	[Fact]
	public async Task GetUsimProfiles_Succeeds()
	{
		// Get all
		var usimProfiles = await Client
			.Hss
			.GetUsimProfilesAsync()
			.ConfigureAwait(false);

		usimProfiles.Should().BeOfType<Page<UsimProfile>>();
		usimProfiles.Should().NotBeNull();

		// Get individual
		var usimProfile = await Client
			.Hss
			.GetUsimProfileAsync(usimProfiles.Results[0].Id)
			.ConfigureAwait(false);

		usimProfile.Should().BeOfType<UsimProfile>();
		usimProfile.Should().NotBeNull();
	}

	[Fact]
	public async Task GetApnProfilesByUsimProfileId_Succeeds()
	{
		var defaultUsimProfileId = await GetDefaultUsimProfileIdAsync()
			.ConfigureAwait(false);

		// Get all
		var apnProfiles = await Client
			.Hss
			.GetApnProfilesByUsimProfileIdAsync(defaultUsimProfileId)
			.ConfigureAwait(false);

		apnProfiles.Should().BeOfType<Page<ApnProfile>>();
		apnProfiles.Should().NotBeNull();
	}

	[Fact]
	public async Task GetPublicLandMobileNetworks_Succeeds()
	{
		var defaultUsimProfileId = await GetDefaultUsimProfileIdAsync()
			.ConfigureAwait(false);

		// Get all
		var plmns = await Client
			.Hss
			.GetPublicLandMobileNetworksAsync(defaultUsimProfileId)
			.ConfigureAwait(false);

		plmns.Should().BeOfType<Page<PublicLandMobileNetwork>>();
		plmns.Should().NotBeNull();
	}

	[Fact]
	public async Task GetClosedSubscriberGroups_Succeeds()
	{
		var defaultUsimProfileId = await GetDefaultUsimProfileIdAsync()
			.ConfigureAwait(false);

		// Get all
		var csgs = await Client
			.Hss
			.GetClosedSubscriberGroupsAsync(defaultUsimProfileId)
			.ConfigureAwait(false);

		csgs.Should().BeOfType<Page<ClosedSubscriberGroup>>();
		csgs.Should().NotBeNull();
	}

	[Fact]
	public async Task GetTeleservices_Succeeds()
	{
		var defaultUsimProfileId = await GetDefaultUsimProfileIdAsync()
			.ConfigureAwait(false);

		// Get all
		var teleservices = await Client
			.Hss
			.GetTeleservicesAsync(defaultUsimProfileId)
			.ConfigureAwait(false);

		teleservices.Should().BeOfType<Page<Teleservice>>();
		teleservices.Should().NotBeNull();
	}

	[Fact]
	public async Task GetApns_Succeeds()
	{
		// Get all
		var apns = await Client
			.Hss
			.GetApnsAsync()
			.ConfigureAwait(false);

		apns.Should().BeOfType<Page<Apn>>();
		apns.Should().NotBeNull();

		// Get individual
		var apn = await Client
			.Hss
			.GetApnAsync(apns.Results[0].Id)
			.ConfigureAwait(false);

		apn.Should().BeOfType<Apn>();
		apn.Should().NotBeNull();
	}

	[Fact]
	public async Task GetApnProfiles_Succeeds()
	{
		// Get all
		var apnProfiles = await Client
			.Hss
			.GetApnProfilesAsync()
			.ConfigureAwait(false);

		apnProfiles.Should().BeOfType<Page<ApnProfile>>();
		apnProfiles.Should().NotBeNull();

		// Get individual
		var apnProfile = await Client
			.Hss
			.GetApnProfileAsync(apnProfiles.Results[0].Id)
			.ConfigureAwait(false);

		apnProfile.Should().BeOfType<ApnProfile>();
		apnProfile.Should().NotBeNull();
	}

	private async Task<int> GetDefaultUsimProfileIdAsync()
	{
		var usimProfiles = await Client
		.Hss
		.GetUsimProfilesAsync()
		.ConfigureAwait(false);
		return
			usimProfiles.Results.FirstOrDefault(usp => usp.Default)?.Id
			?? throw new InvalidOperationException("No UsimProfile is set default.");
	}
}
