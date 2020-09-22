using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

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
		public object Ip { get; set; } = null!;

		[DataMember(Name = "timestamp")]
		public int Timestamp { get; set; }

		[DataMember(Name = "globalENBid")]
		public GlobalENBid GlobalENBid { get; set; } = null!;

		[DataMember(Name = "timestampex")]
		public object Timestampex { get; set; } = null!;

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
		public object TaiRaw { get; set; } = null!;

		public Tai Tai
			=> TaiRaw switch
			{
				Tai tai => tai,
				string taiString => GetTaiFromString(taiString),
				_ => throw new JsonReaderException($"Could not determine Tai format from '{TaiRaw}")
			};

		/// <summary>
		/// Example string to match against:
		/// tac-lb83.tac-hb00.tac.epc.mnc340.mcc311.3gppnetwork.org
		/// </summary>
		private static readonly Regex TaiRegex = new Regex(@"^tac-lb(?<lowByte>[\d]{2})\.tac-hb(?<highByte>[\d]{2})\.tac\.epc\.mnc(?<mnc>[\d]+)\.mcc(?<mcc>[\d]+)\.3gppnetwork\.org$");

		private static Tai GetTaiFromString(string taiRaw)
		{
			var matches = TaiRegex.Match(taiRaw);
			if(!matches.Success)
			{
				throw new JsonReaderException($"Could not determine Tai format from '{taiRaw}");
			}
			return new Tai
			{
				Plmn = $"{matches.Groups["mcc"]}{matches.Groups["mnc"]}",
				Tac = Convert.ToInt32($"0x{matches.Groups["highByte"]}{matches.Groups["lowByte"]}", 16)
			};
		}
	}
}
