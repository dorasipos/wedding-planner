namespace Dora.WeddingPlanner.Model
{
    public class WeddingEventLocation
    {
        public string Name { get; }
        public string Notes { get; }
        public Address Address { get; }
        public GeoLocation ExactLocation { get; }
    }
}