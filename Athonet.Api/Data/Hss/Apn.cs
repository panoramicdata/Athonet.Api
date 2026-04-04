namespace Athonet.Api.Data.Hss;

/// <summary>
/// An APN
/// </summary>
public class Apn : NamedIdentifiedItem
{
    /// <summary>
    /// The PDP type
    /// </summary>
    [JsonPropertyName("pdp_type")]
    public int PdpType { get; set; }
}
