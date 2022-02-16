namespace Athonet.Api.Data.Hss;

/// <summary>
/// A Public Land Mobile Network
/// </summary>
[DataContract]
public class PublicLandMobileNetwork : IdentifiedItem
{
    /// <summary>
    /// The Mobile Country Code
    /// </summary>
    [DataMember(Name = "mcc")]
    public int MobileCountryCode { get; set; }

    /// <summary>
    /// The Mobile Country Code ID
    /// </summary>
    [DataMember(Name = "mcc_id")]
    public int MobileCountryCodeId { get; set; }

    /// <summary>
    /// The mobile network code
    /// </summary>
    [DataMember(Name = "default")]
    public int MobileNetworkCode { get; set; }

    /// <summary>
    /// The operator
    /// </summary>
    [DataMember(Name = "operator")]
    public string? Operator { get; set; }
}
