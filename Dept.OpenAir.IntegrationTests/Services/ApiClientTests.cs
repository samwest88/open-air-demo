using Dept.OpenAir.Services;
using Dept.OpenAir.Web.Business.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace Dept.OpenAir.IntegrationTests
{
    /// <summary>
    /// Integration tests for our Api Client
    /// TODO: These just test the happy-path at the moment - some ones where we can get API errors to occur would be good
    /// TODO: Add unit testing into seperate project so we don't have to hit actual endpoints to test logging etc. 
    /// </summary>
    [TestClass]
    public class ApiClientTests
    {
        [TestMethod]
        public async Task GetCities_Success()
        {
            //Arrange
            var config = new Mock<IConfiguration>(MockBehavior.Strict);
            config.Setup(x => x.GetSection(ConfigurationConstants.ApiPrefix).Value).Returns("https://docs.openaq.org/v2");
            var client = new ApiClient(config.Object, new Mock<ILogger<ApiClient>>().Object);
            
            //Act
            var result = await client.GetCities();

            //Assert : Check we have some results
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Results?.Any());

            //Assert : Check our deserialization of a nested property
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Results?.First().Country));
        }

        [TestMethod]
        public async Task GetMeasurements_Success()
        {
            //Arrange
            var config = new Mock<IConfiguration>(MockBehavior.Strict);
            config.Setup(x => x.GetSection(ConfigurationConstants.ApiPrefix).Value).Returns("https://docs.openaq.org/v2");
            var client = new ApiClient(config.Object, new Mock<ILogger<ApiClient>>().Object);
            var city = "Southampton";

            //Act
            var result = await client.GetMeasurements(city);

            //Assert : Check we have some results & that they contain our requested city
            Assert.IsNotNull(result);
            Assert.AreEqual(city, result.Results?.First().City);
        }
    }
}