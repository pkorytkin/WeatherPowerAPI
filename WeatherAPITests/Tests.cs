using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using WeatherAPI.Services;

namespace WeatherAPITests
{
    public class Tests
    {
        static WeatherAPIService service;
        /// <summary>
        /// Готовим сервис из библиотеки
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var loggerMock = new Mock<ILogger<WeatherAPIService>>(MockBehavior.Default);
            Dictionary<string, string?> dict = new Dictionary<string, string?>
            {
                //Нужно указать API ключ
                { "WeatherAPI:APIKey", "" }
            };

            var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(dict)
            .Build();
            service = new WeatherAPIService(loggerMock.Object, configuration);
        }
        /// <summary>
        /// Тест на проверку что ответ от апи приходит
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestForecastNotNull()
        {
            // Act

            var result = await service.GetWeatherForecast();
            // Assert

            Assert.That(result, Is.Not.Null);
        }
        /// <summary>
        /// Тест на проверку что ответ от апи приходит
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestCurrentNotNull()
        {
            // Act
            var result = await service.GetCurrentWeather();
            // Assert
            Assert.That(result, Is.Not.Null);
        }
        /// <summary>
        /// Тест на проверку что ответ от апи приходит на нужное число дней 1
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestForecastDays()
        {
            // Act
            var result = await service.GetWeatherForecast(days: 1);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.forecast, Is.Not.Null);
            Assert.That(result.forecast.forecastday, Is.Not.Null);
            Assert.That(result.forecast.forecastday.Count == 1, Is.True);
        }
        /// <summary>
        /// Тест на проверку что ответ от апи приходит на нужное число дней 3
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestForecastDays3()
        {
            // Act

            var result = await service.GetWeatherForecast(days: 3);
            // Assert

            Assert.That(result, Is.Not.Null);
            Assert.That(result.forecast, Is.Not.Null);
            Assert.That(result.forecast.forecastday, Is.Not.Null);
            Assert.That(result.forecast.forecastday.Count == 3, Is.True);
        }
    }
}