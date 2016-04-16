using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.DTO
{
    public sealed class CommentDto
    {
        public DateTime Timestamp { get; private set; }
        public string Content { get; private set; }
    }
}
