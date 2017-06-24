using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberFormatCalculations.Abstractions.RomanNumerals;
using NumberFormatCalculations.Implementations.Calculators.RomanNumerals;
using NumberFormatCalculations.Implementations.RuleCheckers.RomanNumerals;
using NumberFormatCalculations.Implementations.SymbolValues.RomanNumerals;
using IntergalacticInterpretation;
using Utilities;

namespace UnitTesting
{
    [TestClass]
    public class IntergalacticInterpretationTest
    {
        [TestMethod]
        public void Test_With_Proper_Input_Text_File()
        {
            //Arrange
            var inputTextLines = EmbeddedResourceUtility.GetResourceDataLineTexts(Assembly.GetExecutingAssembly(), "UnitTesting.InputText.txt").ToList();
            var romanNumeralSymbolValues = new RomanNumeralSymbolValues();
            var romanNumeralRuleCheckers = new List<IRomanNumeralRuleChecker>
                                           {
                                              new MaxSuccessiveRepetitionRuleChecker(),
                                              new FourTimesRepetitionWithLowerValueCharacterAtFourthPositionRuleChecker(),
                                              new NotAllowedRepetitionRuleChecker(),
                                              new AllowedSubtractionsRuleChecker(),
                                              new NotAllowedSubtractionRuleChecker(romanNumeralSymbolValues),
                                              new OnlyOneSmallValueFromlLargeValueSubtractionAllowedRuleChecker(romanNumeralSymbolValues),
                                           };
            var standardRomanNumeralCalculator = new StandardRomanNumeralCalculator(romanNumeralSymbolValues, romanNumeralRuleCheckers);
            var intergalacticProcessor = new IntergalacticProcessor(standardRomanNumeralCalculator, romanNumeralSymbolValues);

            //Action
            var outputTextLines = intergalacticProcessor.Process(inputTextLines);

            //Assert
            Assert.AreEqual(outputTextLines[0], "pish tegj glob glob is 42");
            Assert.AreEqual(outputTextLines[1], "glob prok Silver is 68 Credits");
            Assert.AreEqual(outputTextLines[2], "glob prok Gold is 57800 Credits");
            Assert.AreEqual(outputTextLines[3], "glob prok Iron is 782 Credits");
            Assert.AreEqual(outputTextLines[4], "I have no idea what you are talking about");
        }
    }
}
