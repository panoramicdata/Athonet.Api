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
			[Query] string? imsi = null,
			[Query] string? imei = null,
			[Query] long? from = null,
			[Query] long? to = null,
			[Query] string? type = null,
			[Query] string? layer = null,
			[Query] string? id = null,
			[Query] string? id__gt = null,
			[Query] string? id__gte = null,
			[Query] string? orderBy = null,
			CancellationToken cancellationToken = default);
	}
}
