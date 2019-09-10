using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System.Configuration;
using System.Threading.Tasks;
using VivaldiHiddenLevers.ApiHiddenLevers.Entities.Output;

namespace VivaldiHiddenLevers.ApiHiddenLevers
{
    public class HiddenLeversClient : IHiddenLeversClient
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly string _apiUser;

        public HiddenLeversClient()
        {
            _baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _apiKey = ConfigurationManager.AppSettings["ApiKey"];
            _apiUser = ConfigurationManager.AppSettings["ApiUser"];
        }

        public async Task<HiddenLeversClientOutput> CreateClient(string advisorEmail, string clientName, string clientEmail, string clientPhone, string uniqueClientId)
        {
            string input = JsonConvert.SerializeObject(new
            {
                advisorEmail,
                clientName,
                clientEmail,
                clientPhone,
                uniqueClientId
            });

            var result = await _baseUrl
                .AppendPathSegment("createclient")
                .SetQueryParam("apikey", _apiKey)
                .SetQueryParam("apiuser", _apiUser)
                .SetQueryParam("input", input)
                .GetJsonAsync<HiddenLeversClientResult>();

            return result.Result;
        }
    }
}
