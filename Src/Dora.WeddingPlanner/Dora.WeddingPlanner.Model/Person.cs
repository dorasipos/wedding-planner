﻿using System;
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
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                throw new InvalidOperationException("A person must have a name");
            }

            this.FirstName = firstName;
            this.LastName = lastName;

            this.displayName = string.Format("{0} {1}", this.LastName, this.FirstName).Trim();
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string DisplayName { get { return this.displayName; } }

        public override string ToString()
        {
            return this.displayName;
        }
    }
}
