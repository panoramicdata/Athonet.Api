using System.Runtime.Serialization;

namespace Athonet.Api.Data.Mogw
{
	[DataContract]
	public class Event
	{
		[DataMember(Name = "layer")]
		public EventLayer Layer { get; set; }

		[DataMember(Name = "event_type")]
		public EventType EventType { get; set; }

		[DataMember(Name = "timestamp")]
		public int Timestamp { get; set; }

		[DataMember(Name = "event")]
		public string? EventMessage { get; set; }

		[DataMember(Name = "evt")]
		public Evt Evt { get; set; } = null!;

		[DataMember(Name = "proc")]
		public string Proc { get; set; } = null!;

		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}
