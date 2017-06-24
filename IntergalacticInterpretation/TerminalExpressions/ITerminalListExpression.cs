using System.Collections.Generic;

namespace IntergalacticInterpretation.TerminalExpressions
{
    public interface ITerminalListExpression<TData>
    {
        List<TData> DataList { get;}
    }
}
