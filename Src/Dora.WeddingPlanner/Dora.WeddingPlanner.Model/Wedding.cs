using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model
{
    public class Wedding
    {
        private readonly Person bride;
        private readonly Person groom;
        private readonly List<WeddingTask> tasks = new List<WeddingTask>();
        private readonly List<WeddingGuest> guests = new List<WeddingGuest>();
        private readonly List<WeddingEvent> events = new List<WeddingEvent>();

        public Wedding(Person bride, Person groom)
        {
            if (bride == null || groom == null)
            {
                throw new InvalidOperationException("Cannot have a wedding without both the bride and the groom");
            }

            this.bride = bride;
            this.groom = groom;
        }

        public Person Bride { get { return this.bride; } }
        public Person Groom { get { return this.groom; } }

        public IReadOnlyList<WeddingEvent> Events { get { return this.events; } }

        public IReadOnlyList<WeddingTask> Tasks { get { return this.tasks; } }

        public IReadOnlyList<WeddingGuest> Guests { get { return this.guests; } }

        public Wedding AddTask(WeddingTask task)
        {
            this.tasks.Add(task);
            return this;
        }
    }
}
