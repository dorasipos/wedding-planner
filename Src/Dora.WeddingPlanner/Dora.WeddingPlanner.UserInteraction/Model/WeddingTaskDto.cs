using System.Collections.Generic;

namespace Dora.WeddingPlanner.UserInteraction.Model
{
    public sealed class WeddingTaskDto
    {
        public enum TaskPriority
        {
            Basic,
            Mandatory
        }

        public string Title { get; set; }

        public IReadOnlyList<CommentDto> Details { get; set; }

        public bool IsClosed { get; set; }

        public TaskPriority Priority { get; set; }
    }
}