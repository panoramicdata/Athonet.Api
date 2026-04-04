namespace Athonet.Api.Data.Mogw;

/// <summary>
/// Detailed information about a MoGW event.
/// </summary>
[DataContract]
public class EventDetails
{
	/// <summary>
	/// The event layer.
	/// </summary>
	[DataMember(Name = "layer")]
	public EventLayer Layer { get; set; }

	/// <summary>
	/// The procedure name.
	/// </summary>
	[DataMember(Name = "proc")]
	public string Proc { get; set; } = string.Empty;

	/// <summary>
	/// The event type.
	/// </summary>
	[DataMember(Name = "type")]
	public EventType Type { get; set; }

	/// <summary>
	/// The IP address.
	/// </summary>
	[DataMember(Name = "ip")]
	public object? Ip { get; set; }

	/// <summary>
	/// The Unix timestamp in seconds.
	/// </summary>
	[DataMember(Name = "timestamp")]
	public int UnixTimestamp { get; set; }

	/// <summary>
	/// The Global eNodeB Identifier.
	/// </summary>
	[DataMember(Name = "globalENBid")]
	public GlobalENodeBId? GlobalENodeBId { get; set; }

	/// <summary>
	/// The Unix timestamp in milliseconds.
	/// </summary>
	[DataMember(Name = "timestampex")]
	public long UnixTimestampMs { get; set; }

	/// <summary>
	/// The eNodeB name.
	/// </summary>
	[DataMember(Name = "ENBname")]
	public string? ENodeBName { get; set; }

	/// <summary>
	/// The cause of the event.
	/// </summary>
	[DataMember(Name = "cause")]
	public string? Cause { get; set; }

	/// <summary>
	/// The International Mobile Subscriber Identity.
	/// </summary>
	[DataMember(Name = "imsi")]
	public string? Imsi { get; set; }

	/// <summary>
	/// The PDN Gateway IP addresses.
	/// </summary>
	[DataMember(Name = "pgw_ip")]
	public IList<string>? PgwIp { get; set; }

	/// <summary>
	/// The bearer identifier.
	/// </summary>
	[DataMember(Name = "bearer_id")]
	public string? BearerId { get; set; }

	/// <summary>
	/// The Access Point Name.
	/// </summary>
	[DataMember(Name = "apn")]
	public string? Apn { get; set; }

	/// <summary>
	/// The E-UTRAN Cell Global Identifier.
	/// </summary>
	[DataMember(Name = "ecgi")]
	public Ecgi? Ecgi { get; set; }

	/// <summary>
	/// The International Mobile Equipment Identity.
	/// </summary>
	[DataMember(Name = "imei")]
	public string? Imei { get; set; }

	/// <summary>
	/// The Mobile Subscriber ISDN Number.
	/// </summary>
	[DataMember(Name = "msisdn")]
	public string? Msisdn { get; set; }

	/// <summary>
	/// The user addresses.
	/// </summary>
	[DataMember(Name = "user_addr")]
	public IList<string>? UserAddr { get; set; }

	/// <summary>
	/// The Radio Access Technology.
	/// </summary>
	[DataMember(Name = "rat")]
	public string? Rat { get; set; }

	/// <summary>
	/// The service.
	/// </summary>
	[DataMember(Name = "srv")]
	public string? Srv { get; set; }

	/// <summary>
	/// The username.
	/// </summary>
	[DataMember(Name = "username")]
	public string? Username { get; set; }

	/// <summary>
	/// The MME hostname.
	/// </summary>
	[DataMember(Name = "mme_hostname")]
	public string? MmeHostname { get; set; }

	/// <summary>
	/// The MME realm name.
	/// </summary>
	[DataMember(Name = "mme_realmname")]
	public string? MmeRealMName { get; set; }

	/// <summary>
	/// The network interface.
	/// </summary>
	[DataMember(Name = "interface")]
	public string? Interface { get; set; }

	/// <summary>
	/// The raw Tracking Area Identity value.
	/// </summary>
	[DataMember(Name = "tai")]
	public object? TaiRaw { get; set; } = null!;

	/// <summary>
	/// The parsed Tracking Area Identity.
	/// </summary>
	public Tai? Tai
		=> TaiRaw switch
		{
			null => null,
			Tai tai => tai,
			JObject jObject => jObject.ToObject<Tai>(),
			string taiString => GetTaiFromString(taiString),
			_ => throw new JsonReaderException($"Could not determine Tai format from '{TaiRaw}")
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
