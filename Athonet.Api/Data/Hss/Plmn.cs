namespace Athonet.Api.Data.Hss;

/// <summary>
/// A Public Land Mobile Network
/// </summary>
public class PublicLandMobileNetwork : IdentifiedItem
{
    /// <summary>
    /// The Mobile Country Code
    /// </summary>
    [JsonPropertyName("mcc")]
    public int MobileCountryCode { get; set; }

    /// <summary>
    /// The Mobile Country Code ID
    /// </summary>
    [JsonPropertyName("mcc_id")]
    public int MobileCountryCodeId { get; set; }

    /// <summary>
    /// The mobile network code
    /// </summary>
    [JsonPropertyName("default")]
    public int MobileNetworkCode { get; set; }

    /// <summary>
    /// The operator
    /// </summary>
    [JsonPropertyName("operator")]
    public string? Operator { get; set; }
}
