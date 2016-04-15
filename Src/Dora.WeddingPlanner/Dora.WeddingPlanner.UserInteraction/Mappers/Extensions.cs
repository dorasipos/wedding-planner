using Dora.WeddingPlanner.Model;
using Dora.WeddingPlanner.UserInteraction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Model.WeddingTasks;

namespace Dora.WeddingPlanner.UserInteraction.Mappers
{
    internal static class Extensions
    {
        public static Person Map(this PersonDto dto)
        {
            return DtoToModelMapper.Map(dto);
        }

        public static WeddingDto Map(this Wedding model)
        {
            return ModelToDtoMapper.Map(model);
        }

        public static WeddingTaskDto Map(this WeddingTask model)
        {
            return ModelToDtoMapper.Map(model);
        }

        public static PredefinedWeddingTaskDto Map(this PredefinedWeddingTask model)
        {
            return ModelToDtoMapper.Map(model);
        }

        public static IEnumerable<PredefinedWeddingTaskDto> Map(this IEnumerable<KeyValuePair<string, PredefinedWeddingTask>> model)
        {
            return ModelToDtoMapper.Map(model);
        }
    }
}
