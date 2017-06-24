
namespace NumberFormatCalculations.Abstractions
{
    public abstract class BaseSymbolValuesContainer<TKey,TValue>
    {
        protected ISymbolValues<TKey, TValue> symbolValues;

        public BaseSymbolValuesContainer(ISymbolValues<TKey, TValue> symbolValues)
        {
            this.symbolValues = symbolValues;
        }
    }
}
