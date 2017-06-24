using NumberFormatCalculations.Abstractions;
using IntergalacticInterpretation.TerminalExpressions;

namespace IntergalacticInterpretation.InputSemanticLanguageExpressions
{
    public abstract class BaseInputSemanticLanguageExpression : BaseNumberFormatCalculatorAndSymbolValuesContainer<char,int>, IInputSemanticLanguageExpression
    {
        public BaseInputSemanticLanguageExpression(INumberFormatCalculator numberFormatCalculator,ISymbolValues<char, int> symbolValues) : base(numberFormatCalculator,symbolValues)
        {
        }

        public abstract void Store(string input);
        public abstract int Interpret(ITerminalListExpression<string> intergalacticWordsList);
    }
}
