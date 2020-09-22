using Athonet.Api.Data.Mogw;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Athonet.Api.Test
{
	public class TaiTests : BaseTest
	{
		public TaiTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
		{
		}

		[Fact]
		public void String_Succeeds()
		{
			var evt = new EventDetails
			{
				TaiRaw = "tac-lb83.tac-hb00.tac.epc.mnc340.mcc311.3gppnetwork.org"
			};

			evt.Tai.Should().BeOfType<Tai>();
			evt.Tai.Plmn.Should().Be("311340");
			evt.Tai.Tac.Should().Be(131);
		}

		[Fact]
		public void Tai_Succeeds()
		{
			var evt = new EventDetails
			{
				TaiRaw = new Tai
				{
					Plmn = "311340",
					Tac = 131
				}
			};

			evt.Tai.Should().BeOfType<Tai>();
			evt.Tai.Plmn.Should().Be("311340");
			evt.Tai.Tac.Should().Be(131);
		}
		[Fact]
		public void JObject_Succeeds()
		{
			var evt = new EventDetails
			{
				TaiRaw = JObject.Parse("{ \"Plmn\": \"311340\", \"Tac\": 131 }")
			};

			evt.Tai.Should().BeOfType<Tai>();
			evt.Tai.Plmn.Should().Be("311340");
			evt.Tai.Tac.Should().Be(131);
		}
	}
}
