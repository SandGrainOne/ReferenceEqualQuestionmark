using System.Collections.Generic;

namespace ReferenceEqualQuestionmark
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetWeatherForecast();
    }
}
