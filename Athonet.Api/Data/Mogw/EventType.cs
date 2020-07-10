using System.Runtime.Serialization;

namespace Athonet.Api.Data.Mogw
{
	[DataContract]
	public enum EventType
	{
		Unknown,

		[EnumMember(Value = "attach")]
		Attach,

		[EnumMember(Value = "attach_failure")]
		AttachFailure,

		[EnumMember(Value = "access_accept")]
		AccessAccept,

		[EnumMember(Value = "access_reject")]
		AccessReject,

		[EnumMember(Value = "detach")]
		Detach,

		[EnumMember(Value = "location_update")]
		LocationUpdate,

		[EnumMember(Value = "def_bearer_activation")]
		DefBearerActivation,

		[EnumMember(Value = "def_bearer_activation_failure")]
		DefBearerActivationFailure,

		[EnumMember(Value = "def_bearer_deactivation")]
		DefBearerDeactivation,

		[EnumMember(Value = "bearer_deactivation")]
		BearerDeactivation,

		[EnumMember(Value = "create_session")]
		CreateSession,

		[EnumMember(Value = "delete_session")]
		DeleteSession,

		[EnumMember(Value = "modify_session")]
		ModifySession,

		[EnumMember(Value = "update_session")]
		UpdateSession,

		[EnumMember(Value = "ded_bearer_activation")]
		DedBearerActivation,

		[EnumMember(Value = "ded_bearer_activation_failure")]
		DedBearerActivationFailure,

		[EnumMember(Value = "s1_setup")]
		S1Setup,

		[EnumMember(Value = "s1_down")]
		S1Down,

		[EnumMember(Value = "s1_setup_fail")]
		S1SetupFail,

		[EnumMember(Value = "s1_reset")]
		S1Reset,

		[EnumMember(Value = "unreachable")]
		Unreachable,

		[EnumMember(Value = "reachable")]
		Reachable,

		[EnumMember(Value = "routing_area_update")]
		RoutingAreaUpdate,

		[EnumMember(Value = "tracking_area_update")]
		TrackingAreaUpdate,

		[EnumMember(Value = "isd")]
		Isd,

		[EnumMember(Value = "isd_fail")]
		IsdFail,

		[EnumMember(Value = "clr")]
		Clr,

		[EnumMember(Value = "clr_fail")]
		ClrFail,

		[EnumMember(Value = "update_location_fail")]
		UpdateLocationFail,

		[EnumMember(Value = "cdr_limit")]
		CdrLimit,

		// Outside documented values

		[EnumMember(Value = "update_location")]
		UpdateLocation,

		[EnumMember(Value = "purge")]
		Purge,
	}
}