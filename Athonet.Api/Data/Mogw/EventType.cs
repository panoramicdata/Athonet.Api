namespace Athonet.Api.Data.Mogw;

[DataContract]
public enum EventType
{
    Unknown = 0,

    [EnumMember(Value = "attach")]
    Attach = 1,

    [EnumMember(Value = "attach_failure")]
    AttachFailure = 2,

    [EnumMember(Value = "access_accept")]
    AccessAccept = 3,

    [EnumMember(Value = "access_reject")]
    AccessReject = 4,

    [EnumMember(Value = "detach")]
    Detach = 5,

    [EnumMember(Value = "location_update")]
    LocationUpdate = 6,

    [EnumMember(Value = "def_bearer_activation")]
    DefBearerActivation = 7,

    [EnumMember(Value = "def_bearer_activation_failure")]
    DefBearerActivationFailure = 8,

    [EnumMember(Value = "def_bearer_deactivation")]
    DefBearerDeactivation = 9,

    [EnumMember(Value = "bearer_deactivation")]
    BearerDeactivation = 10,

    [EnumMember(Value = "create_session")]
    CreateSession = 11,

    [EnumMember(Value = "delete_session")]
    DeleteSession = 12,

    [EnumMember(Value = "modify_session")]
    ModifySession = 13,

    [EnumMember(Value = "update_session")]
    UpdateSession = 14,

    [EnumMember(Value = "ded_bearer_activation")]
    DedBearerActivation = 15,

    [EnumMember(Value = "ded_bearer_activation_failure")]
    DedBearerActivationFailure = 16,

    [EnumMember(Value = "s1_setup")]
    S1Setup = 17,

    [EnumMember(Value = "s1_down")]
    S1Down = 18,

    [EnumMember(Value = "s1_setup_fail")]
    S1SetupFail = 19,

    [EnumMember(Value = "s1_reset")]
    S1Reset = 20,

    [EnumMember(Value = "unreachable")]
    Unreachable = 21,

    [EnumMember(Value = "reachable")]
    Reachable = 22,

    [EnumMember(Value = "routing_area_update")]
    RoutingAreaUpdate = 23,

    [EnumMember(Value = "tracking_area_update")]
    TrackingAreaUpdate = 24,

    [EnumMember(Value = "isd")]
    Isd = 25,

    [EnumMember(Value = "isd_fail")]
    IsdFail = 26,

    [EnumMember(Value = "clr")]
    Clr = 27,

    [EnumMember(Value = "clr_fail")]
    ClrFail = 28,

    [EnumMember(Value = "update_location_fail")]
    UpdateLocationFail = 29,

    [EnumMember(Value = "cdr_limit")]
    CdrLimit = 30,

    // ** Undocumented entries ** //

    [EnumMember(Value = "update_location")]
    UpdateLocation = 31,

    [EnumMember(Value = "purge")]
    Purge = 32,

    [EnumMember(Value = "auth")]
    Auth = 33,

    [EnumMember(Value = "create_session_reject")]
    CreateSessionReject = 34,

    [EnumMember(Value = "air")]
    Air = 35,

    [EnumMember(Value = "air_fail")]
    AirFail = 36
}
