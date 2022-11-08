namespace Athonet.Api.Data;

/// <summary>
/// An identified item
/// </summary>
[DataContract]
public abstract class IdentifiedItem
{
	/// <summary>
	/// Resource ID
	/// </summary>
	[DataMember(Name = "id")]
	public int Id { get; set; }
}
