using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Power.DTO;
using Power.Models.WeatherAPI;
using Power.Request;
using System.Threading;

namespace Power.Controllers
{
    /// <summary>
    /// Контроллер WeatherAPI
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
   
    public class WeatherAPIController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<WeatherAPIController> logger;
        /// <summary>
        /// Конструктор для контроллера
        /// </summary>
        /// <param name="mediator">медиатр его интерфейс</param>
        /// <param name="logger">интерфейс логировщика</param>
        public WeatherAPIController(IMediator mediator, ILogger<WeatherAPIController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }
        /// <summary>
        /// Получение погоды по API с заданным Lat Lon для Москвы
        /// </summary>
        /// <response code="200">Вернёт информацию о прогнозе погоды</response>
        /// <response code="400">Что-то пошло не так</response>
        /// <param name="cancellationToken">Токен отмены</param>
        [ProducesResponseType(typeof(CurrentWeatherAPIResponseDTO), StatusCodes.Status200OK, contentType: "application/json")]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        [HttpGet("[controller]/GetCurrentWeather")]
        public async Task<IActionResult> GetCurrentWeather(CancellationToken cancellationToken)
        {
            var result=await mediator.Send(new CurrentWeatherRequest(), cancellationToken);
            ArgumentNullException.ThrowIfNull(result);
            return Ok(result);
        }
        /// <summary>
        /// Получение прогноза погоды по API с заданным для Москвы
        /// </summary>
        /// <response code="200">Вернёт информацию о прогнозе погоды</response>
        /// <response code="400">Что-то пошло не так</response>
        /// <param name="Days">Дней в прогнозе</param>
        /// <param name="cancellationToken">Токен отмены</param>

        [ProducesResponseType(typeof(ForecastWeatherAPIResponseDTO),StatusCodes.Status200OK,contentType:"application/json")]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        [HttpGet("[controller]/GetWeatherForecast")]
        public async Task<IActionResult> GetWeatherForecast(CancellationToken cancellationToken,int? Days=3)
        {
            var result = await mediator.Send(new ForecastWeatherRequest(Days), cancellationToken);
            ArgumentNullException.ThrowIfNull(result);
            return Ok(result);
        }
    }
}
