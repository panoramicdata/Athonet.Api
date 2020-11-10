using System.Runtime.Serialization;

namespace Athonet.Api.Data
{
	/// <summary>
	/// An error response
	/// </summary>
	[DataContract]
	public class ErrorResponse
	{
		/// <summary>
		/// The error code
		/// </summary>
		[DataMember(Name = "error")]
		public int ErrorCode { get; set; }

		/// <summary>
		/// The error message
		/// </summary>
		[DataMember(Name = "message")]
		public string Message { get; set; } = string.Empty;
	}
}
