using System;

namespace Dora.WeddingPlanner.Model.DTO
{
    public sealed class WeddingEventDto
    {
        public string Title { get; private set; }

        public DateTime HappeningOn { get; private set; }

        public WeddingEventLocationDto Location { get; private set; }
    }
}