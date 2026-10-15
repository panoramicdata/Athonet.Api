using System.Text.Json;

namespace Athonet.Api.Test;

public class PageTests
{
	[Fact]
	public void Defaults_AreDocumentedValues()
	{
		var page = new Page<UsimProfile>();

		_ = page.Count.Should().Be(0);
		_ = page.Next.Should().BeNull();
		_ = page.Previous.Should().BeNull();
		_ = page.Results.Should().BeNull();
	}

	[Fact]
	public void Serialisation_RoundTripsAllProperties()
	{
		var page = new Page<UsimProfile>
		{
			Count = 1,
			Next = "https://example.invalid/next",
			Previous = "https://example.invalid/prev",
			Results = new List<UsimProfile> { new() { Id = 1, Name = "p" } }
		};

		var json = JsonSerializer.Serialize(page);
		var deserialized = JsonSerializer.Deserialize<Page<UsimProfile>>(json)!;

		_ = deserialized.Count.Should().Be(1);
		_ = deserialized.Next.Should().Be("https://example.invalid/next");
		_ = deserialized.Previous.Should().Be("https://example.invalid/prev");
		_ = deserialized.Results.Should().HaveCount(1);
		_ = deserialized.Results[0].Id.Should().Be(1);
		_ = deserialized.Results[0].Name.Should().Be("p");
	}
}
