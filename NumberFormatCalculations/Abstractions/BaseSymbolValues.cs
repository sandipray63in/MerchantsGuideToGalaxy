using System.Collections.Generic;

namespace NumberFormatCalculations.Abstractions
{
    public abstract class BaseSymbolValues<TKey, TValue> : ISymbolValues<TKey, TValue>
    {
        protected static IReadOnlyDictionary<TKey, TValue> symbolValues;

        public IReadOnlyDictionary<TKey, TValue> SymbolValues
        {
            get
            {
                return symbolValues;
            }
        }
    }
}
