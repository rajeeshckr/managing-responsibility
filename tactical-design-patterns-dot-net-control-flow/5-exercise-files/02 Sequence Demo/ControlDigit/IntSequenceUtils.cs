using System.Collections.Generic;
using System.Linq;

namespace ControlDigit
{
    static class IntSequenceUtils
    {
        public static IEnumerable<int> AddWeights(this IEnumerable<int> values, IEnumerable<int> factors)
        {
            return values.Zip(factors, (v, f) => v * f);
        }
    }
}
