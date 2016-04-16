using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.DTO
{
    public sealed class WeddingTaskDto
    {
        public string Id { get; private set; }

        public enum TaskPriority
        {
            Basic,
            Mandatory
        }

        public string Title { get; private set; }

        public CommentDto[] Details { get; private set; }

        public bool IsClosed { get; private set; }

        public TaskPriority Priority { get; private set; }
    }
}
