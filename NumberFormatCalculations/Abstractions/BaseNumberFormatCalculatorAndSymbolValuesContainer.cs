
namespace NumberFormatCalculations.Abstractions
{
    public abstract class BaseNumberFormatCalculatorAndSymbolValuesContainer<TKey,TValue> : BaseSymbolValuesContainer<TKey, TValue>
    {
        protected INumberFormatCalculator numberFormatCalculator;

        public BaseNumberFormatCalculatorAndSymbolValuesContainer(INumberFormatCalculator numberFormatCalculator, ISymbolValues<TKey, TValue> symbolValues) : base(symbolValues)
        {
            this.numberFormatCalculator = numberFormatCalculator;
        }
    }
}
