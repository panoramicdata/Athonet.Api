namespace Athonet.Api.Data.Mogw;

[DataContract]
public class Ecgi
{
    [DataMember(Name = "plmn")]
    public string Plmn { get; set; } = string.Empty;

    [DataMember(Name = "cellid")]
    public int Cellid { get; set; }
}
