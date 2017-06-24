using System;
using System.Linq;
using NumberFormatCalculations.Abstractions;
using IntergalacticInterpretation.Enums;
using IntergalacticInterpretation.InputSemanticLanguageExpressions;
using IntergalacticInterpretation.TerminalExpressions;
using Utilities;

namespace IntergalacticInterpretation.QueryExpressions
{
    public class CreditsQueryExpression : BaseQueryExpression
    {
        public CreditsQueryExpression(INumberFormatCalculator numberFormatCalculator, ISymbolValues<char, int> symbolValues) : base(numberFormatCalculator, symbolValues)
        {
        }

        protected override void ValidateQueryInputBeforeIs(string queryInputWordsBeforeIs)
        {
            ContractUtility.Requires<ArgumentException>(queryInputWordsBeforeIs.Trim() == "how many Credits", "Query input before \"is\" must be \"how many Credits\"");
        }

        protected override string BuildIntergalacticWordsListAndGetOutputToReturn(string queryInputWordsAfterIsButBeforeQuestionMark)
        {
            var allowedCreditTypes = Enum.GetNames(typeof(CreditsType));
            ContractUtility.Requires<ArgumentException>(allowedCreditTypes.Any(x => queryInputWordsAfterIsButBeforeQuestionMark.Trim().EndsWith(x)), "The last word in the query after \"is\" but before \"?\" should be any of " + allowedCreditTypes.Aggregate((a,b) => a + " , " + b) + ".");
            var queryInputWordsListAfterIsButBeforeQuestionMark = queryInputWordsAfterIsButBeforeQuestionMark.Split(new string[] { " " }, StringSplitOptions.None).Where(x => !String.IsNullOrEmpty(x)).ToList();
            var queryInputWordsListAfterIsButBeforeQuestionMarkTerminalListExpression = new TerminalListExpression<string>(queryInputWordsListAfterIsButBeforeQuestionMark);
            var creditsInputSemanticLanguageExpression = new CreditslInputSemanticLanguageExpression(numberFormatCalculator, symbolValues);
            return queryInputWordsAfterIsButBeforeQuestionMark + " is " + creditsInputSemanticLanguageExpression.Interpret(queryInputWordsListAfterIsButBeforeQuestionMarkTerminalListExpression) + " Credits";
        }
    }
}
