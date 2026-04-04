namespace Athonet.Api.Data.Mogw;

/// <summary>
/// Global eNodeB Identifier.
/// </summary>
public class GlobalENodeBId
{
	/// <summary>
	/// The PLMN identifier.
	/// </summary>
	[JsonPropertyName("plmn")]
	public string Plmn { get; set; } = string.Empty;

	/// <summary>
	/// The Home eNodeB identifier.
	/// </summary>
	[JsonPropertyName("homeENBid")]
	public int HomeENodeBId { get; set; }
}
