using System.Runtime.Serialization;

namespace Athonet.Api.Data.Hss
{
	/// <summary>
	/// A Teleservice
	/// </summary>
	[DataContract]
	public class Teleservice : IdentifiedItem
	{
		/// <summary>
		/// The teleservice ID
		/// </summary>
		[DataMember(Name = "teleservice")]
		public int TeleserviceId { get; set; }

		/// <summary>
		/// The USIM Profile ID
		/// </summary>
		[DataMember(Name = "id_usim_profile")]
		public int UsimProfileId { get; set; }
	}
}
