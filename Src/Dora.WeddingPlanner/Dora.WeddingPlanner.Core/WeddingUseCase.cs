﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Data;
using Dora.WeddingPlanner.Data.Model;
using Dora.WeddingPlanner.Model;

namespace Dora.WeddingPlanner.Core
{
    public class WeddingUseCase
    {
        private readonly Guid weddingId;
        private readonly Wedding wedding;
        private readonly ICanStoreWeddings weddingStore;

        public WeddingUseCase(Wedding wedding, Guid weddingId, ICanStoreWeddings store)
        {
            this.wedding = wedding;
            this.weddingId = weddingId;
            this.weddingStore = store;
        }

        public WeddingTask DefineNewTask(string title, string description = null)
        {
            var weddingTask = new BasicWeddingTask(title);
            if (!string.IsNullOrWhiteSpace(description))
            {
                weddingTask.Describe(description);
            }
            this.wedding.AddTask(weddingTask);
            this.weddingStore.Save(StorableWedding.Existing(this.weddingId, this.wedding));
            return weddingTask;
        }
    }
}
