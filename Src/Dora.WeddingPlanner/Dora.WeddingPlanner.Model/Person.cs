using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Model
{
    public class Person
    {
        private readonly string displayName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            this.displayName = string.Format("{0} {2}", this.LastName, this.FirstName).Trim();
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string DisplayName { get { return this.displayName; } }
    }
}
