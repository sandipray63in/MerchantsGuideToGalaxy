using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace NumberFormatCalculations.Abstractions.RomanNumerals
{
    public abstract class RomanNumeralCalculator : INumberFormatCalculator
    {
        protected ISymbolValues<char, int> symbolValues;
        private List<IRomanNumeralRuleChecker> ruleCheckers;

        public RomanNumeralCalculator(ISymbolValues<char, int> symbolValues, List<IRomanNumeralRuleChecker> ruleCheckers)
        {
            this.symbolValues = symbolValues;
            this.ruleCheckers = ruleCheckers;
        }

        public int ToNumber(string romanNumeral)
        {
            return Calculate(GetRomanNumeralCharactersAfterCheckingAllRules(romanNumeral));
        }

        public abstract string ToNumberFormat(int number);

        private char[] GetRomanNumeralCharactersAfterCheckingAllRules(string romanNumeral)
        {
            var romanNumeralCharacters = romanNumeral.ToCharArray();
            var notSupportedCharacters = romanNumeralCharacters.Except(symbolValues.SymbolValues.Keys.ToArray());
            ContractUtility.Requires<InvalidCastException>(notSupportedCharacters == null || notSupportedCharacters.Count() < 1, () => "The character(s) viz. " + CharactersUtility.GetFormattedCommaSeperatedCharacters(notSupportedCharacters) + " are not supported.");
            if (this.ruleCheckers != null && this.ruleCheckers.Count > 0)
            {
                var rulesViolations = GetAllRulesViolations(romanNumeralCharacters);
                ContractUtility.Requires<ApplicationException>(rulesViolations == null || rulesViolations.Count < 1, () => rulesViolations.Aggregate((a, b) => a + Environment.NewLine + b));
            }
            return romanNumeralCharacters;
        }


        protected List<string> GetAllRulesViolations(char[] romanNumeralCharacters)
        {
            List<string> rulesViolations = null;
            this.ruleCheckers.ForEach(ruleChecker =>
             {
                 var currentRuleCheckerViolations = ruleChecker.GetRuleViolations(romanNumeralCharacters);
                 if (currentRuleCheckerViolations != null && currentRuleCheckerViolations.Count > 0)
                 {
                     if (rulesViolations == null)
                     {
                         rulesViolations = new List<string>();
                     }
                     rulesViolations.AddRange(currentRuleCheckerViolations);
                 }
             }
            );
            return rulesViolations;
        }

        protected abstract int Calculate(char[] romanNumeralCharacters);

    }
}
