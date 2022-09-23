namespace CandidateTesting.FabioGalanteMans.Console.Services.Rest;
public interface IRestService
{
    Task<string?> ReadLogs(string sourceUrl);
}