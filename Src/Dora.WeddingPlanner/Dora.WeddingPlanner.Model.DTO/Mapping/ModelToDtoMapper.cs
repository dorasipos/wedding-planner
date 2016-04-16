using AutoMapper;
using Dora.WeddingPlanner.Model.WeddingTasks;
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
                cfg.CreateMap<Comment, CommentDto>()
                    .ForMember(d => d.Timestamp, o => o.MapFrom(x => x.On));
                cfg.CreateMap<Person, PersonDto>();
                cfg.CreateMap<WeddingTask, WeddingTaskDto>()
                    .ForMember(d => d.IsClosed, o => o.ResolveUsing((r, t) => t.IsClosed()))
                    .ForMember(d => d.Priority, o => o.ResolveUsing((r, t) => MapPriority(t)));
                cfg.CreateMap<Address, AddressDto>();
                cfg.CreateMap<GeoLocation, GeoLocationDto>();
                cfg.CreateMap<WeddingEventLocation, WeddingEventLocationDto>();
                cfg.CreateMap<WeddingEvent, WeddingEventDto>();
                cfg.CreateMap<Wedding, WeddingDto>();
            });

            map = config.CreateMapper();
        }

        private static WeddingTaskDto.TaskPriority MapPriority(WeddingTask model)
        {
            if (model is MandatoryWeddingTask)
            {
                return WeddingTaskDto.TaskPriority.Mandatory;
            }

            return WeddingTaskDto.TaskPriority.Basic;
        }

        public static WeddingDto Map(Wedding wedding)
        {
            return map.Map<WeddingDto>(wedding);
        }
    }
}
