using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model.DTO
{
    public sealed class PersonDto
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName).Trim();
        }
    }
}
