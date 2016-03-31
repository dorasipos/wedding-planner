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
        private StorableWedding(Wedding wedding, Guid id)
        {
            this.Wedding = wedding;
            this.Id = id;
        }

        private StorableWedding(Wedding wedding)
            : this(wedding, Guid.NewGuid())
        { }

        public Guid Id { get; }
        public Wedding Wedding { get; }

        public static StorableWedding New(Wedding wedding)
        {
            return new StorableWedding(wedding);
        }

        public static StorableWedding Existing(Guid id, Wedding wedding)
        {
            return new StorableWedding(wedding, id);
        }
    }
}
