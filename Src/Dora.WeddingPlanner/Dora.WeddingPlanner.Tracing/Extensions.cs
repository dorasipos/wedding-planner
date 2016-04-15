using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Tracing
{
    public static class Extensions
    {
        public static void MeasureWith(this Action action, params IDisposable[] measureTools)
        {
            Wrappers.MeasureActionWith(action, measureTools);
        }

        public static T MeasureWith<T>(this Func<T> action, params IDisposable[] measureTools)
        {
            return Wrappers.MeasureFunctionWith(action, measureTools);
        }

        public static bool Try(this Action action, out Exception exception)
        {
            return Wrappers.TryAction(action, out exception);
        }

        public static bool Try<T>(this Func<T> func, out T result, out Exception exception)
        {
            return Wrappers.TryFunction(func, out result, out exception);
        }
    }
}
