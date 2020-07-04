using Athonet.Api.Data;
using Athonet.Api.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Athonet.Api
{
	internal class AuthenticatedHttpHandler : HttpClientHandler
	{
		private readonly ILogger _logger;

		public AuthenticatedHttpHandler(bool ignoreSslCertificateErrors, ILogger logger)
		{
			_logger = logger;
			if (ignoreSslCertificateErrors)
			{
				ServerCertificateCustomValidationCallback = DangerousAcceptAnyServerCertificateValidator;
			}
		}

		private bool DangerousAcceptAnyServerCertificateValidator(
			HttpRequestMessage arg1,
			X509Certificate2 arg2,
			X509Chain arg3,
			SslPolicyErrors arg4)
			=> true;

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var guid = Guid.NewGuid();
			try
			{
				_logger.LogTrace($"{guid}: Request starting");

				_logger.LogDebug($"{guid}: Request\n{request}");

				var response = await base
					.SendAsync(request, cancellationToken)
					.ConfigureAwait(false);

				_logger.LogDebug($"{guid}: Response ({response.StatusCode})\n{await response.Content.ReadAsStringAsync().ConfigureAwait(false)}");

				if (response.IsSuccessStatusCode)
				{
					return response;
				}
				// Failure

				_logger.LogDebug($"{guid}: Failure code ({response.StatusCode})");
				var responseBody = await response
					.Content
					.ReadAsStringAsync()
					.ConfigureAwait(false);
				var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
				throw new AthonetApiException(errorResponse);
			}
			catch(AthonetApiException)
			{
				throw;
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);
				throw;
			}
			finally
			{
				_logger.LogTrace($"{guid}: Request complete");
			}
		}
	}
}