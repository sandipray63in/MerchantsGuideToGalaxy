
namespace IntergalacticInterpretation.TerminalExpressions
{
    public class TerminalListIsExpression<TLeftData, TRightData, TLeftListExpression, TRightListExpression> : ITerminalListIsExpression<TLeftData, TRightData, TLeftListExpression, TRightListExpression>
        where TLeftListExpression : ITerminalListExpression<TLeftData>
        where TRightListExpression : ITerminalListExpression<TRightData>
    {
        private TLeftListExpression leftListExpression;
        private TRightListExpression rightListExpression;

        public TerminalListIsExpression(TLeftListExpression leftListExpression, TRightListExpression rightListExpression)
        {
            this.leftListExpression = leftListExpression;
            this.rightListExpression = rightListExpression;
        }

        public TLeftListExpression LeftListExpression
        {
            get
            {
                return LeftListExpression;
            }
        }

        public TRightListExpression RightListExpression
        {
            get
            {
                return rightListExpression;
            }
        }
    }
}
