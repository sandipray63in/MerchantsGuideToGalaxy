
namespace IntergalacticInterpretation.TerminalExpressions
{
    public interface ITerminalIsExpression<TLeftExpressionData, TRightExpressionData>
    {
        ITerminalExpression<TLeftExpressionData> LeftExpressionData { get;}

        ITerminalExpression<TRightExpressionData> RightExpressionData { get;}
    }
}
