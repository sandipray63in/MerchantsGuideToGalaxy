using System.Collections.Generic;

namespace NumberFormatCalculations.Abstractions
{
    public interface ISymbolValues<TKey,TValue>
    {
        IReadOnlyDictionary<TKey, TValue> SymbolValues { get; }
    }
}
