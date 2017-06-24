
namespace IntergalacticInterpretation.TerminalExpressions
{
    public class TerminalExpression<TData> : ITerminalExpression<TData>
    {
        private TData data;

        public TerminalExpression(TData data)
        {
            this.data = data;
        }

        public TData Data
        {
            get
            {
                return data;
            }
        }
    }
}
