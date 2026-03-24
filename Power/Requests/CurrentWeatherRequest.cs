using MediatR;
using Power.Models.WeatherAPI;
namespace Power.Request
{
    public class CurrentWeatherRequest: IRequest<CurrentWeatherAPIResponseDTO>
    {
    }
}
