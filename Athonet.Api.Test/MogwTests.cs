namespace Athonet.Api.Test;

public class MogwTests : BaseTest
{
	public MogwTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
	}

	[Fact]
	public async Task GetEvents_Succeeds()
	{
		// Get all
		var events = await Client
			.Mogw
			.GetEventsAsync(orderBy: "id", limit: 10)
			.ConfigureAwait(false);

		events.Should().BeOfType<MogwEventSet>();
		events.Should().NotBeNull();
	}
}