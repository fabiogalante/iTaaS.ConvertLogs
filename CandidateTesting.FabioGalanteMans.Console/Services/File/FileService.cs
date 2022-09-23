using System.Text;
using CandidateTesting.FabioGalanteMans.Console.Model;

namespace CandidateTesting.FabioGalanteMans.Console.Services.File
{
    public class FileService : IFileService
    {
        public string TransformAndSave(IEnumerable<AgoraLog> agoraLogs, string targetPath)
        {

            var contents = new StringBuilder();
            contents.Append($"#Version: 1.0 {Environment.NewLine}");
            contents.Append($"#Date: {DateTime.Now} {Environment.NewLine}");
            contents.Append($"#Fields: provider http-method status-code uri-path time-taken response-size cache-status {Environment.NewLine}");

            foreach (var agoraLog in agoraLogs)
            {
                contents.Append(
                    $"{agoraLog.Provider} {agoraLog.HttpMethod} {agoraLog.StatusCode} {agoraLog.FileName} {agoraLog.LogCode} {agoraLog.Key} {agoraLog.Code} {Environment.NewLine}");
            }

            Directory.CreateDirectory(targetPath);
            var pathString = Path.Combine(targetPath, "minhaCdn1.txt");
            System.IO.File.WriteAllText(pathString, contents.ToString()); 

            return contents.ToString();
        }
    }
}
