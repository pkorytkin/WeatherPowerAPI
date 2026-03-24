namespace Power.Models.WeatherAPI
{
    /// <summary>
    /// Модель ответа от WeatherAPI прогноза
    /// </summary>
    public class ForecastWeatherAPIResponseDTO:CurrentWeatherAPIResponseDTO
    {

        /// <summary>
        /// Прогноз
        /// </summary>
        public ForecastDTO? forecast { get; set; }
    }

}
