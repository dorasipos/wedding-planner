using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Model;
using Dora.WeddingPlanner.UserInteraction.Model;

namespace Dora.WeddingPlanner.UserInteraction.Mappers
{
    internal static class ModelToDtoMapper
    {
        public static WeddingDto Map(Wedding model)
        {
            return new WeddingDto
            {
                Bride = Map(model.Bride),
                Groom = Map(model.Groom)
            };
        }

        public static PersonDto Map(Person model)
        {
            return new PersonDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }
    }
}
