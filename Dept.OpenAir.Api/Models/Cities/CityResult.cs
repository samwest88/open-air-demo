namespace Dept.OpenAir.Api.Models
{
    public class CityResult
    {
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Count { get; set; }
        public int Locations { get; set; }
        public DateTime FirstUpdated { get; set; }
        public DateTime LastUpdated { get; set; }
        public string[] Parameters { get; set; } = Array.Empty<string>();
    }
}
