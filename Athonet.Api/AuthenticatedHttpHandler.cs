using Athonet.Api.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
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
		private readonly AthonetClientOptions _options;

		public string? LastHttpRequest { get; private set; }

		public string? LastHttpResponse { get; private set; }

		public AuthenticatedHttpHandler(AthonetClientOptions options, ILogger logger)
		{
			_logger = logger;
			_options = options;
			if (options.IgnoreSslCertificateErrors)
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
				if (_options.StoreLastRequestAndResponse)
				{
					LastHttpRequest = request.ToString();
					if (request.Content != null)
					{
						LastHttpRequest += $"\n{await request.Content.ReadAsStringAsync().ConfigureAwait(false)}";
					}
				}

				_logger.LogTrace($"{guid}: Request starting");

				var requestCleaned = string.Join("\n", request
					.ToString()
					.Split('\n')
					.Select(line => line.StartsWith("  X-MOGWAPI-AUTH") ? "  X-MOGWAPI-AUTH: XXXXXXXXXXXXXX" : line)
				);

				_logger.LogDebug($"{guid}: Request\n{requestCleaned}");

				var response = await base
					.SendAsync(request, cancellationToken)
					.ConfigureAwait(false);

				_logger.LogDebug($"{guid}: Response ({response.StatusCode})\n{await response.Content.ReadAsStringAsync().ConfigureAwait(false)}");

				if (_options.StoreLastRequestAndResponse)
				{
					LastHttpResponse = response.ToString();
					if (response.Content != null)
					{
						LastHttpResponse += $"\n{await response.Content.ReadAsStringAsync().ConfigureAwait(false)}";
					}
				}

				if (response.IsSuccessStatusCode)
				{
					return response;
				}
				// Failure

				_logger.LogDebug($"{guid}: Failure code ({response.StatusCode})");

				var responseBody = response
					.Content is null
						? null
						: await response
							.Content
							.ReadAsStringAsync()
							.ConfigureAwait(false);

				throw new AthonetApiException(response.StatusCode, responseBody ?? string.Empty);
			}
			catch (AthonetApiException)
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