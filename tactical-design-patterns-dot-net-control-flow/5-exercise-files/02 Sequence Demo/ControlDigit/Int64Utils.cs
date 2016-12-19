using System;
using System.Collections.Generic;

namespace ControlDigit
{
    static class Int64Utils
    {
        public static IEnumerable<int> GetDigitsFromLeastSignificant(this Int64 number)
        {

            List<int> digits = new List<int>();
            do
            {
                int digit = (int)(number % 10);
                digits.Add(digit);
                number /= 10;
            }
            while (number > 0);

            return digits;

        }
    }
}
