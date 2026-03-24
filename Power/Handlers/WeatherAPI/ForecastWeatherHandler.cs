using MediatR;
using Power.Models.WeatherAPI;
using Power.Request;
using WeatherAPI.Services;

namespace Power.Handlers.WeatherAPI
{
    /// <summary>
    /// Хендлер медиатора для обработки прогноза погоды
    /// </summary>
    public class ForecastWeatherHandler : IRequestHandler<ForecastWeatherRequest, ForecastWeatherAPIResponseDTO>
    {
        private readonly WeatherAPIService weatherAPIService;
        private readonly ILogger<CurrentWeatherHandler> logger;
        /// <summary>
        /// Конструктор для погоды в прогнозе
        /// </summary>
        /// <param name="weatherAPIService"></param>
        /// <param name="logger"></param>
        public ForecastWeatherHandler(WeatherAPIService weatherAPIService, ILogger<CurrentWeatherHandler> logger)
        {
            this.weatherAPIService = weatherAPIService;
            this.logger = logger;
        }
        /// <summary>
        /// Обработка запроса через медиатор пришедшего
        /// </summary>
        /// <param name="request">Параметры запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO ответа от сервиса</returns>
        public async Task<ForecastWeatherAPIResponseDTO> Handle(ForecastWeatherRequest request, CancellationToken cancellationToken)
        {
            return await weatherAPIService.GetWeatherForecast(request.Days);
        }
    }
}
