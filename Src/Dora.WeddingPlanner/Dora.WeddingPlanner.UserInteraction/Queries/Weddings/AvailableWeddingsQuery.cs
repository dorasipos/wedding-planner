using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Core;
using Dora.WeddingPlanner.UserInteraction.Mappers;
using Dora.WeddingPlanner.UserInteraction.Model;

namespace Dora.WeddingPlanner.UserInteraction.Queries.Weddings
{
    public class AvailableWeddingsQuery : ImAQuery<IEnumerable<KeyValuePair<string, WeddingDto>>, object>
    {
        public IEnumerable<KeyValuePair<string, WeddingDto>> Query(object parameter)
        {
            foreach (var w in new WeddingDefinitionUseCase(Interactor.Store)
                .FetchAll()
                .Select(w => new KeyValuePair<string, WeddingDto>(w.Key, w.Value.Map())))
            {
                yield return w;
            }
        }
    }
}
