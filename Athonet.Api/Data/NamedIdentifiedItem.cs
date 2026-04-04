namespace Athonet.Api.Data;

/// <summary>
/// A named, identified item
/// </summary>
public abstract class NamedIdentifiedItem : IdentifiedItem
{
	/// <summary>
	/// Human name
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = null!;
}
