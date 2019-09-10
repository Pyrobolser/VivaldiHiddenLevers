using MediatR;

namespace VivaldiHiddenLevers.Application.StressTests.Queries.GetStressTestForClient
{
    public class GetStressTestDetailForClientQuery : IRequest<StressTestDetailModel>
    {
        public int ClientId { get; set; }
    }
}
