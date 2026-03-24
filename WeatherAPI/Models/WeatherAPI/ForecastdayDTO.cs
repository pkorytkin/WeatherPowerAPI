namespace Power.Models.WeatherAPI
{
    public class ForecastdayDTO
    {
        public string? date { get; set; }
        public int? date_epoch { get; set; }
        public DayDTO? day { get; set; }
        public AstroDTO? astro { get; set; }
        public List<HourDTO>? hour { get; set; }
    }

}
