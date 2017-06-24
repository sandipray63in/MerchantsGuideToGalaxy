
namespace IntergalacticInterpretation.TerminalExpressions
{
    public class TerminalIsExpression<TLeftExpressionData, TRightExpressionData> : ITerminalIsExpression<TLeftExpressionData, TRightExpressionData>
    {
        private TLeftExpressionData leftData;
        private TRightExpressionData rightData;

        public TerminalIsExpression(TLeftExpressionData leftData, TRightExpressionData rightData)
        {
            this.leftData = leftData;
            this.rightData = rightData;
        }

        public ITerminalExpression<TLeftExpressionData> LeftExpressionData
        {
            get
            {
                return new TerminalExpression<TLeftExpressionData>(leftData);
            }
        }

        public ITerminalExpression<TRightExpressionData> RightExpressionData
        {
            get
            {
                return new TerminalExpression<TRightExpressionData>(rightData);
            }
        }
    }
}
