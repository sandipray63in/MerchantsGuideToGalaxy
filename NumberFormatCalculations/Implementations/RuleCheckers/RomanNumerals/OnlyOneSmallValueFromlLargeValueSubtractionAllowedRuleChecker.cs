using System.Collections.Generic;
using NumberFormatCalculations.Abstractions;
using NumberFormatCalculations.Abstractions.RomanNumerals;

namespace NumberFormatCalculations.Implementations.RuleCheckers.RomanNumerals
{
    public class OnlyOneSmallValueFromlLargeValueSubtractionAllowedRuleChecker : BaseSymbolValuesContainer<char, int>, IRomanNumeralRuleChecker
    {
        public OnlyOneSmallValueFromlLargeValueSubtractionAllowedRuleChecker(ISymbolValues<char, int> symbolValues) : base(symbolValues)
        {
        }

        public List<string> GetRuleViolations(char[] romanNumeralCharacters)
        {
            for (var index = 1; index < romanNumeralCharacters.Length; index++)
            {
                if (index + 1 != romanNumeralCharacters.Length && romanNumeralCharacters[index] != romanNumeralCharacters[index + 1] && symbolValues.SymbolValues[romanNumeralCharacters[index - 1]] < symbolValues.SymbolValues[romanNumeralCharacters[index]]
                    && symbolValues.SymbolValues[romanNumeralCharacters[index]] < symbolValues.SymbolValues[romanNumeralCharacters[index + 1]])
                {
                    return new List<string> { { "Only one small-value symbol may be subtracted from any large-value symbol." } };
                }
            }
            return null;
        }
    }
}
