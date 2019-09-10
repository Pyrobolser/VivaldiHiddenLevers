using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Apis.HLEntities;
using VivaldiHiddenLevers.Application.Interfaces;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.HLClient
{
    public class HiddenLeversApiClient : IVivaldiHiddenLeversClient
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly string _apiUser;

        public HiddenLeversApiClient(IConfiguration config)
        {
            _baseUrl = config["HiddenLeversServiceUri"];
            _apiKey = config["HiddenLeversAPIKey"];
            _apiUser = config["HiddenLeversAPIUser"];
        }

        public async Task<RiskProfile> CreateRiskProfile(HLInput positions)
        {
            string input = JsonConvert.SerializeObject(positions);

            return await _baseUrl
                .AppendPathSegment("riskprofile")
                .SetQueryParam("apikey", _apiKey)
                .SetQueryParam("apiuser", _apiUser)
                .SetQueryParam("allocationType", "pct")
                .SetQueryParam("timeframe", "2yr")
                .SetQueryParam("input", input)
                .GetJsonAsync<RiskProfile>();
        }

        public async Task<StressTest> CreateStressTest(HLInput positions)
        {
            string input = JsonConvert.SerializeObject(positions);

            return await _baseUrl
                .AppendPathSegment("stresstest")
                .SetQueryParam("apikey", _apiKey)
                .SetQueryParam("apiuser", _apiUser)
                .SetQueryParam("allocationType", "pct")
                .SetQueryParam("input", input)
                .GetJsonAsync<StressTest>();
        }

        public async Task<HLClientResult> CreateClient(string advisorEmail, string clientName, string clientEmail, string clientPhone, string uniqueClientId)
        {
            string input = JsonConvert.SerializeObject(new
            {
                advisorEmail,
                clientName,
                clientEmail,
                clientPhone,
                uniqueClientId
            });

            return await _baseUrl
                .AppendPathSegment("createclient")
                .SetQueryParam("apikey", _apiKey)
                .SetQueryParam("apiuser", _apiUser)
                .SetQueryParam("input", input)
                .GetJsonAsync<HLClientResult>();
        }
    }
}
