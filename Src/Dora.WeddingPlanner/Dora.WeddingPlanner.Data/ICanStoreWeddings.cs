using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Data.Model;
using Dora.WeddingPlanner.Model;

namespace Dora.WeddingPlanner.Data
{
    public interface ICanStoreWeddings
    {
        void Save(StorableWedding wedding);
        Wedding Load(Guid id);
        IEnumerable<StorableWedding> All();
    }
}
