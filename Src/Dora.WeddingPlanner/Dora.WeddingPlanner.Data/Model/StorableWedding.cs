using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Model;

namespace Dora.WeddingPlanner.Data.Model
{
    public class StorableWedding
    {
        private StorableWedding(Wedding wedding, string id)
        {
            this.Wedding = wedding;
            this.Id = id;
        }

        private StorableWedding(Wedding wedding)
            : this(wedding, Guid.NewGuid().ToString())
        { }

        public string Id { get; private set; }
        public Wedding Wedding { get; private set; }

        public static StorableWedding New(Wedding wedding)
        {
            return new StorableWedding(wedding);
        }

        public static StorableWedding Existing(string id, Wedding wedding)
        {
            return new StorableWedding(wedding, id);
        }
    }
}
