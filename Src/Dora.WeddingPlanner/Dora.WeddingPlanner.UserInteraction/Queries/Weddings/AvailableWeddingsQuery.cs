﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Core;
using Dora.WeddingPlanner.UserInteraction.Mappers;
using Dora.WeddingPlanner.UserInteraction.Model;

namespace Dora.WeddingPlanner.UserInteraction.Queries.Weddings
{
    public class AvailableWeddingsQuery : ImAQuery<IEnumerable<KeyValuePair<Guid, WeddingDto>>, object>
    {
        public IEnumerable<KeyValuePair<Guid, WeddingDto>> Query(object parameter)
        {
            return new WeddingDefinitionUseCase(Interactor.Store)
                .FetchAll()
                .Select(w => new KeyValuePair<Guid, WeddingDto>(w.Key, w.Value.Map()));
        }
    }
}
