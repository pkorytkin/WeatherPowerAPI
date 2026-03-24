using MediatR;
using Power.Models.WeatherAPI;
using Power.Request;
using WeatherAPI.Services;

namespace Power.Handlers.WeatherAPI
{
    /// <summary>
    /// Хендлер для погоды сейчас
    /// </summary>
    public class CurrentWeatherHandler : IRequestHandler<CurrentWeatherRequest, CurrentWeatherAPIResponseDTO>
    {
        private readonly WeatherAPIService weatherAPIService;
        private readonly ILogger<CurrentWeatherHandler> logger;
        /// <summary>
        /// Конструктор для погоды сейчас
        /// </summary>
        /// <param name="weatherAPIService"></param>
        /// <param name="logger"></param>
        public CurrentWeatherHandler(WeatherAPIService weatherAPIService, ILogger<CurrentWeatherHandler> logger)
        {
            this.weatherAPIService = weatherAPIService;
            this.logger = logger;
        }
        /// <summary>
        /// Обработка
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CurrentWeatherAPIResponseDTO> Handle(CurrentWeatherRequest request, CancellationToken cancellationToken)
        {
            return await weatherAPIService.GetCurrentWeather();
        }
    }
}
