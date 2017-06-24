using System;
using System.Linq;
using NumberFormatCalculations.Abstractions;
using IntergalacticInterpretation.InputSemanticLanguageExpressions;
using IntergalacticInterpretation.TerminalExpressions;
using Utilities;

namespace IntergalacticInterpretation.QueryExpressions
{
    public class NormalQueryExpression : BaseQueryExpression
    {
        public NormalQueryExpression(INumberFormatCalculator numberFormatCalculator, ISymbolValues<char, int> symbolValues) : base(numberFormatCalculator, symbolValues)
        {
        }

        protected override void ValidateQueryInputBeforeIs(string queryInputWordsBeforeIs)
        {
            ContractUtility.Requires<ArgumentException>(queryInputWordsBeforeIs.Trim() == "how much", "Query input before \"is\" must be \"how much\"");
        }

        protected override string BuildIntergalacticWordsListAndGetOutputToReturn(string queryInputWordsAfterIsButBeforeQuestionMark)
        {
            var queryInputWordsListAfterIsButBeforeQuestionMark = queryInputWordsAfterIsButBeforeQuestionMark.Split(new string[] { " " }, StringSplitOptions.None).Where(x => !String.IsNullOrEmpty(x.Trim())).ToList();
            ContractUtility.Requires<ArgumentException>(queryInputWordsListAfterIsButBeforeQuestionMark.Count > 0, "Words count before \"is\" in the input query must be > 0");
            var queryInputWordsListAfterIsButBeforeQuestionMarkTerminalListExpression = new TerminalListExpression<string>(queryInputWordsListAfterIsButBeforeQuestionMark);
            var normalInputSemanticLanguageExpression = new NormalInputSemanticLanguageExpression(numberFormatCalculator, symbolValues);
            return queryInputWordsAfterIsButBeforeQuestionMark + " is " + normalInputSemanticLanguageExpression.Interpret(queryInputWordsListAfterIsButBeforeQuestionMarkTerminalListExpression);
        }
    }
}
