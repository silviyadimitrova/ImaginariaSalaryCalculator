using ImaginariaSalaryCalculator.Models;

namespace ImaginariaSalaryCalculator.TaxIncentivesCalculators
{
    public class CharityCalculator : ITaxIncentivesCalculator
    {
        private const decimal CharityThresholdPercentage = 0.1M;

        public decimal Calculate(TaxPayer taxPayerData, Taxes taxesRecord)
        {
            decimal charityThresholdAmount = CharityThresholdPercentage * taxPayerData.GrossIncome;
            decimal relevantCharityValue = charityThresholdAmount >= taxPayerData.CharitySpent ? taxPayerData.CharitySpent : charityThresholdAmount;
            taxesRecord.CharitySpent = taxPayerData.CharitySpent;

            return relevantCharityValue;
        }
    }
}
