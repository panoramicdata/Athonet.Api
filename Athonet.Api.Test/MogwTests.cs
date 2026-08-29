namespace Athonet.Api.Test;

public class MogwTests(ITestOutputHelper testOutputHelper, Fixture fixture) : BaseTest(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetEvents_Succeeds()
	{
		// Get all
		var events = await Client
			.Mogw
			.GetEventsAsync(
				new MogwEventQuery { OrderBy = "id", Limit = 10 },
				CancellationToken);

		_ = events.Should().BeOfType<MogwEventSet>();
		_ = events.Should().NotBeNull();
	}
}