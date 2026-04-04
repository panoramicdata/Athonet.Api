namespace Athonet.Api.Data.Mogw;

/// <summary>
/// Global eNodeB Identifier.
/// </summary>
[DataContract]
public class GlobalENodeBId
{
	/// <summary>
	/// The PLMN identifier.
	/// </summary>
	[DataMember(Name = "plmn")]
	public string Plmn { get; set; } = string.Empty;

	/// <summary>
	/// The Home eNodeB identifier.
	/// </summary>
	[DataMember(Name = "homeENBid")]
	public int HomeENodeBId { get; set; }
}
