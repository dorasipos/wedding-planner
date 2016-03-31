using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.UserInteraction;
using Dora.WeddingPlanner.UserInteraction.Commands;
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

            Console.WriteLine(result);

            Console.WriteLine("Done @ {0}", DateTime.Now);
            Console.ReadLine();
        }
    }
}
