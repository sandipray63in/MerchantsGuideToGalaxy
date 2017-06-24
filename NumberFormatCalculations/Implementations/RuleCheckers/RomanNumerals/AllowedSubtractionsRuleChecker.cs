using System;
using System.Collections.Generic;
using System.Linq;
using NumberFormatCalculations.Abstractions.RomanNumerals;
using Utilities;

namespace NumberFormatCalculations.Implementations.RuleCheckers.RomanNumerals
{
    public class AllowedSubtractionsRuleChecker : IRomanNumeralRuleChecker
    {
        private static IList<Tuple<char,char>> allowedNextSymbolsForSubtraction = new List<Tuple<char, char>>
                                 {
                                  Tuple.Create<char, char>('I','V'),
                                  Tuple.Create<char, char>('I','X'),
                                  Tuple.Create<char, char>('X','L'),
                                  Tuple.Create<char, char>('X','C'),
                                  Tuple.Create<char, char>('C','D'),
                                  Tuple.Create<char, char>('C','M')
                                 };

        public List<string> GetRuleViolations(char[] romanNumeralCharacters)
        {
            List<string> allowedNextSymbolForSubtractionRuleViolations = null;
            for (var index = 0; index < romanNumeralCharacters.Length; index++)
            {
                var currentRomanNumeralCharacter = romanNumeralCharacters[index];
                if (index + 1 != romanNumeralCharacters.Length && romanNumeralCharacters[index] != romanNumeralCharacters[index + 1] && allowedNextSymbolsForSubtraction.Any(x => x.Item1 == currentRomanNumeralCharacter))
                {
                    var allowedNextSymbolsForSubtractionValues = allowedNextSymbolsForSubtraction.Where(x => x.Item1 == currentRomanNumeralCharacter).Select(x => x.Item2);
                    if (!allowedNextSymbolsForSubtractionValues.Contains(romanNumeralCharacters[index + 1]))
                    {
                        if (allowedNextSymbolForSubtractionRuleViolations == null)
                        {
                            allowedNextSymbolForSubtractionRuleViolations = new List<string>();
                        }
                        allowedNextSymbolForSubtractionRuleViolations.Add(currentRomanNumeralCharacter + " can be subtracted from " + CharactersUtility.GetFormattedCommaSeperatedCharacters(allowedNextSymbolsForSubtractionValues) + " only");
                    }
                }
            }
            return allowedNextSymbolForSubtractionRuleViolations;
        }
    }
}
