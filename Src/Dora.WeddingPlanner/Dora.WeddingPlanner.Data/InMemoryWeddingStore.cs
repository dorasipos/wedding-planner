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
            if (!weddingDictionary.ContainsKey(id))
            {
                return null;
            }
            return weddingDictionary[id];
        }

        public void Save(StorableWedding wedding)
        {
            if (!weddingDictionary.ContainsKey(wedding.Id))
            {
                weddingDictionary.Add(wedding.Id, wedding.Wedding);
                return;
            }
            weddingDictionary[wedding.Id] = wedding.Wedding;
        }
    }
}
