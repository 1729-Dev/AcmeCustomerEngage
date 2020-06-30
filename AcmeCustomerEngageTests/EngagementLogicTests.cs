using AcmeCustomerEngage.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AcmeCustomerEngage.Tests
{
    [TestClass()]
    public class EngagementLogicTests
    {
        private const string Phone = "Phone";
        private const string Email = "Email";
        private const string Text = "Text";
        private const string None = "None";

        private DateTime dateTime = DateTime.Now;

        private const float tempBelow55 = 54.9F;
        private const float tempExactly55 = 55F;
        private const float tempAbove55 = 55.1F;
        private const float tempBelow75 = 74.9F;
        private const float tempExactly75 = 75F;
        private const float tempAbove75 = 75.1F;

        #region Below55

        [TestMethod]
        public void Below55Raining()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempBelow55, Sunny: false, Raining: true);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Phone);
        }

        [TestMethod]
        public void Below55Sunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempBelow55, Sunny: true, Raining: false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Phone);
        }

        [TestMethod]
        public void Below55NeitherRainingNorSunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempBelow55, false, false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Phone);
        }

        #endregion Below55

        #region Exactly55

        [TestMethod]
        public void Exactly55Raining()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempExactly55, Sunny: false, Raining: true);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        [TestMethod]
        public void Exactly55Sunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempExactly55, Sunny: true, Raining: false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        [TestMethod]
        public void Exactly55NeitherRainingNorSunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempExactly55, false, false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        #endregion Exactly55

        #region Above55

        [TestMethod]
        public void Above55Raining()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempAbove55, Sunny: false, Raining: true);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        [TestMethod]
        public void Above55Sunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempAbove55, Sunny: true, Raining: false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        [TestMethod]
        public void Above55NeitherRainingNorSunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempAbove55, false, false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        #endregion Above55

        #region Below75

        [TestMethod]
        public void Below75Raining()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempBelow75, Sunny: false, Raining: true);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        [TestMethod]
        public void Below75Sunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempBelow75, Sunny: true, Raining: false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        [TestMethod]
        public void Below75NeitherRainingNorSunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempBelow75, false, false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        #endregion Below75

        #region Exactly75

        [TestMethod]
        public void Exactly75Raining()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempExactly75, Sunny: false, Raining: true);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        [TestMethod]
        public void Exactly75Sunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempExactly75, Sunny: true, Raining: false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        [TestMethod]
        public void Exactly75NeitherRainingNorSunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempExactly75, false, false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Email);
        }

        #endregion Exactly75

        #region Above75

        [TestMethod]
        public void Above75Raining()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempAbove75, Sunny: false, Raining: true);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Phone);
        }

        [TestMethod]
        public void Above75Sunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempAbove75, Sunny: true, Raining: false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, Text);
        }

        [TestMethod]
        public void Above75NeitherRainingNorSunny()
        {
            // Arrange
            WeatherModel weatherSnapShot = new WeatherModel(dateTime, tempAbove75, false, false);

            // Act
            string message = EngagementLogic.CommunicationMethod(weatherSnapShot);

            // Assert
            Assert.AreEqual(message, None);
        }

        #endregion Above75

        #region WeatherSnapshotsQuantity

        [TestMethod()]
        public void NoWeatherSnapshots()
        {
            // Arrange
            List<WeatherModel> weather = new List<WeatherModel>();

            // Act
            string preMessage = EngagementLogic.WeatherSnapshotsQuantity(weather);

            // Assert
            Assert.AreEqual("Error - no weather snapshots available to display.", preMessage);
        }

        [TestMethod()]
        public void WeatherSnapshotsLessThanFiveDays()
        {
            // Arrange
            List<WeatherModel> weather = new List<WeatherModel>()
            {
                new WeatherModel(dateTime.AddDays(1), tempExactly55),
                new WeatherModel(dateTime.AddDays(2), tempAbove75, true),
                new WeatherModel(dateTime.AddDays(3), tempExactly75, false, true),
                new WeatherModel(dateTime.AddDays(4), tempAbove75)
            };

            // Act
            string preMessage = EngagementLogic.WeatherSnapshotsQuantity(weather);

            // Assert
            Assert.AreEqual("Warning - less than 5 days of weather snapshots available to display.", preMessage);
        }

        [TestMethod()]
        public void WeatherSnapshotsFiveDaysReturnsNull()
        {
            // Arrange
            List<WeatherModel> weather = new List<WeatherModel>()
            {
                new WeatherModel(dateTime.AddDays(1), tempExactly55),
                new WeatherModel(dateTime.AddDays(2), tempAbove75, true),
                new WeatherModel(dateTime.AddDays(3), tempExactly75, false, true),
                new WeatherModel(dateTime.AddDays(4), tempAbove75),
                new WeatherModel(dateTime.AddDays(5), tempBelow55, true)
            };

            // Act
            string preMessage = EngagementLogic.WeatherSnapshotsQuantity(weather);

            // Assert
            Assert.IsNull(preMessage);
        }

        #endregion WeatherSnapshotsQuantity

        #region TrimWeather

        [TestMethod()]
        public void RemoveTodaysWeatherSnapshots()
        {
            DateTime today = DateTime.Now;
            const int expectedSnapshotCount = 5;

            // Arrange
            List<WeatherModel> weather = new List<WeatherModel>()
            {
                new WeatherModel(today, tempAbove75),
                new WeatherModel(dateTime.AddDays(1), tempExactly55),
                new WeatherModel(dateTime.AddDays(2), tempAbove75, true),
                new WeatherModel(dateTime.AddDays(3), tempExactly75, false, true),
                new WeatherModel(dateTime.AddDays(4), tempAbove75),
                new WeatherModel(dateTime.AddDays(5), tempBelow55, true)
            };

            // Act
            List<WeatherModel> trimmedWeather = EngagementLogic.TrimWeatherSnapshots(weather);

            // Assert
            Assert.IsNull(trimmedWeather.Find(x => x.Start.Date.Equals(today.Date)));
            Assert.AreEqual(expectedSnapshotCount, trimmedWeather.Count);
        }

        [TestMethod()]
        public void RemoveBeyondFiveDaysWeatherSnapshots()
        {
            const int expectedSnapshotCount = 5;

            // Arrange
            List<WeatherModel> weather = new List<WeatherModel>()
            {
                new WeatherModel(dateTime.AddDays(1), tempExactly55),
                new WeatherModel(dateTime.AddDays(2), tempAbove75, true),
                new WeatherModel(dateTime.AddDays(3), tempExactly75, false, true),
                new WeatherModel(dateTime.AddDays(4), tempAbove75),
                new WeatherModel(dateTime.AddDays(5), tempBelow55, true),
                new WeatherModel(dateTime.AddDays(6), tempExactly55, false, true)
            };

            // Act
            List<WeatherModel> trimmedWeather = EngagementLogic.TrimWeatherSnapshots(weather);

            // Assert
            Assert.IsNull(trimmedWeather.Find(x => x.Start.Date.Equals(dateTime.AddDays(6).Date)));
            Assert.AreEqual(expectedSnapshotCount, trimmedWeather.Count);
        }

        #endregion TrimWeather
    }
}