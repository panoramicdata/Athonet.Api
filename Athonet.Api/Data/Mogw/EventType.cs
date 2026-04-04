namespace Athonet.Api.Data.Mogw;

/// <summary>
/// The event type.
/// </summary>
public enum EventType
{
	/// <summary>
	/// Unknown event type.
	/// </summary>
	Unknown = 0,

	/// <summary>
	/// Attach event.
	/// </summary>
	[EnumMember(Value = "attach")]
	Attach = 1,

	/// <summary>
	/// Attach failure event.
	/// </summary>
	[EnumMember(Value = "attach_failure")]
	AttachFailure = 2,

	/// <summary>
	/// Access accept event.
	/// </summary>
	[EnumMember(Value = "access_accept")]
	AccessAccept = 3,

	/// <summary>
	/// Access reject event.
	/// </summary>
	[EnumMember(Value = "access_reject")]
	AccessReject = 4,

	/// <summary>
	/// Detach event.
	/// </summary>
	[EnumMember(Value = "detach")]
	Detach = 5,

	/// <summary>
	/// Location update event.
	/// </summary>
	[EnumMember(Value = "location_update")]
	LocationUpdate = 6,

	/// <summary>
	/// Default bearer activation event.
	/// </summary>
	[EnumMember(Value = "def_bearer_activation")]
	DefBearerActivation = 7,

	/// <summary>
	/// Default bearer activation failure event.
	/// </summary>
	[EnumMember(Value = "def_bearer_activation_failure")]
	DefBearerActivationFailure = 8,

	/// <summary>
	/// Default bearer deactivation event.
	/// </summary>
	[EnumMember(Value = "def_bearer_deactivation")]
	DefBearerDeactivation = 9,

	/// <summary>
	/// Bearer deactivation event.
	/// </summary>
	[EnumMember(Value = "bearer_deactivation")]
	BearerDeactivation = 10,

	/// <summary>
	/// Create session event.
	/// </summary>
	[EnumMember(Value = "create_session")]
	CreateSession = 11,

	/// <summary>
	/// Delete session event.
	/// </summary>
	[EnumMember(Value = "delete_session")]
	DeleteSession = 12,

	/// <summary>
	/// Modify session event.
	/// </summary>
	[EnumMember(Value = "modify_session")]
	ModifySession = 13,

	/// <summary>
	/// Update session event.
	/// </summary>
	[EnumMember(Value = "update_session")]
	UpdateSession = 14,

	/// <summary>
	/// Dedicated bearer activation event.
	/// </summary>
	[EnumMember(Value = "ded_bearer_activation")]
	DedBearerActivation = 15,

	/// <summary>
	/// Dedicated bearer activation failure event.
	/// </summary>
	[EnumMember(Value = "ded_bearer_activation_failure")]
	DedBearerActivationFailure = 16,

	/// <summary>
	/// S1 setup event.
	/// </summary>
	[EnumMember(Value = "s1_setup")]
	S1Setup = 17,

	/// <summary>
	/// S1 down event.
	/// </summary>
	[EnumMember(Value = "s1_down")]
	S1Down = 18,

	/// <summary>
	/// S1 setup failure event.
	/// </summary>
	[EnumMember(Value = "s1_setup_fail")]
	S1SetupFail = 19,

	/// <summary>
	/// S1 reset event.
	/// </summary>
	[EnumMember(Value = "s1_reset")]
	S1Reset = 20,

	/// <summary>
	/// Unreachable event.
	/// </summary>
	[EnumMember(Value = "unreachable")]
	Unreachable = 21,

	/// <summary>
	/// Reachable event.
	/// </summary>
	[EnumMember(Value = "reachable")]
	Reachable = 22,

	/// <summary>
	/// Routing area update event.
	/// </summary>
	[EnumMember(Value = "routing_area_update")]
	RoutingAreaUpdate = 23,

	/// <summary>
	/// Tracking area update event.
	/// </summary>
	[EnumMember(Value = "tracking_area_update")]
	TrackingAreaUpdate = 24,

	/// <summary>
	/// Insert Subscriber Data event.
	/// </summary>
	[EnumMember(Value = "isd")]
	Isd = 25,

	/// <summary>
	/// Insert Subscriber Data failure event.
	/// </summary>
	[EnumMember(Value = "isd_fail")]
	IsdFail = 26,

	/// <summary>
	/// Cancel Location Request event.
	/// </summary>
	[EnumMember(Value = "clr")]
	Clr = 27,

	/// <summary>
	/// Cancel Location Request failure event.
	/// </summary>
	[EnumMember(Value = "clr_fail")]
	ClrFail = 28,

	/// <summary>
	/// Update location failure event.
	/// </summary>
	[EnumMember(Value = "update_location_fail")]
	UpdateLocationFail = 29,

	/// <summary>
	/// CDR limit event.
	/// </summary>
	[EnumMember(Value = "cdr_limit")]
	CdrLimit = 30,

	// ** Undocumented entries ** //

	/// <summary>
	/// Update location event.
	/// </summary>
	[EnumMember(Value = "update_location")]
	UpdateLocation = 31,

	/// <summary>
	/// Purge event.
	/// </summary>
	[EnumMember(Value = "purge")]
	Purge = 32,

	/// <summary>
	/// Authentication event.
	/// </summary>
	[EnumMember(Value = "auth")]
	Auth = 33,

	/// <summary>
	/// Create session reject event.
	/// </summary>
	[EnumMember(Value = "create_session_reject")]
	CreateSessionReject = 34,

	/// <summary>
	/// Authentication Information Request event.
	/// </summary>
	[EnumMember(Value = "air")]
	Air = 35,

	/// <summary>
	/// Authentication Information Request failure event.
	/// </summary>
	[EnumMember(Value = "air_fail")]
	AirFail = 36
}
