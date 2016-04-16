using System.Collections.Generic;

namespace Dora.WeddingPlanner.Model.DTO
{
    public sealed class AddressDto
    {
        public string[] AddressLines { get; private set; }
        public string City { get; private set; }
        public string Area { get; private set; }
        public string Country { get; private set; }
    }
}