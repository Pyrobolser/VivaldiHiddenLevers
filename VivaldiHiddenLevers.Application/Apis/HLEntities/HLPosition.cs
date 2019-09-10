using Newtonsoft.Json;

namespace VivaldiHiddenLevers.Application.Apis.HLEntities
{
    public class HLPosition
    {
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
    }
}
