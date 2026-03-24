using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Power.Models.WeatherAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherAPI.Exceptions;

namespace WeatherAPI.Services
{
    /// <summary>
    /// Сервсис получения информации по погоде
    /// <a>https://www.weatherapi.com/docs/</a>
    /// </summary>
    public class WeatherAPIService
    {
        private readonly ILogger<WeatherAPIService> logger;
        private readonly IConfiguration configuration;
        /// <summary>
        /// Ссылка на API
        /// </summary>
        const string CurrentWeatherURL = "https://api.weatherapi.com/v1/current.json?key={0}&q={1},{2}";
        const string ForecastWeatherURL = "http://api.weatherapi.com/v1/forecast.json?key={0}&q={1},{2}&days={3}";
        /// <summary>
        /// Московская широта
        /// </summary>
        const string MoscowLat = "55.751244";
        /// <summary>
        /// Московская долгота
        /// </summary>
        const string MoscowLon = "37.618423";
        /// <summary>
        /// Ключ API
        /// </summary>
        private string APIKey { get; init; }
        public WeatherAPIService(ILogger<WeatherAPIService> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
            APIKey = configuration
                .GetRequiredSection("WeatherAPI")
                .GetValue<string>("APIKey")??"";

            ArgumentNullException.ThrowIfNullOrEmpty(APIKey,"Не указан ключ к WeatherAPI");
        }

        /// <summary>
        /// Получение прогноза погоды по API с заданным Lat Lon по умолчанию Москва
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        /// <param name="days">Число дней до 14 включительно</param>
        public async Task<ForecastWeatherAPIResponseDTO> GetWeatherForecast(int? days = 3, string lat = MoscowLat, string lon = MoscowLon)
        {
            try
            {
                if (days > 14)
                {
                    days = 14;
                }
                string apiUrl = string.Format(ForecastWeatherURL, APIKey, lat, lon,days);
                HttpClient httpClient = new HttpClient();
                var res = await httpClient.GetAsync(apiUrl);
                ArgumentNullException.ThrowIfNull(res, "Пришёл не валидный ответ от Weather API");
                var resJson = await res.Content.ReadAsStringAsync();
                var dto = await JsonSerializer.DeserializeAsync<ForecastWeatherAPIResponseDTO>(res.Content.ReadAsStream());

                ArgumentNullException.ThrowIfNull(dto, "Не удалось десериализовать ответ Weather API. Возможно устарела реализация API.");

                return dto;
            }
            catch (Exception ex)
            {
                throw new WeatherAPIException(ex.Message);
            }
        }
        /// <summary>
        /// Получение погоды по API с заданным Lat Lon по умолчанию Москва
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        public async Task<CurrentWeatherAPIResponseDTO> GetCurrentWeather(string lat = MoscowLat, string lon = MoscowLon)
        {
            try
            {
                string apiUrl = string.Format(CurrentWeatherURL,APIKey, lat, lon);
                HttpClient httpClient = new HttpClient();
                var res = await httpClient.GetAsync(apiUrl);
                ArgumentNullException.ThrowIfNull(res, "Пришёл не валидный ответ от Weather API");
                var resJson = await res.Content.ReadAsStringAsync();
                var dto = await JsonSerializer.DeserializeAsync<CurrentWeatherAPIResponseDTO>(res.Content.ReadAsStream());

                ArgumentNullException.ThrowIfNull(dto, "Не удалось десериализовать ответ Weather API. Возможно устарела реализация API.");

                return dto;
            }
            catch (Exception ex)
            {
                throw new WeatherAPIException(ex.Message);
            }
        }


    }
}
