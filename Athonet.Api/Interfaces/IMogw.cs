namespace Athonet.Api.Interfaces;

/// <summary>
/// MoGW (Mobile Gateway) API interface.
/// </summary>
public interface IMogw
{
	/// <summary>
	/// Get MoGW Events
	/// </summary>
	/// <param name="query">The filter criteria. Null properties are omitted from the query string.</param>
	/// <param name="cancellationToken">The CancellationToken</param>
	[Get("/API/mogw/events")]
	Task<MogwEventSet> GetEventsAsync(
		[Query] MogwEventQuery query,
		CancellationToken cancellationToken);
}
