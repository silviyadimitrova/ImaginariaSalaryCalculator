using ImaginariaSalaryCalculator.Models;

namespace ImaginariaSalaryCalculator.TaxCalculators
{
    public interface ITaxDeductionCalculator
    {
        // Returns the current net value based on criteria for the proccess
        decimal Calculate(TaxPayer taxPayerData, Taxes taxesRecord, decimal taxIncentivesTotal);
    }
}
