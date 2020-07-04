using Athonet.Api.Data.Hss;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Athonet.Api.Interfaces
{
	public interface IHss
	{
		/// <summary>
		/// Get USIM profiles
		/// </summary>
		/// <param name="cancellationToken">The CancellationToken</param>
		[Get("/API/hss/usim-profiles")]
		Task<Page<UsimProfile>> GetUsimProfilesAsync(
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Get USIM profile by id
		/// </summary>
		/// <param name="id">The USIM profile ID</param>
		/// <param name="cancellationToken">The CancellationToken</param>
		[Get("/API/hss/usim-profiles/{usimProfileId}")]
		Task<UsimProfile> GetUsimProfileAsync(
			int usimProfileId,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Get APN profiles by USIM Profile ID
		/// </summary>
		/// <param name="usimProfileId">The USIM profile ID</param>
		/// <param name="cancellationToken">The CancellationToken</param>
		[Get("/API/hss/usim-profiles/{usimProfileId}/apn-profiles")]
		Task<Page<ApnProfile>> GetApnProfilesByUsimProfileIdAsync(
			int usimProfileId,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Get PLMNs by USIM Profile ID
		/// </summary>
		/// <param name="usimProfileId">The USIM profile ID</param>
		/// <param name="cancellationToken">The CancellationToken</param>
		[Get("/API/hss/usim-profiles/{usimProfileId}/plmns")]
		Task<Page<PublicLandMobileNetwork>> GetPublicLandMobileNetworksAsync(
			int usimProfileId,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Get Closed Subscriber Groups by USIM Profile ID
		/// </summary>
		/// <param name="usimProfileId">The USIM profile ID</param>
		/// <param name="cancellationToken">The CancellationToken</param>
		[Get("/API/hss/usim-profiles/{usimProfileId}/csgs-list")]
		Task<Page<ClosedSubscriberGroup>> GetClosedSubscriberGroupsAsync(
			int usimProfileId,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Get Teleservices by USIM Profile ID
		/// </summary>
		/// <param name="usimProfileId">The USIM profile ID</param>
		/// <param name="cancellationToken">The CancellationToken</param>
		[Get("/API/hss/usim-profiles/{usimProfileId}/teleservices")]
		Task<Page<Teleservice>> GetTeleservicesAsync(
			int usimProfileId,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Get Apns
		/// </summary>
		/// <param name="cancellationToken">The CancellationToken</param>
		[Get("/API/hss/apns")]
		Task<Page<Apn>> GetApnsAsync(
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Get Apns
		/// </summary>
		/// <param name="apnProfileId">The APN ID</param>
		/// <param name="cancellationToken">The CancellationToken</param>
		[Get("/API/hss/apns/{apnId}")]
		Task<Apn> GetApnAsync(
			int apnId,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Get Apn Profiles
		/// </summary>
		/// <param name="cancellationToken">The CancellationToken</param>
		[Get("/API/hss/apn-profiles")]
		Task<Page<ApnProfile>> GetApnProfilesAsync(
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Get Apn Profile by ID
		/// </summary>
		/// <param name="apnProfileId">The APN Profile ID</param>
		/// <param name="cancellationToken">The CancellationToken</param>
		[Get("/API/hss/apn-profiles/{apnProfileId}")]
		Task<ApnProfile> GetApnProfileAsync(
			int apnProfileId,
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Get APN by APN Profile ID
		/// </summary>
		/// <param name="apnProfileId">The APN Profile ID</param>
		/// <param name="cancellationToken">The CancellationToken</param>
		[Get("/API/hss/apn-profiles/{apnProfileId}/apn")]
		Task<Apn> GetApnByApnProfileIdAsync(
			int apnProfileId,
			CancellationToken cancellationToken = default);
	}
}
