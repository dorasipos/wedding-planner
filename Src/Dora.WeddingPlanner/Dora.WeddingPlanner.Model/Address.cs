using System.Collections.Generic;

namespace Dora.WeddingPlanner.Model
{
    public class Address
    {
        public IReadOnlyList<string> AddressLines { get; }
        public string City { get; }
        public string Area { get; }
        public string Country { get; }
    }
}