
namespace IntergalacticInterpretation.TerminalExpressions
{
    public interface ITerminalListIsExpression<TLeftData,TRightData,TLeftListExpression,TRightListExpression>
        where TLeftListExpression : ITerminalListExpression<TLeftData>
        where TRightListExpression : ITerminalListExpression<TRightData>
    {
        TLeftListExpression LeftListExpression { get; }
        TRightListExpression RightListExpression { get; }
    }
}
