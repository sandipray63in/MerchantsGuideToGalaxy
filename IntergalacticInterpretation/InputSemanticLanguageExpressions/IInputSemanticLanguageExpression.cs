using IntergalacticInterpretation.TerminalExpressions;

namespace IntergalacticInterpretation.InputSemanticLanguageExpressions
{
    interface IInputSemanticLanguageExpression
    {
        void Store(string input);
        int Interpret(ITerminalListExpression<string> intergalacticWordsList);
    }
}
