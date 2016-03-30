using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model
{
    public class WeddingEvent
    {
        public static WeddingEvent CivilCeremony = new WeddingEvent("Civil Ceremony");
        public static WeddingEvent ReligiousCeremony = new WeddingEvent("Religious Ceremony");
        public static WeddingEvent Reception = new WeddingEvent("Wedding Reception");

        public WeddingEvent(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new InvalidOperationException("A wedding event must have a title");
            }

            this.Title = title;
        }

        public string Title { get; }
        public DateTime HappeningOn { get; private set; }
        public WeddingEventLocation Location { get; private set; }

        public WeddingEvent Pin(DateTime on, WeddingEventLocation location)
        {
            this.HappeningOn = on;
            this.Location = location;
            return this;
        }
    }
}
