using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Data;
using Dora.WeddingPlanner.Data.Model;
using Dora.WeddingPlanner.Model;
using Dora.WeddingPlanner.Model.WeddingTasks;

namespace Dora.WeddingPlanner.Core
{
    public class WeddingUseCase
    {
        private readonly string weddingId;
        private readonly Wedding wedding;
        private readonly ICanStoreWeddings weddingStore;

        public WeddingUseCase(Wedding wedding, string weddingId, ICanStoreWeddings store)
        {
            this.wedding = wedding;
            this.weddingId = weddingId;
            this.weddingStore = store;
        }

        public BasicWeddingTask DefineNewTask(string title, string description = null)
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

        public MandatoryWeddingTask DefineNewMandatoryTask(string title, string description = null)
        {
            var weddingTask = new MandatoryWeddingTask(title);
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
