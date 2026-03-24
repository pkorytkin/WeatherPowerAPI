namespace WeatherAPI.Exceptions
{
    [Serializable]
    public class WeatherAPIException : Exception
    {
        /// <summary>
        /// Конструктор с ошибкой погодного API
        /// </summary>
        /// <param name="message">Сообщение</param>
        public WeatherAPIException(string? message) : base(message)
        {
        }
        /// <summary>
        /// Конструктор с ошибкой погодного API
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="innerException">Вложенная ошибка</param>
        public WeatherAPIException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
