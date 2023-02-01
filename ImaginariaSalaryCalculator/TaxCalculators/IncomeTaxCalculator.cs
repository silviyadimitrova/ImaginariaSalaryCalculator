using ImaginariaSalaryCalculator.Models;

namespace ImaginariaSalaryCalculator.TaxCalculators
{
    public class IncomeTaxCalculator : ITaxDeductionCalculator
    {
        private const decimal SalaryLowerBounradyForIncomeTaxApplicability = 1000;
        private const decimal IncomeTaxPercentage = 0.10M;

        public decimal Calculate(TaxPayer taxPayerData, Taxes taxesRecord, decimal taxIncentivesTotal)
        {
            decimal incomeTax = 0;

            if (taxPayerData.GrossIncome > SalaryLowerBounradyForIncomeTaxApplicability)
            {
                incomeTax = IncomeTaxPercentage * (taxPayerData.GrossIncome - taxIncentivesTotal);
                taxesRecord.IncomeTax = incomeTax;
            }

            return incomeTax;
        }
    }
}
