namespace Athonet.Api.Data;

[DataContract]
public class Page<T>
{
	[DataMember(Name = "count")]
	public int Count { get; set; }

	[DataMember(Name = "next")]
	public string? Next { get; set; }

	[DataMember(Name = "previous")]
	public string? Previous { get; set; }

	[DataMember(Name = "results")]
	public IList<T> Results { get; set; } = null!;
}
