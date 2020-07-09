using System.Runtime.Serialization;

namespace Athonet.Api.Data.Mogw
{
	[DataContract]
	public enum EventLayer
	{
		Unknown,

		[DataMember(Name = "locations")]
		LocationServices,

		[DataMember(Name = "s1ap")]
		S1APLayer,

		[DataMember(Name = "nas")]
		NetworkAcessStratumLayer
	}
}