namespace CandidateTesting.FabioGalanteMans.Console.Model;

public class AgoraLog
{
    public AgoraLog()
    {
        Provider = "\"MINHA CDN\"";
    }

    public string? Provider { get; }
    public string? Key { get; set; }
    public string? HttpMethod { get; set; }
    public string? StatusCode { get; set; }
    public string? Code { get; set; }
    public string? LogCode { get; set; }
    public string? FileName { get; set; }
}