using Dora.WeddingPlanner.Model;
using Dora.WeddingPlanner.UserInteraction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.Mappers
{
    internal static class Extensions
    {
        public static Person Map(this PersonDto dto)
        {
            return DtoToModelMapper.Map(dto);
        }
    }
}
