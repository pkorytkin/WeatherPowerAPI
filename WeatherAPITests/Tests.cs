using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using WeatherAPI.Services;

namespace WeatherAPITests
{
    public class Tests
    {
        static WeatherAPIService service;
        [SetUp]
        public void Setup()
        {
            var loggerMock = new Mock<ILogger<WeatherAPIService>>(MockBehavior.Default);
            var dict = new Dictionary<string, string>
            {
                //Нужно указать API ключ
                { "WeatherAPI:APIKey", "" }
            };

            var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(dict)
            .Build();
            service = new WeatherAPIService(loggerMock.Object, configuration);
        }

        [Test]
        public async Task TestForecastNotNull()
        {
            var result=await service.GetWeatherForecast();
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public async Task TestCurrentNotNull()
        {
            var result=await service.GetCurrentWeather();
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public async Task TestForecastDays()
        {
            var result=await service.GetWeatherForecast(days:1);
            Assert.That(result.forecast.forecastday.Count==1, Is.True);
        }
        [Test]
        public async Task TestForecastDays3()
        {
            var result=await service.GetWeatherForecast(days:3);
            Assert.That(result.forecast.forecastday.Count==3, Is.True);
        }
    }
}