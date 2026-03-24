using MediatR;
using Power.Models.WeatherAPI;
using Power.Request;
using WeatherAPI.Services;

namespace Power.Handlers.WeatherAPI
{
    public class ForecastWeatherHandler : IRequestHandler<ForecastWeatherRequest, ForecastWeatherAPIResponseDTO>
    {
        private readonly WeatherAPIService weatherAPIService;
        private readonly ILogger<CurrentWeatherHandler> logger;

        public ForecastWeatherHandler(WeatherAPIService weatherAPIService, ILogger<CurrentWeatherHandler> logger)
        {
            this.weatherAPIService = weatherAPIService;
            this.logger = logger;
        }

        public async Task<ForecastWeatherAPIResponseDTO> Handle(ForecastWeatherRequest request, CancellationToken cancellationToken)
        {
            return await weatherAPIService.GetWeatherForecast(request.Days);
        }
    }
}
