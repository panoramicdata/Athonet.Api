namespace Athonet.Api.Data.Mogw;

[DataContract]
public enum EventLayer
{
    Unknown = 0,

    [EnumMember(Value = "locations")]
    LocationServices = 1,

    [EnumMember(Value = "s1ap")]
    S1APLayer = 2,

    [EnumMember(Value = "nas")]
    NetworkAcessStratumLayer = 3,

    // ** Undocumented entries ** //

    [EnumMember(Value = "radius")]
    Radius = 4,

    [EnumMember(Value = "gtp")]
    GTP = 5

}
