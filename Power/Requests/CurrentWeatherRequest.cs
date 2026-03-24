using MediatR;
using Power.Models.WeatherAPI;
namespace Power.Request
{
    /// <summary>
    /// Запрос через mediatr 
    /// </summary>
    public class CurrentWeatherRequest: IRequest<CurrentWeatherAPIResponseDTO>
    {
    }
}
