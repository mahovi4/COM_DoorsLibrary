using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM_DoorsLibrary
{
    internal static class Shared
    {
        internal static bool EqualsDouble(this double left, double right)
        {
            return Math.Abs(left - right) < 0.0000001;
        }
    }
}
