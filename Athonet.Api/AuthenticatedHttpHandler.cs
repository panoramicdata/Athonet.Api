namespace Athonet.Api;

internal sealed class AuthenticatedHttpHandler : HttpClientHandler
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

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var guid = Guid.NewGuid();
		try
		{
			await LogRequestAsync(guid, request, cancellationToken).ConfigureAwait(false);

			var response = await base
				.SendAsync(request, cancellationToken)
				.ConfigureAwait(false);

			var content = await LogResponseAsync(guid, response, cancellationToken).ConfigureAwait(false);

			return response.IsSuccessStatusCode
				? response
				: throw new AthonetApiException(response.StatusCode, content);
		}
		// AthonetApiException is the handler's own signal for an unsuccessful response; it is
		// already logged by LogResponseAsync, so it is excluded here to avoid logging it twice.
		catch (Exception exception) when (exception is not AthonetApiException)
		{
			_logger.LogError(exception, "{Message}", exception.Message);
			throw;
		}
		finally
		{
			_logger.LogTrace("{Guid}: Request complete", guid);
		}
	}

	private async Task LogRequestAsync(Guid guid, HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (_options.StoreLastRequestAndResponse)
		{
			LastHttpRequest = request.ToString();
			if (request.Content is not null)
			{
				LastHttpRequest += $"\n{await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false)}";
			}
		}

		_logger.LogTrace("{Guid}: Request starting", guid);
		_logger.LogDebug("{Guid}: Request\n{RequestCleaned}", guid, RedactAuthHeader(request.ToString()));
	}

	private static string RedactAuthHeader(string request)
		=> string.Join("\n", request
			.Split('\n')
			.Select(line => line.StartsWith("  X-MOGWAPI-AUTH", StringComparison.Ordinal)
				? "  X-MOGWAPI-AUTH: XXXXXXXXXXXXXX"
				: line
			)
		);

	/// <summary>
	/// Logs the response and, when configured, stores it. Returns the response body.
	/// </summary>
	private async Task<string> LogResponseAsync(Guid guid, HttpResponseMessage response, CancellationToken cancellationToken)
	{
		var content = await response
			.Content
			.ReadAsStringAsync(cancellationToken)
			.ConfigureAwait(false);

		_logger.LogDebug("{Guid}: Response ({ResponseStatusCode})\n{Content}",
			guid,
			response.StatusCode,
			content
			);

		if (_options.StoreLastRequestAndResponse)
		{
			LastHttpResponse = $"{response}\n{content}";
		}

		if (!response.IsSuccessStatusCode)
		{
			_logger.LogDebug("{Guid}: Failure code ({ResponseStatusCode})",
				guid,
				response.StatusCode);
		}

		return content;
	}
}
