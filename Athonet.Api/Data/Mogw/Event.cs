namespace Athonet.Api.Data.Mogw;

/// <summary>
/// A MoGW event.
/// </summary>
public class Event
{
	/// <summary>
	/// The event layer.
	/// </summary>
	[JsonPropertyName("layer")]
	public EventLayer Layer { get; set; }

	/// <summary>
	/// The event type.
	/// </summary>
	[JsonPropertyName("event_type")]
	public EventType Type { get; set; }

	/// <summary>
	/// The Unix timestamp in seconds.
	/// </summary>
	[JsonPropertyName("timestamp")]
	public int UnixTimestamp { get; set; }

	/// <summary>
	/// The Unix timestamp in milliseconds.
	/// </summary>
	[JsonPropertyName("timestampex")]
	public long UnixTimestampMs { get; set; }

	/// <summary>
	/// The event ID.
	/// </summary>
	[JsonPropertyName("id")]
	public int Id { get; set; }

	/// <summary>
	/// The event details.
	/// </summary>
	[JsonPropertyName("evt")]
	public EventDetails EventDetails { get; set; } = new EventDetails();

	/// <summary>
	/// The process name.
	/// </summary>
	[JsonPropertyName("proc")]
	public string Process { get; set; } = string.Empty;

	/// <summary>
	/// The event message.
	/// </summary>
	[JsonPropertyName("event")]
	public string? EventMessage { get; set; }
}
