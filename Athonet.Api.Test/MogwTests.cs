using Athonet.Api.Data.Mogw;
using FluentAssertions;
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
			// Get all
			var events = await Client
				.Mogw
				.GetEventsAsync()
				.ConfigureAwait(false);

			events.Should().BeOfType<MogwEventSet>();
			events.Should().NotBeNull();
		}
	}
}
