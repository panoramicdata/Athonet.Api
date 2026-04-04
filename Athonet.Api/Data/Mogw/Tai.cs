namespace Athonet.Api.Data.Mogw;

/// <summary>
/// Tracking Area Identity.
/// </summary>
[DataContract]
public class Tai
{
	/// <summary>
	/// The PLMN identifier.
	/// </summary>
	[DataMember(Name = "plmn")]
	public string Plmn { get; set; } = string.Empty;

	/// <summary>
	/// The Tracking Area Code.
	/// </summary>
	[DataMember(Name = "tac")]
	public int Tac { get; set; }
}
