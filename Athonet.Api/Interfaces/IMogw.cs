using Athonet.Api.Data.Mogw;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Athonet.Api.Interfaces
{
	public interface IMogw
	{
		/// <summary>
		/// Get MoGW Events
		/// </summary>
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
}
