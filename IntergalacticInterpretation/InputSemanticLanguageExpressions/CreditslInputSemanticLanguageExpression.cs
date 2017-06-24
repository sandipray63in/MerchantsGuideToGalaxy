using System;
using System.Collections.Generic;
using System.Linq;
using NumberFormatCalculations.Abstractions;
using IntergalacticInterpretation.Enums;
using IntergalacticInterpretation.TerminalExpressions;
using Utilities;

namespace IntergalacticInterpretation.InputSemanticLanguageExpressions
{
    public class CreditslInputSemanticLanguageExpression : BaseInputSemanticLanguageExpression
    {
        private static readonly Dictionary<string, ITerminalIsExpression<string, decimal>> creditsInputMappingsWithTerminalIsExpressions = new Dictionary<string, ITerminalIsExpression<string, decimal>>();

        public CreditslInputSemanticLanguageExpression(INumberFormatCalculator numberFormatCalculator, ISymbolValues<char, int> symbolValues) : base(numberFormatCalculator, symbolValues)
        {

        }

        public override void Store(string creditsInput)
        {
            var trimmedCreditsInput = creditsInput.Trim();
            ContractUtility.Requires<ArgumentException>(trimmedCreditsInput.Contains(" is "), "creditsInput must contain \" is \"");
            ContractUtility.Requires<ArgumentException>(trimmedCreditsInput.Trim().EndsWith("Credits"), "creditsInput must must end with \"Credits\"");
            var creditsInputWordsBeforeAndAfterIs = trimmedCreditsInput.Split(new string[] { " is " }, StringSplitOptions.None).Where(x => !String.IsNullOrEmpty(x));

            var creditsInputWordsBeforeIs = creditsInputWordsBeforeAndAfterIs.FirstOrDefault();
            ContractUtility.Requires<ArgumentException>(!String.IsNullOrEmpty(creditsInputWordsBeforeIs) && !String.IsNullOrWhiteSpace(creditsInputWordsBeforeIs), "Some data must be there before \"is\" in creditsInput");
            var creditsInputWordsListBeforeIs = creditsInputWordsBeforeIs.Split(new string[] { " " }, StringSplitOptions.None).Where(x => !String.IsNullOrEmpty(x.Trim()));
            var creditsTypeInputWordJustBeforeIs = creditsInputWordsListBeforeIs.LastOrDefault();
            var allowedCreditTypes = Enum.GetNames(typeof(CreditsType));
            ContractUtility.Requires<ArgumentException>(!String.IsNullOrEmpty(creditsTypeInputWordJustBeforeIs) && allowedCreditTypes.Contains(creditsTypeInputWordJustBeforeIs), "The input word just before \"is\" must be any one of " + allowedCreditTypes.Aggregate((a, b) => a + " , " + b) + " .");
            ContractUtility.Requires<ArgumentException>(!creditsInputMappingsWithTerminalIsExpressions.ContainsKey(creditsTypeInputWordJustBeforeIs), "creditsInput relevant data is already stored");

            var inputValueCreditsAfterIs = creditsInputWordsBeforeAndAfterIs.LastOrDefault();
            ContractUtility.Requires<ArgumentException>(!String.IsNullOrEmpty(inputValueCreditsAfterIs) && !String.IsNullOrWhiteSpace(inputValueCreditsAfterIs), "Some data must be there after \"is\" in creditsInput");
            var inputValuesJustAfterIs = inputValueCreditsAfterIs.Trim().Split(new string[]{ " Credits"}, StringSplitOptions.None).Where(x => !String.IsNullOrEmpty(x));
            ContractUtility.Requires<ArgumentException>(inputValuesJustAfterIs.Count() == 1, "There must be atleast one and only one value between \"is\" and \"Credits\"  in creditsInput");
            var inputValueJustAfterIs = inputValuesJustAfterIs.FirstOrDefault();
            var intInputValueJustAfterIs = 0;
            ContractUtility.Requires<ArgumentException>(!String.IsNullOrEmpty(inputValueJustAfterIs) && Int32.TryParse(inputValueJustAfterIs, out intInputValueJustAfterIs), "The value of the data between \"is\" and \"Credits\" in creditsInput must be of integer type");

            var normalInputWordsListBeforeCreditsType = creditsInputWordsListBeforeIs.Where(x => x != creditsTypeInputWordJustBeforeIs).ToList();
            var normalInputWordsListBeforeCreditsTypeNumberFormatValue = 1;
            if (normalInputWordsListBeforeCreditsType.Count > 0)
            {
                var normalInputSemanticLanguageExpression = new NormalInputSemanticLanguageExpression(numberFormatCalculator, symbolValues);
                var normalIntergalacticWordsList = new TerminalListExpression<string>(normalInputWordsListBeforeCreditsType);
                normalInputWordsListBeforeCreditsTypeNumberFormatValue = normalInputSemanticLanguageExpression.Interpret(normalIntergalacticWordsList);
            }
            decimal creditsTypeValue = Convert.ToDecimal(intInputValueJustAfterIs) / Convert.ToDecimal(normalInputWordsListBeforeCreditsTypeNumberFormatValue);

            var terminalIsExpression = new TerminalIsExpression<string, decimal>(creditsTypeInputWordJustBeforeIs, creditsTypeValue);
            creditsInputMappingsWithTerminalIsExpressions.Add(creditsTypeInputWordJustBeforeIs, terminalIsExpression);
        }

