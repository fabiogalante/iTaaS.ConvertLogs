namespace CandidateTesting.FabioGalanteMans.Console.Services.Rest;
public interface IRestService
{
    Task<Stream?> ReadLog(string sourceUrl);
    Task<string?> ReadLogs(string sourceUrl);
}