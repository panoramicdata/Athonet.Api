using Athonet.Api.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Refit;
using System;
using System.Net.Http;

namespace Athonet.Api
{
	public class AthonetClient : IDisposable
	{
		private bool disposedValue;
		private readonly HttpClient _httpClient;
		private readonly ILogger? _logger;

		public AthonetClient(AthonetClientOptions options, ILogger? logger = null)
		{
			// Validation
			if (options is null)
			{
				throw new ArgumentNullException(nameof(options));
			}
			options.Validate();

			_logger = logger ?? new NullLogger<AthonetClient>();

			var authenticatedHttpHandler = new AuthenticatedHttpHandler(
				options.IgnoreSslCertificateErrors,
				_logger);
			authenticatedHttpHandler.ClientCertificates.Add(options.Certificate);
			authenticatedHttpHandler.ClientCertificateOptions = ClientCertificateOption.Manual;

			_httpClient = new HttpClient(authenticatedHttpHandler)
			{
				BaseAddress = new Uri($"https://{options.HssPcrfHaHostname}:446"),
			};
			_httpClient.DefaultRequestHeaders.Add("X-MOGWAPI-AUTH", $"{options.Username}:{options.Password}");
			_httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			_logger.LogTrace("Constructor complete");

			Hss = RestService.For<IHss>(_httpClient);
			Mogw = RestService.For<IMogw>(_httpClient);
		}

		public IHss Hss { get; }

		public IMogw Mogw { get; }

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_httpClient?.Dispose();
				}

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
