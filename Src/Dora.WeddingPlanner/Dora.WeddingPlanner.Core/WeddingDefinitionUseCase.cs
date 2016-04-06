﻿using Dora.WeddingPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Data;
using Dora.WeddingPlanner.Data.Model;

namespace Dora.WeddingPlanner.Core
{
    public class WeddingDefinitionUseCase
    {
        private readonly ICanStoreWeddings weddingStore;

        public WeddingDefinitionUseCase(ICanStoreWeddings store)
        {
            this.weddingStore = store;
        }

        public KeyValuePair<Guid, Wedding> DefineNew(Person bride, Person groom)
        {
            var wedding = StorableWedding.New(new Wedding(bride, groom));
            this.weddingStore.Save(wedding);
            return new KeyValuePair<Guid, Wedding>(wedding.Id, wedding.Wedding);
        }

        public IEnumerable<KeyValuePair<Guid, Wedding>> FetchAll()
        {
            return this.weddingStore
                .All()
                .Select(w => new KeyValuePair<Guid, Wedding>(w.Id, w.Wedding));
        }

        public Wedding Load(Guid weddingId)
        {
            var wedding = this.weddingStore.Load(weddingId);
            if (wedding == null)
            {
                throw new InvalidOperationException("This wedding does not exist");
            }
            return wedding;
        }
    }
}
