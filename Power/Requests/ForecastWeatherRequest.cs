using MediatR;
using Power.Models.WeatherAPI;
namespace Power.Request
{
    public class ForecastWeatherRequest : IRequest<ForecastWeatherAPIResponseDTO>
    {
        public ForecastWeatherRequest(int? days)
        {
            Days = days;
        }
        /// <summary>
        /// Дней для получения проноза
        /// </summary>
        public int? Days { get; set; }
    }
}
