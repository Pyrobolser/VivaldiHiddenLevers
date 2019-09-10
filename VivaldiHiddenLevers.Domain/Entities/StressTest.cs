using Newtonsoft.Json;
using System.Collections.Generic;

namespace VivaldiHiddenLevers.Domain.Entities
{
    public class StressTest
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [JsonProperty(PropertyName = "result")]
        public ICollection<StressTestResult> Results { get; set; }
        public Client Client { get; set; }
        public string Ticker { get; set; }
        public string Message { get; set; }
    }

    public class StressTestResult
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalImpact { get; set; }
        public ICollection<StressTestPosition> Positions { get; set; }
    }

    public class StressTestPosition
    {
        public string Ticker { get; set; }
        public decimal Quantity { get; set; }
        public decimal ImpactPct { get; set; }
    }
}
