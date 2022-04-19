namespace Athonet.Api.Data.Mogw;

[DataContract]
public class Event
{
    [DataMember(Name = "layer")]
    public EventLayer Layer { get; set; }

    [DataMember(Name = "event_type")]
    public EventType Type { get; set; }

    [DataMember(Name = "timestamp")]
    public int UnixTimestamp { get; set; }

    [DataMember(Name = "timestampex")]
    public long UnixTimestampMs { get; set; }

    [DataMember(Name = "id")]
    public int Id { get; set; }

    [DataMember(Name = "evt")]
    public EventDetails EventDetails { get; set; } = new EventDetails();

    [DataMember(Name = "proc")]
    public string Process { get; set; } = string.Empty;

    [DataMember(Name = "event")]
    public string? EventMessage { get; set; }
}
