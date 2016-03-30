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

        public WeddingTask(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new InvalidOperationException("A wedding task must have a title");
            }

            this.Title = title;
        }

        public string Title { get; }

        public string Description { get; private set; }

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
