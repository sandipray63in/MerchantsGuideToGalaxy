using System.Collections.Generic;

namespace IntergalacticInterpretation.IntergalacticInterpreters.InputStores
{
    public interface IInputStore
    {
        void Store(List<string> inputTexts);
    }
}
