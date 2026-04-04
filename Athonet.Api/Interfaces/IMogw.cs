namespace Athonet.Api.Interfaces;

/// <summary>
/// MoGW (Mobile Gateway) API interface.
/// </summary>
public interface IMogw
{
	/// <summary>
	/// Get MoGW Events
	/// </summary>
	/// <param name="imsi">The IMSI to filter by.</param>
	/// <param name="imei">The IMEI to filter by.</param>
	/// <param name="from">The start timestamp to filter from.</param>
	/// <param name="to">The end timestamp to filter to.</param>
	/// <param name="limit">The maximum number of events to return.</param>
	/// <param name="type">The event type to filter by.</param>
	/// <param name="layer">The event layer to filter by.</param>
	/// <param name="id">The event ID to filter by.</param>
	/// <param name="idGt">Return events with ID greater than this value.</param>
	/// <param name="idGte">Return events with ID greater than or equal to this value.</param>
	/// <param name="orderBy">The field to order results by.</param>
	/// <param name="cancellationToken">The CancellationToken</param>
	[Get("/API/mogw/events")]
	Task<MogwEventSet> GetEventsAsync(
		[AliasAs("imsi")] string? imsi = null,
		[AliasAs("imei")] string? imei = null,
		[AliasAs("from")] long? from = null,
		[AliasAs("to")] long? to = null,
		[AliasAs("limit")] int? limit = null,
		[AliasAs("type")] EventType? type = null,
		[AliasAs("layer")] EventLayer? layer = null,
		[AliasAs("id")] long? id = null,
		[AliasAs("id__gt")] long? idGt = null,
		[AliasAs("id__gte")] long? idGte = null,
		[AliasAs("order_by")] string? orderBy = null,
		CancellationToken cancellationToken = default);
}