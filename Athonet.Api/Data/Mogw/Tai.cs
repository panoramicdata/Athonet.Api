using System.Runtime.Serialization;

namespace Athonet.Api.Data.Mogw
{
	[DataContract]
	public class Tai
	{
		[DataMember(Name = "plmn")]
		public string Plmn { get; set; } = null!;

		[DataMember(Name = "tac")]
		public int Tac { get; set; }
	}
}
