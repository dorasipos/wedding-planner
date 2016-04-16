namespace Dora.WeddingPlanner.Model.DTO
{
    public sealed class WeddingEventLocationDto
    {
        public string Name { get; private set; }
        public string Notes { get; private set; }
        public AddressDto Address { get; private set; }
        public GeoLocationDto ExactLocation { get; private set; }
    }
}