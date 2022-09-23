﻿using CandidateTesting.FabioGalanteMans.Console.Model;

namespace CandidateTesting.FabioGalanteMans.Console.Services.Split
{
    public class SplitService : ISplitService
    {

        public IEnumerable<AgoraLog> SplitAgoraLogs(string? logs)
        {
            using var sr = new StringReader(logs);
            string? lineLog = string.Empty;
            var lines = new List<string?>();
            int count = 0;
            while ((lineLog = sr.ReadLine()) != null)
            {
                count++;
               lines.Add(lineLog);
            }

            var logsTransformed = new List<AgoraLog>();
            foreach (var line in lines)
            {
                var agoraLog = Transform(line);
                logsTransformed.Add(agoraLog);
            }



            return logsTransformed;
        }


        public IEnumerable<AgoraLog> Split(Stream stream)
        {
            var lines = new List<string?>();

            using var streamReader = new StreamReader(stream);
            while (streamReader.ReadLine() is { } line)
                lines.Add(line);


            var logsTransformed = new List<AgoraLog>();
            foreach (var line in lines)
            {
                var agoraLog = Transform(line);
                logsTransformed.Add(agoraLog);
            }



            return logsTransformed;

            
        }

        private AgoraLog Transform(string? log)
        {
            string[] split = log?.Split('|');

            var agoraLog = new AgoraLog
            {
                Key = split?[0],
                StatusCode = split?[1],
                Code = split?[2],
                LogCode = (split?[4])[..3]
            };

            var nameFileAndVerb = split?[3]
                .Replace("\"", "")
                .Split(' ');
            agoraLog.HttpMethod = nameFileAndVerb?[0];
            agoraLog.FileName = nameFileAndVerb?[1];
            return agoraLog;


            
            //312|200|HIT|"GET /robots.txt HTTP/1.1"|100.2
            //GET 200 /robots.txt 100 312 HIT"
            //"MINHA CDN" GET 200 /robots.txt 100 312 HIT
        }
    }
}
