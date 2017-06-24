using System.Collections.Generic;
using NumberFormatCalculations.Abstractions.RomanNumerals;
using Utilities;

namespace NumberFormatCalculations.Implementations.RuleCheckers.RomanNumerals
{
    public class NotAllowedRepetitionRuleChecker : IRomanNumeralRuleChecker
    {
        private static char[] notAllowedRepetitionSymbols = new char[] { 'D', 'L', 'V' };

        public List<string> GetRuleViolations(char[] romanNumeralCharacters)
        {
            var notAllowedRepetitionSymbolsInRomanNumeral = CharactersUtility.GetAllCharactersSatisfyingNumberOfSuppliedRepetitionsOrMore(romanNumeralCharacters, charactersToCheck : notAllowedRepetitionSymbols);
            if (notAllowedRepetitionSymbolsInRomanNumeral != null && notAllowedRepetitionSymbolsInRomanNumeral.Length > 0)
            {
                var violatingCharactersInRomanNumeral = CharactersUtility.GetFormattedCommaSeperatedCharacters(notAllowedRepetitionSymbolsInRomanNumeral);
                return new List<string> { { violatingCharactersInRomanNumeral + " can never be repeated." } };
            }
            return null;
        }
    }
}
 