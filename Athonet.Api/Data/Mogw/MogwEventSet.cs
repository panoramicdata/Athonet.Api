namespace Athonet.Api.Data.Mogw;

/// <summary>
/// A MoGW Event set
/// </summary>
[DataContract]
public class MogwEventSet
{
	/// <summary>
	/// The number of events in this set.
	/// </summary>
	[DataMember(Name = "count")]
	public int Count { get; set; }

	/// <summary>
	/// The total number of matching events.
	/// </summary>
	[DataMember(Name = "total")]
	public int Total { get; set; }

	/// <summary>
	/// The events.
	/// </summary>
	[DataMember(Name = "events")]
	public IList<Event> Events { get; set; } = new List<Event>();
}