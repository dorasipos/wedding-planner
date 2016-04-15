using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.WeddingTasks.Predefined
{
    public static class PredefinedWeddingTaskBag
    {
        private static Lazy<IReadOnlyDictionary<string, PredefinedWeddingTask>> predefinedTasks
            = new Lazy<IReadOnlyDictionary<string, PredefinedWeddingTask>>(GetAllPredefinedWeddingTasksDictionary, true);

        public static IReadOnlyDictionary<string, PredefinedWeddingTask> Tasks
        {
            get
            {
                return predefinedTasks.Value;
            }
        }

        private static PredefinedWeddingTask[] GetAllPredefinedWeddingTasks()
        {
            return new PredefinedWeddingTask[] {
                new PlanCivilCeremonyTask(),
                new PlanReligiousCeremonyTask(),
                new PlanWeddingReceptionPartyTask()
            };
        }

        private static ConcurrentDictionary<string, PredefinedWeddingTask> GetAllPredefinedWeddingTasksDictionary()
        {
            return new ConcurrentDictionary<string, PredefinedWeddingTask>(GetAllPredefinedWeddingTasks().ToDictionary(x => x.Id));
        }
    }
}
