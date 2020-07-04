using System.Runtime.Serialization;

namespace Athonet.Api.Data.Hss
{
	/// <summary>
	/// A USIM profile
	/// </summary>
	[DataContract]
	public class ApnProfile : NamedIdentifiedItem
	{
		/// <summary>
		/// The APN ID
		/// </summary>
		[DataMember(Name = "id_apn")]
		public int ApnId { get; set; }

		/// <summary>
		/// Whether this is the default APN
		/// </summary>
		[DataMember(Name = "default")]
		public bool Default { get; set; }

		/// <summary>
		/// The charging characteristics
		/// </summary>
		[DataMember(Name = "charging_characteristics")]
		public object? ChargingCharacteristics { get; set; }

		/// <summary>
		/// The 3G QOS template ID
		/// </summary>
		[DataMember(Name = "id_qos_template_3g")]
		public int? IdQosTemplate3g { get; set; }

		/// <summary>
		/// The 4G QOS template ID
		/// </summary>
		[DataMember(Name = "id_qos_template_4g")]
		public int? IdQosTemplate4g { get; set; }
	}
}
