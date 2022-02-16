namespace Athonet.Api.Data.Mogw;

[DataContract]
public class GlobalENodeBId
{
    [DataMember(Name = "plmn")]
    public string Plmn { get; set; } = string.Empty;

    [DataMember(Name = "homeENBid")]
    public int HomeENodeBId { get; set; }
}
