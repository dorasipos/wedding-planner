using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Tracing
{
    internal static class Wrappers
    {
        public static void MeasureActionWith(Action actionToMeasure, params IDisposable[] measureTools)
        {
            actionToMeasure();

            for (var i = measureTools.Length - 1; i >= 0; i--)
            {
                measureTools[i].Dispose();
            }
        }

        public static T MeasureFunctionWith<T>(Func<T> functionToMeasure, params IDisposable[] measureTools)
        {
            T result = default(T);
            MeasureActionWith(() => { result = functionToMeasure(); }, measureTools);
            return result;
        }
    }
}
