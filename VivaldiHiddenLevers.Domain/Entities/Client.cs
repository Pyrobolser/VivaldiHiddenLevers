using System.Collections.Generic;

namespace VivaldiHiddenLevers.Domain.Entities
{
    public class Client
    {
        public Client()
        {
            RiskProfiles = new HashSet<RiskProfile>();
            StressTests = new HashSet<StressTest>();
        }

        public int Id { get; set; }
        public int? HiddenLeverId { get; set; }
        public string Url { get; set; }
        public string AdvisorEmail { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<RiskProfile> RiskProfiles { get; set; }
        public ICollection<StressTest> StressTests { get; set; }
    }
}
