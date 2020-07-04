using System.Runtime.Serialization;

namespace Athonet.Api.Data.Hss
{
	/// <summary>
	/// An APN
	/// </summary>
	[DataContract]
	public class Apn : NamedIdentifiedItem
	{
		/// <summary>
		/// The PDP type
		/// </summary>
		[DataMember(Name = "pdp_type")]
		public int PdpType { get; set; }
	}
}
