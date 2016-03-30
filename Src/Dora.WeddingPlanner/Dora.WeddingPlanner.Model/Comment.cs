using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model
{
    public class Comment
    {
        public Comment(string comment, DateTime on)
        {
            this.Content = comment;
            this.On = on;
        }

        public Comment(string comment) : this(comment, DateTime.Now) { }

        public DateTime On { get; }
        public string Content { get; }
    }
}
