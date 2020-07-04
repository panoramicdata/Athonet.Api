using System.Runtime.Serialization;

namespace Athonet.Api.Data.Mogw
{
	[DataContract]
	public class Ecgi
	{
		[DataMember(Name = "plmn")]
		public string Plmn { get; set; } = null!;

		[DataMember(Name = "cellid")]
		public int Cellid { get; set; }
	}
}
