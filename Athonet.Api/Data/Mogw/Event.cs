namespace Athonet.Api.Data.Mogw;

/// <summary>
/// A MoGW event.
/// </summary>
[DataContract]
public class Event
{
	/// <summary>
	/// The event layer.
	/// </summary>
	[DataMember(Name = "layer")]
	public EventLayer Layer { get; set; }

	/// <summary>
	/// The event type.
	/// </summary>
	[DataMember(Name = "event_type")]
	public EventType Type { get; set; }

	/// <summary>
	/// The Unix timestamp in seconds.
	/// </summary>
	[DataMember(Name = "timestamp")]
	public int UnixTimestamp { get; set; }

	/// <summary>
	/// The Unix timestamp in milliseconds.
	/// </summary>
	[DataMember(Name = "timestampex")]
	public long UnixTimestampMs { get; set; }

	/// <summary>
	/// The event ID.
	/// </summary>
	[DataMember(Name = "id")]
	public int Id { get; set; }

	/// <summary>
	/// The event details.
	/// </summary>
	[DataMember(Name = "evt")]
	public EventDetails EventDetails { get; set; } = new EventDetails();

	/// <summary>
	/// The process name.
	/// </summary>
	[DataMember(Name = "proc")]
	public string Process { get; set; } = string.Empty;

	/// <summary>
	/// The event message.
	/// </summary>
	[DataMember(Name = "event")]
	public string? EventMessage { get; set; }
}
