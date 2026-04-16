using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM_DoorsLibrary
{
    internal static class SharedExpression
    {
        internal static int Round(this double d)
        {
            var cel = Math.Truncate(d);
            var tmp = d - cel;
            return tmp > 0 ? (int)cel++ : (int)cel;
        }
    }
}
