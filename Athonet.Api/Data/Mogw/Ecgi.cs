namespace Athonet.Api.Data.Mogw;

/// <summary>
/// E-UTRAN Cell Global Identifier.
/// </summary>
public class Ecgi
{
	/// <summary>
	/// The PLMN identifier.
	/// </summary>
	[JsonPropertyName("plmn")]
	public string Plmn { get; set; } = string.Empty;

	/// <summary>
	/// The cell identifier.
	/// </summary>
	[JsonPropertyName("cellid")]
	public int Cellid { get; set; }
}
