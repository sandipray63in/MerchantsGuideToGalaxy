using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utilities
{
    public static class CharactersUtility
    {
        public static string GetFormattedCommaSeperatedCharacters(IEnumerable<char> characters, string stringToReplaceLastComma = "and")
        {
            return GetFormattedCommaSeperatedCharacters(characters.ToList());
        }

        public static string GetFormattedCommaSeperatedCharacters(char[] characters, string stringToReplaceLastComma = "and")
        {
            return GetFormattedCommaSeperatedCharacters(characters.ToList());
        }

        public static string GetFormattedCommaSeperatedCharacters(List<char> characters, string stringToReplaceLastComma = "and")
        {
            var commaSeperatedCharacters = characters.Where(x => !string.IsNullOrEmpty(x.ToString())).Select(x => x.ToString()).Aggregate((a, b) => a + "," + b);
            var lastIndexOfCommaInCommaSeperatedCharacters = commaSeperatedCharacters.LastIndexOf(",");
            if (lastIndexOfCommaInCommaSeperatedCharacters != -1)
            {
                var commaSeperatedCharactersBeforeLastComma = commaSeperatedCharacters.Substring(0, lastIndexOfCommaInCommaSeperatedCharacters - 1);
                var commaSeperatedCharactersAfterLastComma = commaSeperatedCharacters.Substring(lastIndexOfCommaInCommaSeperatedCharacters + 1);
                commaSeperatedCharacters = commaSeperatedCharactersBeforeLastComma + " " + stringToReplaceLastComma.Trim() + " " + commaSeperatedCharactersAfterLastComma;
            }
            return commaSeperatedCharacters;
        }

        public static char[] GetAllCharactersSatisfyingNumberOfSuppliedRepetitionsOrMore(char[] input, int numberOfRepetitionsToCheck = 2, char[] charactersToCheck = null)
        {
            return GetAllCharactersSatisfyingNumberOfSuppliedRepetitionsOrMore(input.Select(x => x.ToString()).Aggregate((a, b) => a + b), numberOfRepetitionsToCheck, charactersToCheck);
        }

        public static char[] GetAllCharactersSatisfyingNumberOfSuppliedRepetitionsOrMore(string input, int numberOfRepetitionsToCheck = 2,char[] charactersToCheck = null)
        {
            var regEx = new Regex(@"(\w)\1{"+ (numberOfRepetitionsToCheck - 1) + ",}", RegexOptions.Compiled);
            return GetMatchesForSuppliedRegEx(regEx, input, numberOfRepetitionsToCheck, charactersToCheck);
        }

        public static char[] GetAllCharactersSatisfyingExactNumberOfSuppliedRepetitions(char[] input, int numberOfRepetitionsToCheck = 2, char[] charactersToCheck = null)
        {
            return GetAllCharactersSatisfyingExactNumberOfSuppliedRepetitions(input.Select(x => x.ToString()).Aggregate((a, b) => a + b), numberOfRepetitionsToCheck, charactersToCheck);
        }

        public static char[] GetAllCharactersSatisfyingExactNumberOfSuppliedRepetitions(string input, int numberOfRepetitionsToCheck = 2, char[] charactersToCheck = null)
        {
            var regEx = new Regex(@"(\w)\1{" + (numberOfRepetitionsToCheck - 1) + "}", RegexOptions.Compiled);
            return GetMatchesForSuppliedRegEx(regEx, input, numberOfRepetitionsToCheck, charactersToCheck);
        }

        private static char[] GetMatchesForSuppliedRegEx(Regex regEx,string input, int numberOfRepetitionsToCheck = 2, char[] charactersToCheck = null)
        {
            var matchesCollection = regEx.Matches(input);
            if (matchesCollection.Count > 0)
            {
                var matchesArray = new Match[matchesCollection.Count];
                matchesCollection.CopyTo(matchesArray, 0);
                var matchedCharacters = matchesArray.Select(m => m.Value[0]).ToArray();
                if (charactersToCheck != null && charactersToCheck.Count() > 0)
                {
                    matchedCharacters = charactersToCheck.Where(x => matchedCharacters.Contains(x)).ToArray();
                }
                return matchedCharacters;
            }
            return null;
        }
    }
}
