namespace Power.Models.WeatherAPI
{
    public class LocationDTO
    {
        public string? name { get; set; }
        public string? region { get; set; }
        public string? country { get; set; }
        public double? lat { get; set; }
        public double? lon { get; set; }
        public string? tz_id { get; set; }
        public int? localtime_epoch { get; set; }
        public string? localtime { get; set; }
    }


}
