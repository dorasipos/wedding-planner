﻿using Dora.WeddingPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Data;
using Dora.WeddingPlanner.Data.Model;
using Dora.WeddingPlanner.Logging;
using Dora.WeddingPlanner.Tracing;
using NLog;

namespace Dora.WeddingPlanner.Core
{
    public sealed class WeddingDefinitionUseCase
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private readonly ICanStoreWeddings weddingStore;

        public WeddingDefinitionUseCase(ICanStoreWeddings store)
        {
            this.weddingStore = store;
        }

        public KeyValuePair<string, Wedding> DefineNew(Person bride, Person groom)
        {
            var wedding = StorableWedding.New(new Wedding(bride, groom));
            this.weddingStore.Save(wedding);
            return new KeyValuePair<string, Wedding>(wedding.Id, wedding.Wedding);
        }

        public IEnumerable<KeyValuePair<string, Wedding>> FetchAll()
        {
            return this.weddingStore
                .All()
                .Select(w => new KeyValuePair<string, Wedding>(w.Id, w.Wedding));
        }

        public Wedding Load(string weddingId)
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
