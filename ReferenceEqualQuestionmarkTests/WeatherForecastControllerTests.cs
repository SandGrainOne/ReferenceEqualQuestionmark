using System;
using System.Collections.Generic;

using Moq;

using ReferenceEqualQuestionmark;
using ReferenceEqualQuestionmark.Controllers;

using Xunit;

namespace ReferenceEqualQuestionmarkTests
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void AssertTheSameMemorySpace()
        {
            // Arrange
            List<WeatherForecast> weather = new List<WeatherForecast> { new WeatherForecast { Date = DateTime.Now } };

            Mock<IWeatherForecastService> mock = new Mock<IWeatherForecastService>();
            mock.Setup(s => s.GetWeatherForecast()).Returns(weather);

            var target = new WeatherForecastController(mock.Object);

            // Act
            var actual = target.Get() as List<WeatherForecast>;

            // Assert
            Assert.True(ReferenceEquals(weather, actual));

            // This means any changes to weather will also happen to actual:
            weather.Add(new WeatherForecast());

            // They will always be identical. 
            Assert.Equal(weather[1].Date, actual[1].Date);
        }
    }
}
