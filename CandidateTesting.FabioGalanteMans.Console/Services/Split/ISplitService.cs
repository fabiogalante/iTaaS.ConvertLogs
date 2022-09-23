using CandidateTesting.FabioGalanteMans.Console.Model;

namespace CandidateTesting.FabioGalanteMans.Console.Services.Split
{
    public interface ISplitService
    {
        IEnumerable<AgoraLog> Split(Stream stream);
        IEnumerable<AgoraLog> SplitAgoraLogs(string? logs);
    }
}
