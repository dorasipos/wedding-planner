﻿using Dora.WeddingPlanner.Core;
using Dora.WeddingPlanner.Model.DTO;
using Dora.WeddingPlanner.Model.DTO.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Commands
{
    public class CreateWeddingCommand : ImAnInteractionCommand<string>
    {
        public PersonDto Bride { get; set; }
        public PersonDto Groom { get; set; }

        string ImAnInteractionCommand<string>.Execute()
        {
            return new WeddingDefinitionUseCase(Interactor.Store)
                .DefineNew(this.Bride.Map(), this.Groom.Map())
                .Key;
        }

        public override string ToString()
        {
            return string.Format("Create Wedding between {0} and {1}", this.Bride, this.Groom);
        }
    }
}
