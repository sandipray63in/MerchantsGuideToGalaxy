using System.Collections.Generic;

namespace IntergalacticInterpretation.IntergalacticInterpreters.QueryInterpreters
{
    public interface IQueryInterpreter
    {
        List<string> Interpret(List<string> queryTexts);
    }
}
