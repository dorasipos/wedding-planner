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

        public static bool TryAction(Action action, out Exception exception)
        {
            exception = null;
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool TryFunction<T>(Func<T> func, out T result, out Exception exception)
        {
            exception = null;
            try
            {
                result = func();
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                result = default(T);
                return false;
            }
        }
    }
}
