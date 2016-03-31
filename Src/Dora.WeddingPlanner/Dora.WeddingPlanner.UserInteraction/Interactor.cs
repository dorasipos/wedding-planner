using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Data;
using Dora.WeddingPlanner.UserInteraction.Commands;

namespace Dora.WeddingPlanner.UserInteraction
{
    public static class Interactor
    {
        private static bool isInitialized = false;
        private static ICanStoreWeddings weddingStore;

        public static void Initialize()
        {
            if (isInitialized)
            {
                return;
            }

            weddingStore = new InMemoryWeddingStore();

            isInitialized = true;
        }

        internal static ICanStoreWeddings Store
        {
            get
            {
                EnsureInitialization();
                return weddingStore;
            }
        }

        private static void EnsureInitialization()
        {
            if (!isInitialized)
            {
                throw new InvalidOperationException("The Interactor must be initialized before doing any operation. Do so via: Interactor.Initialize();");
            }
        }

        public static CommandResult Run(ImAnInteractionCommand command)
        {
            EnsureInitialization();

            return CommandRunner.Run(command);
        }
    }
}
