using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Core;
using Dora.WeddingPlanner.Model.DTO;
using Dora.WeddingPlanner.Model.DTO.Mapping;

namespace Dora.WeddingPlanner.UserInteraction.Queries.Tasks
{
    public sealed class PredefinedWeddingTasksQuery : ImAQuery<IEnumerable<PredefinedWeddingTaskDto>, object>
    {
        public IEnumerable<PredefinedWeddingTaskDto> Query(object parameter)
        {
            return new WeddingTasksUseCase()
                .FetchPredefinedTasks()
                .Select(t => t.Value.Map());
        }
    }
}
