using System.Collections.Generic;

namespace NumberFormatCalculations.Abstractions.RomanNumerals
{
    public interface IRomanNumeralRuleChecker
    {
        List<string> GetRuleViolations(char[] romanNumeralCharacters);
    }
}
