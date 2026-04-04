namespace Athonet.Api.Data.Hss;

/// <summary>
/// A USIM profile
/// </summary>
public class UsimProfile : NamedIdentifiedItem
{
    /// <summary>
    /// AMBR Uplink at UE level
    /// </summary>
    [JsonPropertyName("ue_ambr_ul")]
    public int UeAmbrUplink { get; set; }

    /// <summary>
    /// AMBR Downlink at UE level
    /// </summary>
    [JsonPropertyName("ue_ambr_dl")]
    public int UeAmbrDownlink { get; set; }

    /// <summary>
    /// True is the element is the Default USIM Profile (the profile associated to a USIM is no profile is specified)
    /// </summary>
    [JsonPropertyName("default")]
    public bool Default { get; set; }

    /// <summary>
    /// True if roaming is allowed for this USIM profile
    /// </summary>
    [JsonPropertyName("roaming_allowed")]
    public int RoamingAllowed { get; set; }

    /// <summary>
    /// No documentation avialable
    /// </summary>
    [JsonPropertyName("subscription_data_flags")]
    public int SubscriptionDataFlags { get; set; }

    /// <summary>
    /// No documentation avialable
    /// </summary>
    [JsonPropertyName("charging_characteristics")]
    public int? ChargingCharacteristics { get; set; }

    /// <summary>
    /// Network access mode S6a [2-OnlyPacket, 3-PacketAndCircuit]
    /// </summary>
    [JsonPropertyName("s6a_nam")]
    public int S6aNam { get; set; } = 2;

    /// <summary>
    /// Network access mode S6d/Gr [1-OnlyCircuit, 2-OnlyPacket, 3-PacketAndCircuit]
    /// </summary>
    [JsonPropertyName("s6dgr_nam")]
    public int S6dgrNam { get; set; } = 3;

    /// <summary>
    /// The regional subscriptions profile.
    /// </summary>
    [JsonPropertyName("regional_subscriptions_profile")]
    public object? RegionalSubscriptionsProfile { get; set; }
}
