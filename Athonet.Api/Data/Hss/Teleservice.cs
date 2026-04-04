namespace Athonet.Api.Data.Hss;

/// <summary>
/// A Teleservice
/// </summary>
public class Teleservice : IdentifiedItem
{
    /// <summary>
    /// The teleservice ID
    /// </summary>
    [JsonPropertyName("teleservice")]
    public int TeleserviceId { get; set; }

    /// <summary>
    /// The USIM Profile ID
    /// </summary>
    [JsonPropertyName("id_usim_profile")]
    public int UsimProfileId { get; set; }
}
