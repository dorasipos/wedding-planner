using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dora.WeddingPlanner.Model
{
    public abstract class WeddingTaskOutcome
    {
        private readonly List<WeddingTask> relatedTasks = new List<WeddingTask>();

        public IReadOnlyList<WeddingTask> RelatedTasks { get { return this.relatedTasks; } }

        public virtual bool IsClosed()
        {
            return this.relatedTasks.All(t => t.IsClosed());
        }
    }
}
