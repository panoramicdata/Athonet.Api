namespace Athonet.Api.Data.Mogw;

/// <summary>
/// E-UTRAN Cell Global Identifier.
/// </summary>
[DataContract]
public class Ecgi
{
	/// <summary>
	/// The PLMN identifier.
	/// </summary>
	[DataMember(Name = "plmn")]
	public string Plmn { get; set; } = string.Empty;

	/// <summary>
	/// The cell identifier.
	/// </summary>
	[DataMember(Name = "cellid")]
	public int Cellid { get; set; }
}
