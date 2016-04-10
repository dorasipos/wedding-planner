using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Core;
using Dora.WeddingPlanner.UserInteraction.Model;
using Dora.WeddingPlanner.Model;
using Dora.WeddingPlanner.UserInteraction.Mappers;

namespace Dora.WeddingPlanner.UserInteraction.Commands.Weddings
{
    public class CreateWeddingTaskCommand : ImAnInteractionCommand<WeddingTaskDto>
    {
        public string WeddingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsMandatory { get; set; }

        WeddingTaskDto ImAnInteractionCommand<WeddingTaskDto>.Execute()
        {
            var useCase = new WeddingUseCase(Interactor.Store.Load(this.WeddingId), this.WeddingId, Interactor.Store);
            WeddingTask task;
            if (this.IsMandatory)
            {
                task = useCase.DefineNewMandatoryTask(this.Title, this.Description);
            }
            else
            {
                task = useCase.DefineNewTask(this.Title, this.Description);
            }
            return task.Map();
        }
    }
}
