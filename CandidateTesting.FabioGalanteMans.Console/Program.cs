using CandidateTesting.FabioGalanteMans.Console.DependencyInjection;
using CandidateTesting.FabioGalanteMans.Console.Services.File;
using CandidateTesting.FabioGalanteMans.Console.Services.Rest;
using CandidateTesting.FabioGalanteMans.Console.Services.Split;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine(Figgle.FiggleFonts.Standard.Render("iTaaS Convert Logs"));

var urls = Environment.GetCommandLineArgs() ?? throw new ArgumentNullException("Environment.GetCommandLineArgs()");

var serviceCollection = new ServiceCollection();
serviceCollection.AddServices();
var serviceProvider = serviceCollection.BuildServiceProvider();
var restService = serviceProvider.GetService<IRestService>();
var splitService = serviceProvider.GetService<ISplitService>();
var iFileService = serviceProvider.GetService<IFileService>();
var sourceUrl = urls[1];
var targetPath = urls[2];
//var result = await restService?.ReadLog(sourceUrl)!;


var result = await restService.ReadLogs(sourceUrl);






if (!string.IsNullOrEmpty(result))
{
   var logs = splitService?.SplitAgoraLogs(result);
   var logsTransformed = iFileService?.TransformAndSave(logs,targetPath);
   Console.WriteLine(logsTransformed);
}
else
    throw new ArgumentNullException("Invalid Logs");






