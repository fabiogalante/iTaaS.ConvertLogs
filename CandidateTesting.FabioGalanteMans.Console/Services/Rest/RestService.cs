namespace CandidateTesting.FabioGalanteMans.Console.Services.Rest;
public class RestService : IRestService
{

    public async Task<string?> ReadLogs(string sourceUrl)
    {
        var httpClient = new HttpClient();
        var responseMessage = await httpClient.GetAsync(sourceUrl);
        if (responseMessage.IsSuccessStatusCode)
            return await responseMessage.Content.ReadAsStringAsync();
        return null;
    }
}