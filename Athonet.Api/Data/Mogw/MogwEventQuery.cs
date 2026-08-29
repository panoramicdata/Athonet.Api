namespace Athonet.Api.Data.Mogw;

/// <summary>
/// Filter criteria for <see cref="Interfaces.IMogw.GetEventsAsync"/>.
/// Every property is optional; properties left null are omitted from the query string.
/// </summary>
public sealed record MogwEventQuery
{
	/// <summary>
	/// The IMSI to filter by.
	/// </summary>
	[AliasAs("imsi")]
	public string? Imsi { get; init; }

	/// <summary>
	/// The IMEI to filter by.
	/// </summary>
	[AliasAs("imei")]
	public string? Imei { get; init; }

	/// <summary>
	/// The start timestamp to filter from.
	/// </summary>
	[AliasAs("from")]
	public long? FromTimestamp { get; init; }

	/// <summary>
	/// The end timestamp to filter to.
	/// </summary>
	[AliasAs("to")]
	public long? ToTimestamp { get; init; }

	/// <summary>
	/// The maximum number of events to return.
	/// </summary>
	[AliasAs("limit")]
	public int? Limit { get; init; }

	/// <summary>
	/// The event type to filter by.
	/// </summary>
	[AliasAs("type")]
	public EventType? EventType { get; init; }

	/// <summary>
	/// The event layer to filter by.
	/// </summary>
	[AliasAs("layer")]
	public EventLayer? EventLayer { get; init; }

	/// <summary>
	/// The event ID to filter by.
	/// </summary>
	[AliasAs("id")]
	public long? Id { get; init; }

	/// <summary>
	/// Return events with ID greater than this value.
	/// </summary>
	[AliasAs("id__gt")]
	public long? IdGt { get; init; }

	/// <summary>
	/// Return events with ID greater than or equal to this value.
	/// </summary>
	[AliasAs("id__gte")]
	public long? IdGte { get; init; }

	/// <summary>
	/// The field to order results by.
	/// </summary>
	[AliasAs("order_by")]
	public string? OrderBy { get; init; }
}
