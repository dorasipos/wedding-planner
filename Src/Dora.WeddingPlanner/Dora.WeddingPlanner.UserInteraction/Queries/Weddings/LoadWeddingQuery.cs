﻿using Dora.WeddingPlanner.Core;
using Dora.WeddingPlanner.Model.DTO;
using Dora.WeddingPlanner.Model.DTO.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Queries.Weddings
{
    public sealed class LoadWeddingQuery : ImAQuery<WeddingDto, string>
    {
        public WeddingDto Query(string weddingId)
        {
            return new WeddingDefinitionUseCase(Interactor.Store)
                .Load(weddingId)
                .Map();
        }

        public override string ToString()
        {
            return "Load Wedding";
        }
    }
}
