using Dora.WeddingPlanner.Model;
using Dora.WeddingPlanner.UserInteraction.Model;
using Dora.WeddingPlanner.UserInteraction.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.UserInteraction.UseCase
{
    public class WeddingUseCase
    {
        public Wedding DefineNew(PersonDto bride, PersonDto groom)
        {
            return new Wedding(bride.Map(), groom.Map());
        }
    }
}
