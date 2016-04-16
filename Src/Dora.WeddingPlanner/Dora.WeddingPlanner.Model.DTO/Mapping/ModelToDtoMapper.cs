using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.DTO.Mapping
{
    internal static class ModelToDtoMapper
    {
        private static IMapper map;

        static ModelToDtoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Wedding, WeddingDto>();
            });

            map = config.CreateMapper();
        }

        public static WeddingDto Map(Wedding wedding)
        {
            return map.Map<WeddingDto>(wedding);
        }
    }
}
