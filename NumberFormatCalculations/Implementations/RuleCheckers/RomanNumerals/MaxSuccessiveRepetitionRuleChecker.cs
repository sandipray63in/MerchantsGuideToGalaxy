using System.Collections.Generic;
using NumberFormatCalculations.Abstractions.RomanNumerals;
using Utilities;

namespace NumberFormatCalculations.Implementations.RuleCheckers.RomanNumerals
{
    public class MaxSuccessiveRepetitionRuleChecker : IRomanNumeralRuleChecker
    {
        private int maxAllowedNumberOfRepetitions;
        private static char[] allowedRepetitionSymbols = new char[] { 'I', 'X', 'C','M' };

        public MaxSuccessiveRepetitionRuleChecker(int maxAllowedNumberOfRepetitions = 3)
        {
            this.maxAllowedNumberOfRepetitions = maxAllowedNumberOfRepetitions;
        }

        public List<string> GetRuleViolations(char[] romanNumeralCharacters)
        {
            var symbolsWithExceededNumberOfRepetitionsInRomanNumeral = CharactersUtility.GetAllCharactersSatisfyingNumberOfSuppliedRepetitionsOrMore(romanNumeralCharacters, maxAllowedNumberOfRepetitions, allowedRepetitionSymbols);
            if (symbolsWithExceededNumberOfRepetitionsInRomanNumeral != null && symbolsWithExceededNumberOfRepetitionsInRomanNumeral.Length > 0)
            {
                var violatingCharactersInRomanNumeral = CharactersUtility.GetFormattedCommaSeperatedCharacters(symbolsWithExceededNumberOfRepetitionsInRomanNumeral);
                return new List<string> { { violatingCharactersInRomanNumeral + " can never be repeated more than " + maxAllowedNumberOfRepetitions + " times ." } };
            }
            return null;
        }
    }
}
