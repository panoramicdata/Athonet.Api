namespace Athonet.Api;

public class AthonetClient : IDisposable
{
	private bool disposedValue;
	private readonly HttpClient _httpClient;
	private readonly ILogger? _logger;
	private readonly AuthenticatedHttpHandler _authenticatedHttpHandler;

	public AthonetClient(AthonetClientOptions options, ILogger? logger = null)
	{
		// Validation
		if (options is null)
		{
			throw new ArgumentNullException(nameof(options));
		}

		options.Validate();

		_logger = logger ?? new NullLogger<AthonetClient>();

		_authenticatedHttpHandler = new AuthenticatedHttpHandler(
			options,
			_logger);
		_authenticatedHttpHandler.ClientCertificates.Add(options.Certificate);
		_authenticatedHttpHandler.ClientCertificateOptions = ClientCertificateOption.Manual;

		_httpClient = new HttpClient(_authenticatedHttpHandler)
		{
			BaseAddress = new Uri($"https://{options.Hostname}:{options.Port}"),
		};

		_httpClient.DefaultRequestHeaders.Add("X-MOGWAPI-AUTH", $"{options.Username}:{options.Password}");
		_httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
		_httpClient.DefaultRequestHeaders.Add("User-Agent", options.UserAgent);
		_logger.LogTrace("{Message}", "Constructor complete");

		JsonConvert.DefaultSettings = () => new JsonSerializerSettings
		{
			Converters = { new StringEnumConverter() }
		};

		var refitSettings = new RefitSettings
		{
			UrlParameterFormatter = new CustomUrlParameterFormatter(),
			ContentSerializer = new NewtonsoftJsonContentSerializer(
				new JsonSerializerSettings { Converters = { new StringEnumConverter() } }
			)
		};

		Hss = RestService.For<IHss>(_httpClient, refitSettings);
		Mogw = RestService.For<IMogw>(_httpClient, refitSettings);
	}

	/// <summary>
	/// The last HTTP request if AthonetClientOptions.StoreLastRequestAndResponse is true.
	/// </summary>
	public string? LastHttpRequest
		=> _authenticatedHttpHandler.LastHttpRequest;

	/// <summary>
	/// The last HTTP response if AthonetClientOptions.StoreLastRequestAndResponse is true.
	/// </summary>
	public string? LastHttpResponse
		=> _authenticatedHttpHandler.LastHttpResponse;

	public IHss Hss { get; }

	public IMogw Mogw { get; }

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				_httpClient?.Dispose();
				_authenticatedHttpHandler?.Dispose();
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
