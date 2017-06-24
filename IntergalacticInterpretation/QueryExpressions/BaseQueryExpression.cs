using System;
using System.Linq;
using NumberFormatCalculations.Abstractions;
using Utilities;

namespace IntergalacticInterpretation.QueryExpressions
{
    public abstract class BaseQueryExpression : BaseNumberFormatCalculatorAndSymbolValuesContainer<char, int>, IQueryExpression
    {

        public BaseQueryExpression(INumberFormatCalculator numberFormatCalculator, ISymbolValues<char, int> symbolValues) : base(numberFormatCalculator,symbolValues)
        {
            
        }
        public string Interpret(string queryInput)
        {
            var trimmedQueryInput = queryInput.Trim();
            ContractUtility.Requires<ArgumentException>(trimmedQueryInput.Contains(" is ") && trimmedQueryInput.EndsWith("?"), "queryInput must contain \"is\" and must end with \"?\"");
            var queryInputWordsBeforeAndAfterIs = trimmedQueryInput.Split(new string[] { " is " }, StringSplitOptions.None).Where(x => !String.IsNullOrEmpty(x));
            var queryInputWordsBeforeIs = queryInputWordsBeforeAndAfterIs.FirstOrDefault();
            ValidateQueryInputBeforeIs(queryInputWordsBeforeIs);
            var queryInputWordsAfterIs = queryInputWordsBeforeAndAfterIs.Last();
            var queryInputWordsAfterIsButBeforeQuestionMark = queryInputWordsAfterIs.Substring(0, queryInputWordsAfterIs.LastIndexOf("?") - 1);
            return BuildIntergalacticWordsListAndGetOutputToReturn(queryInputWordsAfterIsButBeforeQuestionMark);
        }

        protected abstract void ValidateQueryInputBeforeIs(string queryInputWordsBeforeIs);
        protected abstract string BuildIntergalacticWordsListAndGetOutputToReturn(string queryInputWordsAfterIsButBeforeQuestionMark);
    }
}
