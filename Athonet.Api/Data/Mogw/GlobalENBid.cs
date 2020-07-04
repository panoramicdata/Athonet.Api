using System.Runtime.Serialization;

namespace Athonet.Api.Data.Mogw
{
	[DataContract]
	public class GlobalENBid
	{
		[DataMember(Name = "homeENBid")]
		public int HomeENBid { get; set; }

		[DataMember(Name = "plmn")]
		public string? Plmn { get; set; } = null!;
	}
}
