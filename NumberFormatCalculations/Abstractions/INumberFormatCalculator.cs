
namespace NumberFormatCalculations.Abstractions
{
    public interface INumberFormatCalculator
    {
        int ToNumber(string numberFormat);

        string ToNumberFormat(int number);
    }
}
