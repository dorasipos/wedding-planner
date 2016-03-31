using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dora.WeddingPlanner.Model
{
    public abstract class WeddingTaskOutcome
    {
        private readonly string notes;
        protected readonly List<Comment> details = new List<Comment>();
        protected readonly List<WeddingTask> relatedTasks = new List<WeddingTask>();

        public WeddingTaskOutcome(string takeaway)
        {
            this.notes = takeaway;
        }

        public string Notes { get { return this.notes; } }

        public IReadOnlyList<Comment> Details { get; private set; }

        public IReadOnlyList<WeddingTask> RelatedTasks { get { return this.relatedTasks; } }

        public WeddingTaskOutcome Describe(string details)
        {
            this.details.Add(new Comment(details));
            return this;
        }

        public virtual bool IsClosed()
        {
            return this.relatedTasks.All(t => t.IsClosed());
        }
    }
}
