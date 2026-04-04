namespace Athonet.Api.Data;

/// <summary>
/// An identified item
/// </summary>
public abstract class IdentifiedItem
{
	/// <summary>
	/// Resource ID
	/// </summary>
	[JsonPropertyName("id")]
	public int Id { get; set; }
}
