using Dora.WeddingPlanner.Model;
using Dora.WeddingPlanner.UserInteraction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Mappers
{
    internal static class DtoToModelMapper
    {
        public static Person Map(PersonDto dto)
        {
            return new Person(dto.FirstName, dto.LastName);
        }
    }
}
