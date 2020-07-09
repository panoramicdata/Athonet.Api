using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Athonet.Api.Data.Mogw
{
	[DataContract]
	public class Evt
	{
		[DataMember(Name = "layer")]
		public string Layer { get; set; } = null!;

		[DataMember(Name = "proc")]
		public string Proc { get; set; } = null!;

		[DataMember(Name = "type")]
		public string Type { get; set; } = null!;

		[DataMember(Name = "ip")]
		public string Ip { get; set; } = null!;

		[DataMember(Name = "timestamp")]
		public int Timestamp { get; set; }

		[DataMember(Name = "globalENBid")]
		public GlobalENBid GlobalENBid { get; set; } = null!;

		[DataMember(Name = "timestampex")]
		public long TimestampEx { get; set; }

		[DataMember(Name = "ENBname")]
		public string ENBname { get; set; } = null!;

		[DataMember(Name = "cause")]
		public string Cause { get; set; } = null!;

		[DataMember(Name = "imsi")]
		public string Imsi { get; set; } = null!;

		[DataMember(Name = "pgw_ip")]
		public IList<string> PgwIp { get; set; } = null!;

		[DataMember(Name = "bearer_id")]
		public string BearerId { get; set; } = null!;

		[DataMember(Name = "apn")]
		public string Apn { get; set; } = null!;

		[DataMember(Name = "ecgi")]
		public Ecgi Ecgi { get; set; } = null!;

		[DataMember(Name = "tai")]
		public Tai Tai { get; set; } = null!;
	}
}
