using System.Runtime.Serialization;

namespace Athonet.Api.Data.Mogw
{
	[DataContract]
	public enum EventType
	{
		Unknown,

		[DataMember(Name = "attach")]
		Attach,

		[DataMember(Name = "attach_failure")]
		AttachFailure,

		[DataMember(Name = "access_accept")]
		AccessAccept,

		[DataMember(Name = "access_reject")]
		AccessReject,

		[DataMember(Name = "detach")]
		Detach,

		[DataMember(Name = "location_update")]
		LocationUpdate,

		[DataMember(Name = "def_bearer_activation")]
		DefBearerActivation,

		[DataMember(Name = "def_bearer_activation_failure")]
		DefBearerActivationFailure,

		[DataMember(Name = "def_bearer_deactivation")]
		DefBearerDeactivation,

		[DataMember(Name = "bearer_deactivation")]
		BearerDeactivation,
	}
}