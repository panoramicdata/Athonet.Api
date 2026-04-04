namespace Athonet.Api.Data.Mogw;

/// <summary>
/// The event layer.
/// </summary>
[DataContract]
public enum EventLayer
{
	/// <summary>
	/// Unknown layer.
	/// </summary>
	Unknown = 0,

	/// <summary>
	/// Location services layer.
	/// </summary>
	[EnumMember(Value = "locations")]
	LocationServices = 1,

	/// <summary>
	/// S1AP layer.
	/// </summary>
	[EnumMember(Value = "s1ap")]
	S1APLayer = 2,

	/// <summary>
	/// Network Access Stratum layer.
	/// </summary>
	[EnumMember(Value = "nas")]
	NetworkAcessStratumLayer = 3,

	// ** Undocumented entries ** //

	/// <summary>
	/// RADIUS layer.
	/// </summary>
	[EnumMember(Value = "radius")]
	Radius = 4,

	/// <summary>
	/// GTP layer.
	/// </summary>
	[EnumMember(Value = "gtp")]
	GTP = 5
}
