using AutoMapper;
using Newtonsoft.Json;
using VivaldiHiddenLevers.Application.Interfaces.Mapping;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.Apis.HLEntities
{
    public class HLClientResult : IHaveCustomMapping
    {
        [JsonProperty("result/clientid")]
        public int ClientId { get; set; }

        [JsonProperty("result/surveyURL")]
        public string SurveyURL { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<HLClientResult, Client>()
                .ForMember(c => c.HiddenLeverId, opt => opt.MapFrom(hlDto => hlDto.ClientId))
                .ForMember(c => c.Url, opt => opt.MapFrom(hlDto => hlDto.SurveyURL));
        }
    }
}
