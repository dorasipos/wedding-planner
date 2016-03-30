using Dora.WeddingPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Core
{
    public class WeddingUseCase
    {
        public Wedding DefineNew(Person bride, Person groom)
        {
            return new Wedding(bride, groom);
        }
    }
}
