namespace Power.DTO
{
    /// <summary>
    /// DTO для ответов ошибок
    /// </summary>
    public class ErrorDTO
    {
        /// <summary>
        /// Текст сообщения об ошибке
        /// </summary>
        public string Error { get; }
        /// <summary>
        /// Конструктор ошибки
        /// </summary>
        /// <param name="error"></param>

        public ErrorDTO(string error)
        {
            Error = error;
        }
        /// <summary>
        /// Переопределение оператора сравнения
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            return obj is ErrorDTO other &&
                   Error == other.Error;
        }
        /// <summary>
        /// Переопределение оператора хэширования
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Error);
        }
    }
}
