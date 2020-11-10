using Athonet.Api.Data;
using System;
using System.Net;

namespace Athonet.Api.Exceptions
{
	public class AthonetApiException : Exception
	{
		public ErrorResponse? ErrorResponse { get; }

		public HttpStatusCode HttpStatusCode { get; }

		public string ResponseBody { get; }

		internal AthonetApiException(HttpStatusCode httpStatusCode, string message, string responseBody) : base(message)
		{
			HttpStatusCode = httpStatusCode;
			ResponseBody = responseBody;
		}

		internal AthonetApiException(HttpStatusCode httpStatusCode, ErrorResponse errorResponse, string responseBody) : base(errorResponse.Message)
		{
			ErrorResponse = errorResponse;
			HttpStatusCode = httpStatusCode;
			ResponseBody = responseBody;
		}
	}
}
