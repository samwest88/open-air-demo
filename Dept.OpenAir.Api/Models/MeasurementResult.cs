using Dept.OpenAir.Api.Models.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dept.OpenAir.Api.Models
{
    public class MeasurementResult
    {
        public int LocationId { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Parameter { get; set; } = string.Empty;
        public float Value { get; set; }
        public DateInformation? Date { get; set; }
        public string Unit { get; set; } = string.Empty;
        public Coordinates? Coordinates { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public bool IsMobile { get; set; }
        public bool? IsAnalysis { get; set; }
        public string Entity { get; set; } = string.Empty;
        public string SensorType { get; set; } = string.Empty;
    }
}
