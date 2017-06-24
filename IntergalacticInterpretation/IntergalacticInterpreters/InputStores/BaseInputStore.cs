using System;
using System.Collections.Generic;
using System.Linq;
using IntergalacticInterpretation.InputSemanticLanguageExpressions;
using NumberFormatCalculations.Abstractions;
using Utilities;

namespace IntergalacticInterpretation.IntergalacticInterpreters.InputStores
{
    public class InputStore : BaseNumberFormatCalculatorAndSymbolValuesContainer<char, int>, IInputStore
    {
        public InputStore(INumberFormatCalculator numberFormatCalculator, ISymbolValues<char, int> symbolValues) : base(numberFormatCalculator,symbolValues)
        {
            
        }

        public void Store(List<string> inputTexts)
        {
            var creditsInputs = inputTexts.Where(x => x.Contains("Credits")).ToList();
            var normalInputs = inputTexts.Except(creditsInputs).ToList();
            ContractUtility.Requires<ArgumentException>(normalInputs.Count > 0, "There must be some valid input");
            var normalInputSemanticLanguageExpression = new NormalInputSemanticLanguageExpression(numberFormatCalculator, symbolValues);
            Store(normalInputSemanticLanguageExpression, normalInputs);
            var creditsInputSemanticLanguageExpression = new CreditslInputSemanticLanguageExpression(numberFormatCalculator, symbolValues);
            Store(creditsInputSemanticLanguageExpression, creditsInputs);
        }

        private void Store(IInputSemanticLanguageExpression inputSemanticLanguageExpression,List<string> inputs)
        {
            if(inputs.Count > 0)
            {
                inputs.ForEach(x =>
                    {
                        inputSemanticLanguageExpression.Store(x);
                    }
                );
            }
        }
    }
}
