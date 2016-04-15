using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.WeddingPlanner.Data;
using Dora.WeddingPlanner.UserInteraction.Commands;
using Dora.WeddingPlanner.UserInteraction.Queries;
using Dora.WeddingPlanner.Data.Persistence.FileSystem;
using Dora.WeddingPlanner.Data.Repository.NDatabase;
using Dora.WeddingPlanner.Logging;
using Dora.WeddingPlanner.Tracing;
using NLog;

namespace Dora.WeddingPlanner.UserInteraction
{
    public static class Interactor
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private static bool isInitialized = false;
        private static ICanStoreWeddings weddingStore;

        public static void Initialize()
        {
            if (isInitialized)
            {
                return;
            }

            Trace.Able(InitializeStore).MeasureWith(log.Timing("Load wedding store"));

            isInitialized = true;
        }

        private static void InitializeStore()
        {
            weddingStore = new NDatabaseWeddingStore("WeddingStore.ndata.odb");
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

        public static CommandResult<TResult> Run<TResult>(ImAnInteractionCommand<TResult> command)
        {
            EnsureInitialization();

            return Trace.Able(CommandAndQueryRunner.Run, command)
                .MeasureWith(log.Timing(string.Format("Run Command {0}", command)));
        }

        public static QueryResult<TResult> Query<TResult, TParameter>(ImAQuery<TResult, TParameter> query, TParameter parameter)
        {
            EnsureInitialization();

            return Trace.Able(CommandAndQueryRunner.Query, query, parameter)
                .MeasureWith(log.Timing(string.Format("Run Query {0}{1}{2}", query, parameter != null ? " with parameter: " : string.Empty, parameter)));
        }
    }
}
