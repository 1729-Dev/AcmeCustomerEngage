using AcmeCustomerEngage.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using System.Net;

namespace AcmeCustomerEngage.Tests
{
    /* Having trouble getting the mock for the RestSharp library to return the
     * needed states to make these tests work.
     * */
    [TestClass()]
    public class WeatherServiceTests
    {
        [TestMethod]
        public void ServiceUnavailable()
        {
            // Arrange - Mock IRestClient to return Unauthorized
            var mock = new Mock<IRestClient>();
            mock.Setup(x => x.Execute(It.IsAny<RestRequest>()))
            .Returns(new RestResponse
            {
                StatusCode = HttpStatusCode.Unauthorized
            });

            // Act
            var request = new RestRequest();
            var response = mock.Object.Get<WeatherDTO>(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public void ResponseDataNull()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void StatusCodeNotOK()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void PayloadNull()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void PayloadMissingList()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ListItemInvalidDateTime()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ListItemMissingWeatherItem()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ListItemMissingMainItem()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void MainItemMissingTemp()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void WeatherItemMainIsNull()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void WeatherItemMissingTemperature()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void WeatherDetailNull()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void WeatherDetailListEmpty()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void WeatherDetailListMoreThanOneItem()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void RainingMissingIcon()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void RainingPositive()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void RainingNegative()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void SunnyMissingIcon()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void SunnyPositive()
        {
            // 01d.png, 02d.png
            Assert.Fail();
        }

        [TestMethod]
        public void SunnyNegative()
        {
            // We should not consider clear or partly cloudy skies at night to be 'sunny'
            // 01n.png, 02n.png, 03d.png, 03n.png
            Assert.Fail();
        }
    }
}