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
            return ModelToDtoMapper.Map(model);
        }

        public static Wedding Map(this WeddingDto dto)
        {
            return DtoToModelMapper.Map(dto);
        }
    }
}
