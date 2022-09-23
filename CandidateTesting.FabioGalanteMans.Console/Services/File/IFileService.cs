using CandidateTesting.FabioGalanteMans.Console.Model;

namespace CandidateTesting.FabioGalanteMans.Console.Services.File
{
    public interface IFileService
    {
        string TransformAndSave(IEnumerable<AgoraLog> agoraLogs, string targetPath);
    }
}
