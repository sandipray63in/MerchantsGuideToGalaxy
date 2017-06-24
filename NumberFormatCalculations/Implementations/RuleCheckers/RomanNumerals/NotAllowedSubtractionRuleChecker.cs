using System.Collections.Generic;
using NumberFormatCalculations.Abstractions;
using NumberFormatCalculations.Abstractions.RomanNumerals;
using Utilities;

namespace NumberFormatCalculations.Implementations.RuleCheckers.RomanNumerals
{
    public class NotAllowedSubtractionRuleChecker : BaseSymbolValuesContainer<char,int>, IRomanNumeralRuleChecker
    {
        private static List<char> notAllowedSubtractionSymbols = new List<char> { 'D', 'L', 'V' };

        public NotAllowedSubtractionRuleChecker(ISymbolValues<char, int> symbolValues) : base(symbolValues)
        {

        }

        public List<string> GetRuleViolations(char[] romanNumeralCharacters)
        {
            List<char> notAllowedSubtractionSymbolsInRomanNumeral = null;
            for (var index = 0; index < romanNumeralCharacters.Length; index++)
            {
                var currentRomanNumeralCharacter = romanNumeralCharacters[index];
                if (index + 1 != romanNumeralCharacters.Length && romanNumeralCharacters[index] != romanNumeralCharacters[index + 1] && notAllowedSubtractionSymbols.Contains(currentRomanNumeralCharacter)
                    && symbolValues.SymbolValues[currentRomanNumeralCharacter] < symbolValues.SymbolValues[romanNumeralCharacters[index + 1]])
                {
                    if (notAllowedSubtractionSymbolsInRomanNumeral == null)
                    {
                        notAllowedSubtractionSymbolsInRomanNumeral = new List<char>();
                    }
                    if (!notAllowedSubtractionSymbolsInRomanNumeral.Contains(currentRomanNumeralCharacter))
                    {
                        notAllowedSubtractionSymbolsInRomanNumeral.Add(currentRomanNumeralCharacter);
                    }
                }
            }
            if (notAllowedSubtractionSymbolsInRomanNumeral != null && notAllowedSubtractionSymbolsInRomanNumeral.Count > 0)
            {
                var violatingCharactersInRomanNumeral = CharactersUtility.GetFormattedCommaSeperatedCharacters(notAllowedSubtractionSymbolsInRomanNumeral);
                return new List<string> { { violatingCharactersInRomanNumeral + " can never be subtracted." } };
            }
            return null;
        }
    }
}
