using Dora.WeddingPlanner.Model.WeddingTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.DTO.Mapping
{
    public static class Extensions
    {
        public static WeddingDto Map(this Wedding model)
        {
            return ModelToDtoMapper.Do.Map<WeddingDto>(model);
        }

        public static WeddingTaskDto Map(this WeddingTask model)
        {
            return ModelToDtoMapper.Do.Map<WeddingTaskDto>(model);
        }

        public static PredefinedWeddingTaskDto Map(this PredefinedWeddingTask model)
        {
            return ModelToDtoMapper.Do.Map<PredefinedWeddingTaskDto>(model);
        }

        public static Person Map(this PersonDto dto)
        {
            return DtoToModelMapper.Do.Map<Person>(dto);
        }

        public static Wedding Map(this WeddingDto dto)
        {
            return DtoToModelMapper.Do.Map<Wedding>(dto);
        }
    }
}
