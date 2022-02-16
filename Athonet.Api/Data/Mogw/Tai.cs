namespace Athonet.Api.Data.Mogw;

[DataContract]
public class Tai
{
    [DataMember(Name = "plmn")]
    public string Plmn { get; set; } = string.Empty;

    [DataMember(Name = "tac")]
    public int Tac { get; set; }
}
