using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.DTO.Mapping
{
    internal static class DtoToModelMapper
    {
        private static IMapper map;

        static DtoToModelMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WeddingDto, Wedding>();
            });

            map = config.CreateMapper();
        }

        public static Wedding Map(WeddingDto wedding)
        {
            return map.Map<Wedding>(wedding);
        }
    }
}
