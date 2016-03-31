using Dora.WeddingPlanner.Model.WeddingTaskOutcomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dora.WeddingPlanner.Model
{
    public abstract class WeddingTask
    {
        private WeddingTaskOutcome outcome = new NoOutcome();
        protected readonly List<Comment> details = new List<Comment>();

        public WeddingTask(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new InvalidOperationException("A wedding task must have a title");
            }

            this.Title = title;
        }

        public string Title { get; }

        public IReadOnlyList<Comment> Details { get; private set; }

        public virtual WeddingTask Describe(string description)
        {
            this.details.Add(new Comment(description));
            return this;
        }

        public WeddingTaskOutcome Outcome
        {
            get
            {
                return this.outcome;
            }
        }

        public virtual WeddingTask ResolveWith(WeddingTaskOutcome outcome)
        {
            this.outcome = outcome;
            return this;
        }

        public virtual bool IsClosed()
        {
            return this.outcome.IsClosed();
        }
    }
}
