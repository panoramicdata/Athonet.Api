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

		[DataMember(Name = "create_session")]
		CreateSession,

		[DataMember(Name = "delete_session")]
		DeleteSession,

		[DataMember(Name = "modify_session")]
		ModifySession,

		[DataMember(Name = "update_session")]
		UpdateSession,

		[DataMember(Name = "ded_bearer_activation")]
		DedBearerActivation,

		[DataMember(Name = "ded_bearer_activation_failure")]
		DedBearerActivationFailure,

		[DataMember(Name = "s1_setup")]
		S1Setup,

		[DataMember(Name = "s1_down")]
		S1Down,

		[DataMember(Name = "s1_setup_fail")]
		S1SetupFail,

		[DataMember(Name = "s1_reset")]
		S1Reset,

		[DataMember(Name = "unreachable")]
		Unreachable,

		[DataMember(Name = "reachable")]
		Reachable,

		[DataMember(Name = "routing_area_update")]
		RoutingAreaUpdate,

		[DataMember(Name = "tracking_area_update")]
		TrackingAreaUpdate,

		[DataMember(Name = "isd")]
		Isd,

		[DataMember(Name = "isd_fail")]
		IsdFail,

		[DataMember(Name = "clr")]
		Clr,

		[DataMember(Name = "clr_fail")]
		ClrFail,

		[DataMember(Name = "update_location_fail")]
		UpdateLocationFail,

		[DataMember(Name = "cdr_limit")]
		CdrLimit
	}
}