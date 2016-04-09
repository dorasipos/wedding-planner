using Dora.WeddingPlanner.Core;
using Dora.WeddingPlanner.UserInteraction.Mappers;
using Dora.WeddingPlanner.UserInteraction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Queries.Weddings
{
    public class LoadWeddingQuery : ImAQuery<WeddingDto, string>
    {
        public WeddingDto Query(string weddingId)
        {
            return new WeddingDefinitionUseCase(Interactor.Store)
                .Load(weddingId)
                .Map();
        }
    }
}
