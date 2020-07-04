using System.Runtime.Serialization;

namespace Athonet.Api.Data.Hss
{
	/// <summary>
	/// An identified item
	/// </summary>
	[DataContract]
	public abstract class IdentifiedItem
	{
		/// <summary>
		/// Resource ID
		/// </summary>
		[DataMember(Name = "id")]
		public int Id { get; set; }
	}
}