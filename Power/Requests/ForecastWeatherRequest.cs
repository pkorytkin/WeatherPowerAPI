using MediatR;
using Power.Models.WeatherAPI;
namespace Power.Request
{
    /// <summary>
    /// Запрос через mediatr 
    /// </summary>
    public class ForecastWeatherRequest : IRequest<ForecastWeatherAPIResponseDTO>
    {
        /// <summary>
        /// Конструктор с прогнозом через mediatr
        /// </summary>
        /// <param name="days">Дней в прогнозе</param>
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
