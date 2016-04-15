using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Model
{
    public sealed class PredefinedWeddingTaskDto
    {
        public string Id { get; set; }
        public WeddingTaskDto Task { get; set; }
    }
}
