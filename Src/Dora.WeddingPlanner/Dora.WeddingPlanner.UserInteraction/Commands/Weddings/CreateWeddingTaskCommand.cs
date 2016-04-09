using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Core;

namespace Dora.WeddingPlanner.UserInteraction.Commands.Weddings
{
    public class CreateWeddingTaskCommand : ImAnInteractionCommand<object>
    {
        public string WeddingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        object ImAnInteractionCommand<object>.Execute()
        {
            new WeddingUseCase(Interactor.Store.Load(this.WeddingId), this.WeddingId, Interactor.Store).DefineNewTask(this.Title, this.Description);
            return null;
        }
    }
}
