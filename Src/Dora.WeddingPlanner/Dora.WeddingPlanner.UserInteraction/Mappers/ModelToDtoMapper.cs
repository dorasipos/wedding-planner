using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Model;
using Dora.WeddingPlanner.Model.WeddingTasks;
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
                Groom = Map(model.Groom),
                Tasks = model.Tasks.Select(Map).ToArray()
            };
        }

        public static WeddingTaskDto Map(WeddingTask model)
        {
            return new WeddingTaskDto
            {
                Title = model.Title,
                Details = model.Details.Select(Map).ToArray(),
                IsClosed = model.IsClosed(),
                Priority = MapPriority(model)
            };
        }

        private static WeddingTaskDto.TaskPriority MapPriority(WeddingTask model)
        {
            if (model is MandatoryWeddingTask)
            {
                return WeddingTaskDto.TaskPriority.Mandatory;
            }

            return WeddingTaskDto.TaskPriority.Basic;
        }

        private static CommentDto Map(Comment model)
        {
            return new CommentDto
            {
                Content = model.Content,
                Timestamp = model.On
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

        public static PredefinedWeddingTaskDto Map(PredefinedWeddingTask model)
        {
            return new PredefinedWeddingTaskDto
            {
                Id = model.Id,
                Task = Map(model as WeddingTask)
            };
        }

        public static IEnumerable<PredefinedWeddingTaskDto> Map(IEnumerable<KeyValuePair<string, PredefinedWeddingTask>> model)
        {
            foreach (var t in model)
            {
                yield return Map(t.Value);
            }
        }
    }
}
