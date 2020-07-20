﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Athonet.Api.Data.Mogw
{
	[DataContract]
	public class EventDetails
	{
		[DataMember(Name = "layer")]
		public EventLayer Layer { get; set; }

		[DataMember(Name = "proc")]
		public string Proc { get; set; } = string.Empty;

		[DataMember(Name = "type")]
		public EventType Type { get; set; }

		[DataMember(Name = "ip")]
		public object? Ip { get; set; }

		[DataMember(Name = "timestamp")]
		public int UnixTimestamp { get; set; }

		[DataMember(Name = "globalENBid")]
		public GlobalENodeBId? GlobalENodeBId { get; set; }

		[DataMember(Name = "timestampex")]
		public long UnixTimestampMs { get; set; }

		[DataMember(Name = "ENBname")]
		public string? ENodeBName { get; set; }

		[DataMember(Name = "cause")]
		public string? Cause { get; set; }

		[DataMember(Name = "imsi")]
		public string? Imsi { get; set; }

		[DataMember(Name = "pgw_ip")]
		public IList<string>? PgwIp { get; set; }

		[DataMember(Name = "bearer_id")]
		public string? BearerId { get; set; }

		[DataMember(Name = "apn")]
		public string? Apn { get; set; }

		[DataMember(Name = "ecgi")]
		public Ecgi? Ecgi { get; set; }

		[DataMember(Name = "tai")]
		public Tai? Tai { get; set; }

		[DataMember(Name = "imei")]
		public string? Imei { get; set; }

		[DataMember(Name = "msisdn")]
		public string? Msisdn { get; set; }

		[DataMember(Name = "user_addr")]
		public IList<string>? UserAddr { get; set; }

		[DataMember(Name = "rat")]
		public string? Rat { get; set; }

		[DataMember(Name = "srv")]
		public string? Srv { get; set; }

		[DataMember(Name = "username")]
		public string? Username { get; set; }

		[DataMember(Name = "mme_hostname")]
		public string? MmeHostname { get; set; }

		[DataMember(Name = "mme_realmname")]
		public string? MmeRealMName { get; set; }

		[DataMember(Name = "interface")]
		public string? Interface { get; set; }
	}
}
