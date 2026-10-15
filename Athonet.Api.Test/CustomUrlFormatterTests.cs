using System.Text.Json.Serialization;
using Athonet.Api.Data.Mogw;

namespace Athonet.Api.Test;

public class CustomUrlFormatterTests
{
	private static CustomUrlParameterFormatter Formatter => new();

	[Fact]
	public void Format_NullValue_ReturnsNull()
	{
		var result = Formatter.Format(null, null!, typeof(string));

		_ = result.Should().BeNull();
	}
}
