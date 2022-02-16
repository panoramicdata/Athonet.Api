namespace Athonet.Api.Exceptions;

public class AthonetApiException : Exception
{
    public HttpStatusCode HttpStatusCode { get; }

    public string ResponseBody { get; }

    internal AthonetApiException(HttpStatusCode httpStatusCode, string responseBody) : base(httpStatusCode.ToString())
    {
        HttpStatusCode = httpStatusCode;
        ResponseBody = responseBody;
    }
}
