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
                var fields = database.ValuesQuery<StorableWedding>()
                    .Field("Id", "Id")
                    .Field("Wedding.bride", "Bride")
                    .Field("Wedding.groom", "Groom")
                    .Execute();

                foreach (var field in fields)
                {
                    yield return StorableWedding.Existing((string)field.GetByAlias("Id"), new Wedding((Person)field.GetByAlias("Bride"), (Person)field.GetByAlias("Groom")));
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
