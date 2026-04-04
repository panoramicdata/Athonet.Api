namespace Athonet.Api.Data;

/// <summary>
/// A paginated result set.
/// </summary>
/// <typeparam name="T">The type of items in the page.</typeparam>
[DataContract]
public class Page<T>
{
	/// <summary>
	/// The total count of items.
	/// </summary>
	[DataMember(Name = "count")]
	public int Count { get; set; }

	/// <summary>
	/// The URL for the next page of results.
	/// </summary>
	[DataMember(Name = "next")]
	public string? Next { get; set; }

	/// <summary>
	/// The URL for the previous page of results.
	/// </summary>
	[DataMember(Name = "previous")]
	public string? Previous { get; set; }

	/// <summary>
	/// The result items.
	/// </summary>
	[DataMember(Name = "results")]
	public IList<T> Results { get; set; } = null!;
}
