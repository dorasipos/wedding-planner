using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Model.WeddingTasks;
using Dora.WeddingPlanner.Model.WeddingTasks.Predefined;

namespace Dora.WeddingPlanner.Core
{
    public sealed class WeddingTasksUseCase
    {
        public IReadOnlyDictionary<string, PredefinedWeddingTask> FetchPredefinedTasks()
        {
            return PredefinedWeddingTaskBag.Tasks;
        }
    }
}
