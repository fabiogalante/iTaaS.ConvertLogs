using System.CodeDom.Compiler;
using System.Text;
using CandidateTesting.FabioGalanteMans.Console.Model;
using CandidateTesting.FabioGalanteMans.Console.Services.File;
using CandidateTesting.FabioGalanteMans.Console.Services.Rest;
using CandidateTesting.FabioGalanteMans.Console.Services.Split;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Xunit;

namespace CandidateTesting.FabioGalanteMans.Testing.Services
{
    public class SplitTests
    {

        private readonly ISplitService _service = new SplitService();
        private readonly Mock<IFileService> _fileServiceMock = new();

        private string logs = @"312|200|HIT|""GET /robots.txt HTTP/1.1""|100.2
                        101|200|MISS|""POST /myImages HTTP/1.1""|319.4
                        199|404|MISS|""GET /not-found HTTP/1.1""|142.9
                        312|200|INVALIDATE|""GET /robots.txt HTTP/1.1""|245.1";




        [Fact]
        public void Should_SplitAgoraLogs_Null_Without_Logs()
        {
            var result = _service.SplitAgoraLogs(null);
            result.Should().BeNull();
        }


        [Fact]
        public void Should_SplitAgoraLogs_Logs()
        {
            var result =  _service.SplitAgoraLogs(logs);
            result.Should().AllBeOfType<AgoraLog>();
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterThan(0);
            result.First().FileName.Should().Be("/robots.txt");
            result.First().Should().Be("\"MINHA CDN\" GET 200 /robots.txt 100 312 HIT");
        }

    }
}