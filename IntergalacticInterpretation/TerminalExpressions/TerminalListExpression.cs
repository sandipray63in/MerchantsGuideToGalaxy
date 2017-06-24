using System.Collections.Generic;

namespace IntergalacticInterpretation.TerminalExpressions
{
    public class TerminalListExpression<TData> : ITerminalListExpression<TData>
    {
        private List<TData> dataList;

        public TerminalListExpression(List<TData> dataList)
        {
            this.dataList = dataList;
        }

        public List<TData> DataList
        {
            get
            {
                return dataList;
            }
        }
    }
}
