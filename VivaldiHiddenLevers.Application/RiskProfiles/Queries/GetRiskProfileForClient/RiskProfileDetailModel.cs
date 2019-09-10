using System;
using System.Collections.Generic;
using VivaldiHiddenLevers.Application.Interfaces.Mapping;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.RiskProfiles.Queries.GetRiskProfileForClient
{
    public class RiskProfileDetailModel : IMapFrom<RiskProfile>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public RiskProfileResultDto Result { get; set; }
    }

    public class RiskProfileResultDto : IMapFrom<RiskProfileResult>
    {
        public decimal CCRScore { get; set; }
        public decimal ExpectedReturn { get; set; }
        public decimal ExpectedReturn5Yr { get; set; }
        public decimal WorstScenarioImpact { get; set; }
        public string UsePctAllocation { get; set; }
        public decimal SP500Beta { get; set; }
        public decimal ExpenseRatio { get; set; }
        public decimal Yield { get; set; }
        public decimal AnalyzableValue { get; set; }
        public decimal Value { get; set; }
        public ICollection<RiskProfilePositionDto> JsonPositions { get; set; }
    }

    public class RiskProfilePositionDto : IMapFrom<RiskProfilePosition>
    {
        public string Ticker { get; set; }
        public decimal Quantity { get; set; }
        public long MarketCap { get; set; }
        public DateTime PriceDate { get; set; }
        public string Industry { get; set; }
        public decimal Volatility { get; set; }
        public DateTime MDDStart { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public decimal Yield { get; set; }
        public decimal ExpenseRatio { get; set; }
        public string Name { get; set; }
        public decimal PctAllocation { get; set; }
        public DateTime MDDEnd { get; set; }
    }
}
