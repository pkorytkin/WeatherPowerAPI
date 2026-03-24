namespace Power.Models.WeatherAPI
{

    /// <summary>
    /// Модель ответа информации о нынешней погоде
    /// </summary>
    public class CurrentWeatherAPIResponseDTO
    {
        /// <summary>
        /// Информация о локации
        /// </summary>
        public LocationDTO? location { get; set; }
        /// <summary>
        /// Нынешняя погода
        /// </summary>
        public CurrentDTO? current { get; set; }
    }

}
