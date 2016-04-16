using AutoMapper;
using Dora.WeddingPlanner.Model.WeddingTasks;
using Dora.WeddingPlanner.Model.WeddingTasks.Predefined;
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
                cfg.CreateMap<CommentDto, Comment>()
                    .ConstructUsing(d => new Comment(d.Content))
                    .ForMember(d => d.On, o => o.MapFrom(x => x.Timestamp));
                cfg.CreateMap<PersonDto, Person>();

                cfg.CreateMap<WeddingTaskDto, WeddingTask>()
                    .ConstructUsing(MapTask);

                cfg.CreateMap<AddressDto, Address>();
                cfg.CreateMap<GeoLocationDto, GeoLocation>();
                cfg.CreateMap<WeddingEventLocationDto, WeddingEventLocation>();
                cfg.CreateMap<WeddingEventDto, WeddingEvent>();
                cfg.CreateMap<WeddingDto, Wedding>();
            });

            map = config.CreateMapper();
        }

        private static WeddingTask MapTask(WeddingTaskDto taskDto)
        {
            if (taskDto.Id != null)
            {
                return PredefinedWeddingTaskBag.Tasks[taskDto.Id];
            }

            if (taskDto.Priority == WeddingTaskDto.TaskPriority.Mandatory)
            {
                return new MandatoryWeddingTask(taskDto.Title);
            }

            return new BasicWeddingTask(taskDto.Title);
        }

        public static IMapper Do { get { return map; } }
    }
}
