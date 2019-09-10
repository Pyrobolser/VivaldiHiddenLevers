using Newtonsoft.Json;

namespace VivaldiHiddenLevers.ApiHiddenLevers.Entities.Output
{

    public class HiddenLeversClientResult
    {
        [JsonProperty("result")]
        public HiddenLeversClientOutput Result { get; set; }
    }

    public class HiddenLeversClientOutput
    {
        [JsonProperty("clientid")]
        public int ClientId { get; set; }

        [JsonProperty("surveyURL")]
        public string SurveyURL { get; set; }
    }
}
