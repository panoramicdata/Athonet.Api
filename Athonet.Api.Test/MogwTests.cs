namespace Athonet.Api.Test;

public class MogwTests(ITestOutputHelper testOutputHelper, Fixture fixture) : BaseTest(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetEvents_Succeeds()
	{
		// Get all
		var events = await Client
			.Mogw
			.GetEventsAsync(orderBy: "id", limit: 10, cancellationToken: CancellationToken);

		_ = events.Should().BeOfType<MogwEventSet>();
		_ = events.Should().NotBeNull();
	}
}