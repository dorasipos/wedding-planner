using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.WeddingTasks
{
    public abstract class PredefinedWeddingTask : WeddingTask
    {
        public abstract string Id { get; }

        public PredefinedWeddingTask(string title) : base(title)
        {
        }
    }
}
