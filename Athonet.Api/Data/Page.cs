namespace Athonet.Api.Data;

/// <summary>
/// A paginated result set.
/// </summary>
/// <typeparam name="T">The type of items in the page.</typeparam>
public class Page<T>
{
	/// <summary>
	/// The total count of items.
	/// </summary>
	[JsonPropertyName("count")]
	public int Count { get; set; }

	/// <summary>
	/// The URL for the next page of results.
	/// </summary>
	[JsonPropertyName("next")]
	public string? Next { get; set; }

	/// <summary>
	/// The URL for the previous page of results.
	/// </summary>
	[JsonPropertyName("previous")]
	public string? Previous { get; set; }

	/// <summary>
	/// The result items.
	/// </summary>
	[JsonPropertyName("results")]
	public IList<T> Results { get; set; } = null!;
}
