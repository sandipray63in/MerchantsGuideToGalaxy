using System;
using System.Linq;
using System.Collections.Generic;
using NumberFormatCalculations.Abstractions;
using IntergalacticInterpretation.QueryExpressions;
using Utilities;

namespace IntergalacticInterpretation.IntergalacticInterpreters.QueryInterpreters
{
    public class QueryInterpreter : BaseNumberFormatCalculatorAndSymbolValuesContainer<char, int>, IQueryInterpreter
    {
        public QueryInterpreter(INumberFormatCalculator numberFormatCalculator, ISymbolValues<char, int> symbolValues) : base(numberFormatCalculator,symbolValues)
        {
            
        }

        public List<string> Interpret(List<string> queryTexts)
        {
            var creditsQueryTexts = queryTexts.Where(x => x.Contains("Credits")).ToList();
            var normalQueryTexts = queryTexts.Except(creditsQueryTexts).ToList();
            var queryTextsMappingsToOutputTexts = new Dictionary<string, string>();
            queryTexts.ForEach(x =>
              {
                  queryTextsMappingsToOutputTexts.Add(x, string.Empty);
              }
            );
            ContractUtility.Requires<ArgumentException>(normalQueryTexts.Count > 0, "There must be some valid query");
            var normalQueryExpression = new NormalQueryExpression(numberFormatCalculator, symbolValues);
            Interpret(normalQueryExpression, normalQueryTexts, queryTextsMappingsToOutputTexts);
            var creditsQueryExpression = new CreditsQueryExpression(numberFormatCalculator, symbolValues);
            Interpret(creditsQueryExpression, creditsQueryTexts, queryTextsMappingsToOutputTexts);
            return queryTextsMappingsToOutputTexts.Values.ToList();
        }

        private void Interpret(IQueryExpression queryExpression, List<string> queryTexts, Dictionary<string, string> queryTextsMappingsToOutputTexts)
        {
            if (queryTexts.Count > 0)
            {
                queryTexts.ForEach(x =>
                    {
                        try
                        {
                            queryTextsMappingsToOutputTexts[x] = queryExpression.Interpret(x);
                        }
                        catch
                        {
                            queryTextsMappingsToOutputTexts[x] = "I have no idea what you are talking about";
                        }
                    }
                );
            }
        }
    }
}
