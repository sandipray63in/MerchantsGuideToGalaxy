using System;
using System.Collections.Generic;
using System.Text;
using NumberFormatCalculations.Abstractions;
using NumberFormatCalculations.Abstractions.RomanNumerals;
using Utilities;

namespace NumberFormatCalculations.Implementations.Calculators.RomanNumerals
{
    public class StandardRomanNumeralCalculator : RomanNumeralCalculator
    {
        private static string[] roman1 = { "MMM", "MM", "M" };
        private static string[] roman2 = { "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C" };
        private static string[] roman3 = { "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X" };
        private static string[] roman4 = { "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };

        public StandardRomanNumeralCalculator(ISymbolValues<char, int> symbolValues, List<IRomanNumeralRuleChecker> ruleCheckers) : base(symbolValues,ruleCheckers)
        {

        }

        public override string ToNumberFormat(int number)
        {
            ContractUtility.Requires<ArgumentException>(number > 3999, "Too big - can't exceed 3999");
            ContractUtility.Requires<ArgumentException>(number < 1, "Too small - can't be less than 1");
            int thousands, hundreds, tens, units;
            thousands = number / 1000;
            number %= 1000;
            hundreds = number / 100;
            number %= 100;
            tens = number / 10;
            units = number % 10;
            var numberFormat = new StringBuilder();
            if (thousands > 0) numberFormat.Append(roman1[3 - thousands]);
            if (hundreds > 0) numberFormat.Append(roman2[9 - hundreds]);
            if (tens > 0) numberFormat.Append(roman3[9 - tens]);
            if (units > 0) numberFormat.Append(roman4[9 - units]);
            return numberFormat.ToString();
        }

        protected override int Calculate(char[] characters)
        {
            var totalValue = 0;
            var incrementBy = 1;
            for(int i =0; i < characters.Length;i+= incrementBy)
            {
                var currentValue = symbolValues.SymbolValues[characters[i]];
                var nextValue = i + 1 == characters.Length ? Int32.MinValue : symbolValues.SymbolValues[characters[i+1]];
                if (currentValue >= nextValue)
                {
                    totalValue += currentValue;
                    incrementBy = 1;
                }
                else
                {
                    totalValue += nextValue - currentValue;
                    incrementBy = 2;
                }
            }
            return totalValue;
        }
    }
}
