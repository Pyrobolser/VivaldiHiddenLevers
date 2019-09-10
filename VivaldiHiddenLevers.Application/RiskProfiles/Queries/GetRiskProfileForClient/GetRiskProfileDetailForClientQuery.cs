using MediatR;

namespace VivaldiHiddenLevers.Application.RiskProfiles.Queries.GetRiskProfileForClient
{
    public class GetRiskProfileDetailForClientQuery : IRequest<RiskProfileDetailModel>
    {
        public int ClientId { get; set; }
    }
}
