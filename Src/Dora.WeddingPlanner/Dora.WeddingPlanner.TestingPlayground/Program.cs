using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction;
using Dora.WeddingPlanner.UserInteraction.Commands;
using Dora.WeddingPlanner.UserInteraction.Commands.Weddings;
using Dora.WeddingPlanner.UserInteraction.Model;

namespace Dora.WeddingPlanner.TestingPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            Interactor.Initialize();
            var result = Interactor.Run(new CreateWeddingCommand
            {
                Bride = new PersonDto { FirstName = "Ana", LastName = "Blandiana" },
                Groom = new PersonDto { FirstName = "David", LastName = "Morar" }
            });
            var id = Guid.Parse(result.Details);

            Console.WriteLine(result);

            var result2 = Interactor.Run(new CreateWeddingTaskCommand
            {
                WeddingId = id,
                Description = "Scout for a place regarding the wedding reception",
                Title = "Find a place for the Wedding reception"
            });

            Console.WriteLine(result);

            Console.WriteLine("Done @ {0}", DateTime.Now);
            Console.ReadLine();
        }
    }
}
