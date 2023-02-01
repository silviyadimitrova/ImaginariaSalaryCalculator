using ImaginariaSalaryCalculator.Models;

namespace ImaginariaSalaryCalculator.TaxIncentivesCalculators
{
    public interface ITaxIncentivesCalculator
    {
        // Returns the current taxable value based on criteria for the proccess
        decimal Calculate(TaxPayer taxPayerData, Taxes taxesRecord);
    }
}
