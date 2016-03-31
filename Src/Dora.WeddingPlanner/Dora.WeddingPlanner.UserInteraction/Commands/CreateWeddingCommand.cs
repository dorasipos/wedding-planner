using Dora.WeddingPlanner.Core;
using Dora.WeddingPlanner.UserInteraction.Mappers;
using Dora.WeddingPlanner.UserInteraction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Commands
{
    public class CreateWeddingCommand : ImAnInteractionCommand
    {
        public PersonDto Bride { get; set; }
        public PersonDto Groom { get; set; }

        public string Execute()
        {
            return new WeddingDefinitionUseCase(Interactor.Store)
                .DefineNew(this.Bride.Map(), this.Groom.Map())
                .Key.ToString();
        }
    }
}
