using System.Runtime.Serialization;

namespace Athonet.Api.Data.Hss
{
	/// <summary>
	/// A named, identified item
	/// </summary>
	[DataContract]
	public abstract class NamedIdentifiedItem : IdentifiedItem
	{
		/// <summary>
		/// Human name
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; } = null!;
	}
}
