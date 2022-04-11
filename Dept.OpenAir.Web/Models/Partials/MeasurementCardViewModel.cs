namespace Dept.OpenAir.Web.Models.Partials
{
    /// <summary>
    /// Has measurements that we want to display on our card
    /// </summary>
    public class MeasurementCardViewModel
    {
        public int LocationId { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Parameter { get; set; } = string.Empty;
        public float Value { get; set; }
        public bool? IsAnalysis { get; set; }
        public string Entity { get; set; } = string.Empty;
        public string SensorType { get; set; } = string.Empty;
    }
}
