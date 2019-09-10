using System.Collections.Generic;
using VivaldiHiddenLevers.Application.Interfaces.Mapping;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.StressTests.Queries.GetStressTestForClient
{
    public class StressTestDetailModel : IMapFrom<StressTest>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ICollection<StressTestResultDto> Results { get; set; }
        public string Ticker { get; set; }
        public string Message { get; set; }
    }

    public class StressTestResultDto : IMapFrom<StressTestResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalImpact { get; set; }
        public ICollection<StressTestPositionDto> Positions { get; set; }
    }

    public class StressTestPositionDto : IMapFrom<StressTestPosition>
    {
        public string Ticker { get; set; }
        public int Quantity { get; set; }
        public decimal ImpactPct { get; set; }
    }
}
