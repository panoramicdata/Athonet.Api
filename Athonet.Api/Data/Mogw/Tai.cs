namespace Athonet.Api.Data.Mogw;

/// <summary>
/// Tracking Area Identity.
/// </summary>
public class Tai
{
	/// <summary>
	/// The PLMN identifier.
	/// </summary>
	[JsonPropertyName("plmn")]
	public string Plmn { get; set; } = string.Empty;

	/// <summary>
	/// The Tracking Area Code.
	/// </summary>
	[JsonPropertyName("tac")]
	public int Tac { get; set; }
}
