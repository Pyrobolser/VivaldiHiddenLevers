using AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using VivaldiHiddenLevers.Application.Interfaces.Mapping;
using VivaldiHiddenLevers.Application.RiskProfiles.Commands;
using VivaldiHiddenLevers.Application.StressTests.Commands;

namespace VivaldiHiddenLevers.Application.Apis.HLEntities
{
    public class HLInput : IHaveCustomMapping
    {
        [JsonProperty("portfolio")]
        public HLPortfolio Portfolio { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<CreateStressTestForClient, HLInput>()
                .ForMember(c => c.Portfolio, opt => opt.MapFrom(hlDto => new HLPortfolio(hlDto.Positions)));

            configuration.CreateMap<CreateRiskProfileForClient, HLInput>()
                .ForMember(c => c.Portfolio, opt => opt.MapFrom(hlDto => new HLPortfolio(hlDto.Positions)));
        }
    }

    public class HLPortfolio
    {
        public HLPortfolio(ICollection<HLPosition> jsonPositions)
        {
            JsonPositions = jsonPositions;
        }

        [JsonProperty("jsonPositions")]
        public ICollection<HLPosition> JsonPositions { get; set; }
    }
}
