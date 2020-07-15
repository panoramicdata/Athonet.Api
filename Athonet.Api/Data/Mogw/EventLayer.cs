using System.Runtime.Serialization;

namespace Athonet.Api.Data.Mogw
{
	[DataContract]
	public enum EventLayer
	{
		Unknown,

		[EnumMember(Value = "locations")]
		LocationServices,

		[EnumMember(Value = "s1ap")]
		S1APLayer,

		[EnumMember(Value = "nas")]
		NetworkAcessStratumLayer,

		// ** Undocumented entries ** //

		[EnumMember(Value = "radius")]
		Radius,

		[EnumMember(Value = "gtp")]
		GTP

	}
}