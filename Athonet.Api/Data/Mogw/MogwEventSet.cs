namespace Athonet.Api.Data.Mogw;

/// <summary>
/// A MoGW Event set
/// </summary>
[DataContract]
public class MogwEventSet
{
	[DataMember(Name = "count")]
	public int Count { get; set; }

	[DataMember(Name = "total")]
	public int Total { get; set; }

	[DataMember(Name = "events")]
	public IList<Event> Events { get; set; } = new List<Event>();
}