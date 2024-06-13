using Microsoft.Extensions.Logging;
using Moq;
using SmartyStreets.Functions.Configuration;
using SmartyStreets.Functions.Services;

namespace SmartyStreets.Functions.Test
{
    public class UnitTest1
    {
        private SmartyService _service;
        private ISmartyConfiguration _configuration;
        private Mock<IHttpClientFactory> _mockHttpClientFactory;
        private Mock<ILogger<SmartyService>> _mockLogger;

        [Fact]
        public async Task SearchAddressTest()
        {            
            _configuration = new SmartyConfiguration();
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(new HttpClient());
            _mockLogger = new Mock<ILogger<SmartyService>>();
            _service = new SmartyService(_configuration, _mockHttpClientFactory.Object, _mockLogger.Object);

            var testAddress = "4192 Riverboat Rd, Salt Lake City, UT";

            var result = await _service.SearchAddressAsync(testAddress);

            Assert.NotNull(result);
            Assert.Single(result.Suggestions);
            Assert.Equal("84123", result.Suggestions.First().ZipCode);
        }

        [Fact]
        public async Task ValidateAddressTest()
        {
            _configuration = new SmartyConfiguration();
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(new HttpClient());
            _mockLogger = new Mock<ILogger<SmartyService>>();
            _service = new SmartyService(_configuration, _mockHttpClientFactory.Object, _mockLogger.Object);

            var testAddress = new Models.Address
            {
                City = "Salt Lake City",
                State = "UT",
                StreetName = "4192 Riverboat"
            };

            var result = await _service.ValidateAddress(testAddress);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("84123", result.First().Address.ZipCode);
        }
    }
}