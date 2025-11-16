using System.Threading;

namespace Athonet.Api.Test;

public class HssTests(ITestOutputHelper testOutputHelper) : BaseTest(testOutputHelper)
{
	[Fact]
	public async Task GetUsimProfiles_Succeeds()
	{
		// Get all
		var usimProfiles = await Client
			.Hss
			.GetUsimProfilesAsync(CancellationToken);

		_ = usimProfiles.Should().BeOfType<Page<UsimProfile>>();
		_ = usimProfiles.Should().NotBeNull();

		// Get individual
		var usimProfile = await Client
			.Hss
			.GetUsimProfileAsync(usimProfiles.Results[0].Id, CancellationToken);

		_ = usimProfile.Should().BeOfType<UsimProfile>();
		_ = usimProfile.Should().NotBeNull();
	}

	[Fact]
	public async Task GetApnProfilesByUsimProfileId_Succeeds()
	{
		var defaultUsimProfileId = await GetDefaultUsimProfileIdAsync(CancellationToken);

		// Get all
		var apnProfiles = await Client
			.Hss
			.GetApnProfilesByUsimProfileIdAsync(defaultUsimProfileId, CancellationToken);

		_ = apnProfiles.Should().BeOfType<Page<ApnProfile>>();
		_ = apnProfiles.Should().NotBeNull();
	}

	[Fact]
	public async Task GetPublicLandMobileNetworks_Succeeds()
	{
		var defaultUsimProfileId = await GetDefaultUsimProfileIdAsync(CancellationToken);

		// Get all
		var plmns = await Client
			.Hss
			.GetPublicLandMobileNetworksAsync(defaultUsimProfileId, CancellationToken);

		_ = plmns.Should().BeOfType<Page<PublicLandMobileNetwork>>();
		_ = plmns.Should().NotBeNull();
	}

	[Fact]
	public async Task GetClosedSubscriberGroups_Succeeds()
	{
		var defaultUsimProfileId = await GetDefaultUsimProfileIdAsync(CancellationToken);

		// Get all
		var csgs = await Client
			.Hss
			.GetClosedSubscriberGroupsAsync(defaultUsimProfileId, CancellationToken);

		_ = csgs.Should().BeOfType<Page<ClosedSubscriberGroup>>();
		_ = csgs.Should().NotBeNull();
	}

	[Fact]
	public async Task GetTeleservices_Succeeds()
	{
		var defaultUsimProfileId = await GetDefaultUsimProfileIdAsync(CancellationToken);

		// Get all
		var teleservices = await Client
			.Hss
			.GetTeleservicesAsync(defaultUsimProfileId, CancellationToken);

		_ = teleservices.Should().BeOfType<Page<Teleservice>>();
		_ = teleservices.Should().NotBeNull();
	}

	[Fact]
	public async Task GetApns_Succeeds()
	{
		// Get all
		var apns = await Client
			.Hss
			.GetApnsAsync(CancellationToken);

		_ = apns.Should().BeOfType<Page<Apn>>();
		_ = apns.Should().NotBeNull();

		// Get individual
		var apn = await Client
			.Hss
			.GetApnAsync(apns.Results[0].Id, CancellationToken);

		_ = apn.Should().BeOfType<Apn>();
		_ = apn.Should().NotBeNull();
	}

	[Fact]
	public async Task GetApnProfiles_Succeeds()
	{
		// Get all
		var apnProfiles = await Client
			.Hss
			.GetApnProfilesAsync(CancellationToken);

		_ = apnProfiles.Should().BeOfType<Page<ApnProfile>>();
		_ = apnProfiles.Should().NotBeNull();

		// Get individual
		var apnProfile = await Client
			.Hss
			.GetApnProfileAsync(apnProfiles.Results[0].Id, CancellationToken);

		_ = apnProfile.Should().BeOfType<ApnProfile>();
		_ = apnProfile.Should().NotBeNull();
	}

	private async Task<int> GetDefaultUsimProfileIdAsync(CancellationToken cancellationToken)
	{
		var usimProfiles = await Client
		.Hss
		.GetUsimProfilesAsync(cancellationToken)
		.ConfigureAwait(false);
		return
			usimProfiles.Results.FirstOrDefault(usp => usp.Default)?.Id
			?? throw new InvalidOperationException("No UsimProfile is set default.");
	}
}
