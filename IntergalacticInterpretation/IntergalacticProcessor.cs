using System.Collections.Generic;
using System.Linq;
using NumberFormatCalculations.Abstractions;
using IntergalacticInterpretation.IntergalacticInterpreters.InputStores;
using IntergalacticInterpretation.IntergalacticInterpreters.QueryInterpreters;

namespace IntergalacticInterpretation
{
    public class IntergalacticProcessor : BaseNumberFormatCalculatorAndSymbolValuesContainer<char, int>
    {
        public IntergalacticProcessor(INumberFormatCalculator numberFormatCalculator, ISymbolValues<char, int> symbolValues) : base(numberFormatCalculator,symbolValues)
        {
            
        }

        public List<string> Process(List<string> inputTexts)
        {
            var queryTexts = inputTexts.Where(x => x.Trim().EndsWith("?")).ToList();
            var intergalacticWordsTexts = inputTexts.Except(queryTexts).ToList();
            var inputStore = new InputStore(numberFormatCalculator, symbolValues);
            inputStore.Store(intergalacticWordsTexts);
            var queryInterpreter = new QueryInterpreter(numberFormatCalculator, symbolValues);
            return queryInterpreter.Interpret(queryTexts);
        }
    }
}
