using System.Collections.Generic;
using NumberFormatCalculations.Abstractions;

namespace NumberFormatCalculations.Implementations.SymbolValues.RomanNumerals
{
    public class RomanNumeralSymbolValues : BaseSymbolValues<char,int>
    {
        static RomanNumeralSymbolValues()
        {
            BaseSymbolValues<char, int>.symbolValues = new Dictionary<char, int>
                         { {'I',1 }, {'V',5}, {'X',10}, {'L',50}, {'C',100}, {'D',500}, {'M',1000 } };
        }
    }
}
