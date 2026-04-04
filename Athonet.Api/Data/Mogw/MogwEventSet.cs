namespace Athonet.Api.Data.Mogw;

/// <summary>
/// A MoGW Event set
/// </summary>
public class MogwEventSet
{
	/// <summary>
	/// The number of events in this set.
	/// </summary>
	[JsonPropertyName("count")]
	public int Count { get; set; }

	/// <summary>
	/// The total number of matching events.
	/// </summary>
	[JsonPropertyName("total")]
	public int Total { get; set; }

	/// <summary>
	/// The events.
	/// </summary>
	[JsonPropertyName("events")]
	public IList<Event> Events { get; set; } = new List<Event>();
}