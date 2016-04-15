using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.WeddingPlanner.Tracing
{
    public static class Trace
    {
        public static Action Able(Action action)
        {
            return action;
        }

        public static Func<T> Able<T>(Func<T> func)
        {
            return func;
        }

        public static Func<T> Able<P, T>(Func<P, T> func, P param)
        {
            return new Func<T>(() => func(param));
        }

        public static Func<T> Able<P1, P2, T>(Func<P1, P2, T> func, P1 p1, P2 p2)
        {
            return new Func<T>(() => func(p1, p2));
        }
    }
}
