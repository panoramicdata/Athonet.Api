namespace Athonet.Api.Exceptions;

/// <summary>
/// Exception thrown when an Athonet API call fails.
/// </summary>
public class AthonetApiException : Exception
{
	/// <summary>
	/// The HTTP status code returned by the API.
	/// </summary>
	public HttpStatusCode HttpStatusCode { get; }

	/// <summary>
	/// The response body returned by the API.
	/// </summary>
	public string ResponseBody { get; }

	internal AthonetApiException(HttpStatusCode httpStatusCode, string responseBody) : base(httpStatusCode.ToString())
	{
		HttpStatusCode = httpStatusCode;
		ResponseBody = responseBody;
	}
}