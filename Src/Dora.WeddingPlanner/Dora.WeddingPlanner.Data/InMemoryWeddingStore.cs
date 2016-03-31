using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Data.Model;
using Dora.WeddingPlanner.Model;

namespace Dora.WeddingPlanner.Data
{
    public class InMemoryWeddingStore : ICanStoreWeddings
    {
        private readonly Dictionary<Guid, Wedding> weddingDictionary = new Dictionary<Guid, Wedding>();

        public Wedding Load(Guid id)
        {
            return weddingDictionary[id];
        }

        public void Save(StorableWedding wedding)
        {
            weddingDictionary.Add(wedding.Id, wedding.Wedding);
        }
    }
}
