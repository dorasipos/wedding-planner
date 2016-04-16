using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Model;
using Dora.WeddingPlanner.Model.WeddingTasks;
using Dora.WeddingPlanner.Model.WeddingTasks.Predefined;
using Dora.WeddingPlanner.Model.DTO.Mapping;

namespace Dora.WeddingPlanner.TestingPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            var wedding = new Wedding(new Person("Pop", "Bia"), new Person("Pop", "Ion"));
            wedding.AddTask(new PlanCivilCeremonyTask().Describe("Test"));

            var dto = wedding.Map();


            Console.WriteLine("Done @ {0}", DateTime.Now);
            Console.ReadLine();
        }
    }
}
