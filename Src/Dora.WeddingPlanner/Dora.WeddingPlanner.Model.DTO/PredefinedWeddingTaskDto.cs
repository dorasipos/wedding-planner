using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.DTO
{
    public sealed class PredefinedWeddingTaskDto
    {
        public string Id { get; private set; }
        public WeddingTaskDto Task { get; private set; }
    }
}