        public override int Interpret(ITerminalListExpression<string> creditsIntergalacticWordsList)
        {
            ContractUtility.Requires<ArgumentOutOfRangeException>(creditsIntergalacticWordsList != null && creditsIntergalacticWordsList.DataList != null
                                   && creditsIntergalacticWordsList.DataList.Count > 0, "normalIntergalacticWordsList and normalIntergalacticWordsList.DataList cannot be null" +
                                   "and normalIntergalacticWordsList.DataList should be > 0");
            var creditsTypeInputWordJustBeforeIs = creditsIntergalacticWordsList.DataList.LastOrDefault();
            var allowedCreditTypes = Enum.GetNames(typeof(CreditsType));
            ContractUtility.Requires<ArgumentException>(!String.IsNullOrEmpty(creditsTypeInputWordJustBeforeIs) && allowedCreditTypes.Contains(creditsTypeInputWordJustBeforeIs), "The last word must be any one of " + allowedCreditTypes.Aggregate((a, b) => a + " , " + b) + " .");

            ITerminalIsExpression<string, decimal> terminalIsExpression = null;
            ContractUtility.Requires<InvalidOperationException>(creditsInputMappingsWithTerminalIsExpressions.TryGetValue(creditsTypeInputWordJustBeforeIs, out terminalIsExpression), creditsTypeInputWordJustBeforeIs + " was not supplied in the input provided earlier while storing.");

            var normalInputWordsListBeforeCreditsType = creditsIntergalacticWordsList.DataList.Except(new List<string> { creditsTypeInputWordJustBeforeIs }).ToList();
            var normalInputWordsListBeforeCreditsTypeNumberFormatValue = 1;
            if (normalInputWordsListBeforeCreditsType.Count > 0)
            {
                var normalInputSemanticLanguageExpression = new NormalInputSemanticLanguageExpression(numberFormatCalculator, symbolValues);
                var normalIntergalacticWordsList = new TerminalListExpression<string>(normalInputWordsListBeforeCreditsType);
                normalInputWordsListBeforeCreditsTypeNumberFormatValue = normalInputSemanticLanguageExpression.Interpret(normalIntergalacticWordsList);
            }

            return Convert.ToInt32(normalInputWordsListBeforeCreditsTypeNumberFormatValue * terminalIsExpression.RightExpressionData.Data);
        }
    }
}
