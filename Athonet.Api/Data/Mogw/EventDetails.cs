namespace Athonet.Api.Data.Mogw;

/// <summary>
/// Detailed information about a MoGW event.
/// </summary>
public class EventDetails
{
	/// <summary>
	/// The event layer.
	/// </summary>
	[JsonPropertyName("layer")]
	public EventLayer Layer { get; set; }

	/// <summary>
	/// The procedure name.
	/// </summary>
	[JsonPropertyName("proc")]
	public string Proc { get; set; } = string.Empty;

	/// <summary>
	/// The event type.
	/// </summary>
	[JsonPropertyName("type")]
	public EventType Type { get; set; }

	/// <summary>
	/// The IP address.
	/// </summary>
	[JsonPropertyName("ip")]
	public object? Ip { get; set; }

	/// <summary>
	/// The Unix timestamp in seconds.
	/// </summary>
	[JsonPropertyName("timestamp")]
	public int UnixTimestamp { get; set; }

	/// <summary>
	/// The Global eNodeB Identifier.
	/// </summary>
	[JsonPropertyName("globalENBid")]
	public GlobalENodeBId? GlobalENodeBId { get; set; }

	/// <summary>
	/// The Unix timestamp in milliseconds.
	/// </summary>
	[JsonPropertyName("timestampex")]
	public long UnixTimestampMs { get; set; }

	/// <summary>
	/// The eNodeB name.
	/// </summary>
	[JsonPropertyName("ENBname")]
	public string? ENodeBName { get; set; }

	/// <summary>
	/// The cause of the event.
	/// </summary>
	[JsonPropertyName("cause")]
	public string? Cause { get; set; }

	/// <summary>
	/// The International Mobile Subscriber Identity.
	/// </summary>
	[JsonPropertyName("imsi")]
	public string? Imsi { get; set; }

	/// <summary>
	/// The PDN Gateway IP addresses.
	/// </summary>
	[JsonPropertyName("pgw_ip")]
	public IList<string>? PgwIp { get; set; }

	/// <summary>
	/// The bearer identifier.
	/// </summary>
	[JsonPropertyName("bearer_id")]
	public string? BearerId { get; set; }

	/// <summary>
	/// The Access Point Name.
	/// </summary>
	[JsonPropertyName("apn")]
	public string? Apn { get; set; }

	/// <summary>
	/// The E-UTRAN Cell Global Identifier.
	/// </summary>
	[JsonPropertyName("ecgi")]
	public Ecgi? Ecgi { get; set; }

	/// <summary>
	/// The International Mobile Equipment Identity.
	/// </summary>
	[JsonPropertyName("imei")]
	public string? Imei { get; set; }

	/// <summary>
	/// The Mobile Subscriber ISDN Number.
	/// </summary>
	[JsonPropertyName("msisdn")]
	public string? Msisdn { get; set; }

	/// <summary>
	/// The user addresses.
	/// </summary>
	[JsonPropertyName("user_addr")]
	public IList<string>? UserAddr { get; set; }

	/// <summary>
	/// The Radio Access Technology.
	/// </summary>
	[JsonPropertyName("rat")]
	public string? Rat { get; set; }

	/// <summary>
	/// The service.
	/// </summary>
	[JsonPropertyName("srv")]
	public string? Srv { get; set; }

	/// <summary>
	/// The username.
	/// </summary>
	[JsonPropertyName("username")]
	public string? Username { get; set; }

	/// <summary>
	/// The MME hostname.
	/// </summary>
	[JsonPropertyName("mme_hostname")]
	public string? MmeHostname { get; set; }

	/// <summary>
	/// The MME realm name.
	/// </summary>
	[JsonPropertyName("mme_realmname")]
	public string? MmeRealMName { get; set; }

	/// <summary>
	/// The network interface.
	/// </summary>
	[JsonPropertyName("interface")]
	public string? Interface { get; set; }

	/// <summary>
	/// The raw Tracking Area Identity value.
	/// </summary>
	[JsonPropertyName("tai")]
	public object? TaiRaw { get; set; } = null!;

	/// <summary>
	/// The parsed Tracking Area Identity.
	/// </summary>
	public Tai? Tai
		=> TaiRaw switch
		{
			null => null,
			Tai tai => tai,
			JsonElement jsonElement => JsonSerializer.Deserialize<Tai>(jsonElement.GetRawText()),
			string taiString => GetTaiFromString(taiString),
			_ => throw new JsonException($"Could not determine Tai format from '{TaiRaw}")
		};

	/// <summary>
	/// Example string to match against:
	/// tac-lb83.tac-hb00.tac.epc.mnc340.mcc311.3gppnetwork.org
	/// </summary>
	private static readonly Regex TaiRegex = new(@"^tac-lb(?<lowByte>[a-f\d]{2})\.tac-hb(?<highByte>[a-f\d]{2})\.tac\.epc\.mnc(?<mnc>[\d]+)\.mcc(?<mcc>[\d]+)\.3gppnetwork\.org$");

	private static Tai GetTaiFromString(string taiRaw)
	{
		var matches = TaiRegex.Match(taiRaw);
		if (!matches.Success)
		{
			throw new FormatException($"Could not determine Tai format from '{taiRaw}");
		}

		return new Tai
		{
			Plmn = $"{matches.Groups["mcc"]}{matches.Groups["mnc"]}",
			Tac = Convert.ToInt32($"0x{matches.Groups["highByte"]}{matches.Groups["lowByte"]}", 16)
		};
	}
}
