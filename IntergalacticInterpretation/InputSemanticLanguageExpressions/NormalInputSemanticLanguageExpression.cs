using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NumberFormatCalculations.Abstractions;
using IntergalacticInterpretation.TerminalExpressions;
using Utilities;

namespace IntergalacticInterpretation.InputSemanticLanguageExpressions
{
    public class NormalInputSemanticLanguageExpression : BaseInputSemanticLanguageExpression
    {
        private static readonly Dictionary<string, ITerminalIsExpression<string, string>> normalInputMappingsWithTerminalIsExpressions = new Dictionary<string, ITerminalIsExpression<string, string>>();

        public NormalInputSemanticLanguageExpression(INumberFormatCalculator numberFormatCalculator,ISymbolValues<char, int> symbolValues) : base(numberFormatCalculator,symbolValues)
        {

        }

        public override void Store(string normalInput)
        {
            var trimmedNormalInput = normalInput.Trim();
            ContractUtility.Requires<ArgumentException>(trimmedNormalInput.Contains(" is "), "normalInput must contain \" is \"");
            var normalInputWordsBeforeAndAfterIs = trimmedNormalInput.Split(new string[] { " is " }, StringSplitOptions.None).Where(x => !String.IsNullOrEmpty(x));

            var normalInputWordBeforeIs = normalInputWordsBeforeAndAfterIs.FirstOrDefault();
            ContractUtility.Requires<ArgumentException>(!String.IsNullOrEmpty(normalInputWordBeforeIs) && !String.IsNullOrWhiteSpace(normalInputWordBeforeIs), "Some data must be there before \"is\" in normalInput");
            ContractUtility.Requires<ArgumentException>(!normalInputWordBeforeIs.Trim().Contains(" "), "Cannot have > 1 intergalactic words before \"is\" in normalInput");
            ContractUtility.Requires<ArgumentException>(!normalInputMappingsWithTerminalIsExpressions.ContainsKey(normalInputWordBeforeIs), "normalInput is already stored");

            var normalSymbolAfterIs = normalInputWordsBeforeAndAfterIs.LastOrDefault();
            ContractUtility.Requires<ArgumentException>(!String.IsNullOrEmpty(normalSymbolAfterIs) && !String.IsNullOrWhiteSpace(normalSymbolAfterIs), "Some data must be there after \"is\" in normalInput");
            ContractUtility.Requires<ArgumentException>(!normalSymbolAfterIs.Trim().Contains(" "), "Cannot have > 1 symbols after \"is\" in normalInput");
            var validSymbols = symbolValues.SymbolValues.Keys;
            ContractUtility.Requires<ArgumentException>(validSymbols.Select(x => x.ToString()).Contains(normalSymbolAfterIs.Trim()), "The symbol after \"is\" in normalInput must be " + CharactersUtility.GetFormattedCommaSeperatedCharacters(validSymbols,"or") + " .");

            var terminalIsExpression = new TerminalIsExpression<string, string>(normalInputWordBeforeIs, normalSymbolAfterIs);
            normalInputMappingsWithTerminalIsExpressions.Add(normalInputWordBeforeIs, terminalIsExpression);
        }

        public override int Interpret(ITerminalListExpression<string> normalIntergalacticWordsList)
        {
            ContractUtility.Requires<ArgumentOutOfRangeException>(normalIntergalacticWordsList != null && normalIntergalacticWordsList.DataList != null 
                                   && normalIntergalacticWordsList.DataList.Count > 0, "normalIntergalacticWordsList and normalIntergalacticWordsList.DataList cannot be null" +
                                   "and normalIntergalacticWordsList.DataList should be > 0");

            var accumulatedNumberFormat = new StringBuilder();
            normalIntergalacticWordsList.DataList.ForEach(x =>
                {
                    ITerminalIsExpression<string,string> terminalIsExpression = null;
                    ContractUtility.Requires<InvalidOperationException>(normalInputMappingsWithTerminalIsExpressions.TryGetValue(x, out terminalIsExpression), x + " was not supplied in the input provided earlier while storing.");
                    var numberFormat = terminalIsExpression.RightExpressionData.Data;
                    accumulatedNumberFormat.Append(numberFormat);
                }
            );
            return numberFormatCalculator.ToNumber(accumulatedNumberFormat.ToString());
        }
    }
}
