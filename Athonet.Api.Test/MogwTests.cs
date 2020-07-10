using Athonet.Api.Data.Mogw;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Athonet.Api.Test
{
	public class MogwTests : BaseTest
	{
		public MogwTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
		{
		}

		[Fact]
		public async Task GetEvents_Succeeds()
		{
			// Confirms that serialising normally will use the enummember
			var evt = new Event { Type = EventType.UpdateLocation };
			Logger.LogInformation(JsonConvert.SerializeObject(evt));
			// Refit below does not use the enummember on updatelocation

			// Get all
			var events = await Client
				.Mogw
				.GetEventsAsync(orderBy: "id", type: EventType.UpdateLocation)
				.ConfigureAwait(false);

			events.Should().BeOfType<MogwEventSet>();
			events.Should().NotBeNull();
		}
	}
}
