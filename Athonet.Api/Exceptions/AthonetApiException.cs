using Athonet.Api.Data;
using System;

namespace Athonet.Api.Exceptions
{
	public class AthonetApiException : Exception
	{
		public ErrorResponse ErrorResponse { get; }

		internal AthonetApiException(ErrorResponse errorResponse) : base(errorResponse.Message)
		{
			ErrorResponse = errorResponse;
		}
	}
}
