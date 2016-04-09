using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Data.Model;
using Dora.WeddingPlanner.Model;
using NDatabase;

namespace Dora.WeddingPlanner.Data.Repository.NDatabase
{
    public class NDatabaseWeddingStore : ICanStoreWeddings
    {
        private readonly string databaseFilePath;

        public NDatabaseWeddingStore(string databaseFilePath)
        {
            this.databaseFilePath = databaseFilePath;
        }

        public IEnumerable<StorableWedding> All()
        {
            using (var database = OdbFactory.Open(this.databaseFilePath))
            {
                var query = database.Query<StorableWedding>();

                foreach (var result in query.Execute<StorableWedding>())
                {
                    yield return result;
                }
            }
        }

        public Wedding Load(string id)
        {
            using (var database = OdbFactory.Open(this.databaseFilePath))
            {
                var query = database.Query<StorableWedding>();
                query.Descend("Id").Constrain(id).Equal();
                var weddingEntity = query.Execute<StorableWedding>().SingleOrDefault();

                if (weddingEntity == null)
                {
                    return null;
                }

                return weddingEntity.Wedding;
            }
        }

        public void Save(StorableWedding wedding)
        {
            using (var database = OdbFactory.Open(this.databaseFilePath))
            {
                database.Store(wedding);
            }
        }
    }
}
