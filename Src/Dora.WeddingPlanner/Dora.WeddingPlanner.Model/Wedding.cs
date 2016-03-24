using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model
{
    public class Wedding
    {
        public IEnumerable<WeddingTask> Tasks { get; set; }

        public IEnumerable<WeddingGuest> Guests { get; set; }
    }
}
