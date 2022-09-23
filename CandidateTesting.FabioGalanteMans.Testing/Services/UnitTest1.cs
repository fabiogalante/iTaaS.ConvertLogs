using System.Text;
using CandidateTesting.FabioGalanteMans.Console.Services.File;
using CandidateTesting.FabioGalanteMans.Console.Services.Rest;
using CandidateTesting.FabioGalanteMans.Console.Services.Split;
using Moq;
using Xunit;

namespace CandidateTesting.FabioGalanteMans.Testing.Services
{
    public class UnitTest1
    {
        private readonly Mock<IRestService> _restServiceMock = new();

        private readonly ISplitService _service = new SplitService();

        Stream _stream;


        public UnitTest1()
        {
            
        }



       [Fact]
        public void Test1()
        {
          

            


        }
    }
}