using ImaginariaSalaryCalculator.Models;

namespace ImaginariaSalaryCalculator.TaxCalculators
{
    public class SocialTaxCalculator : ITaxDeductionCalculator
    {
        private const decimal SalaryLowerBounradyForSocialTaxApplicability = 1000;
        private const decimal TaxableValueMaxForSocialTaxApplicability = 3000;
        private const decimal SocialTaxPercentage = 0.15M;

        public decimal Calculate(TaxPayer taxPayerData, Taxes taxesRecord, decimal taxIncentivesTotal)
        {
            decimal socialTax = 0;

            if (taxPayerData.GrossIncome > SalaryLowerBounradyForSocialTaxApplicability)
            {
                decimal taxableValue = taxPayerData.GrossIncome > TaxableValueMaxForSocialTaxApplicability ? TaxableValueMaxForSocialTaxApplicability : taxPayerData.GrossIncome;
                socialTax = SocialTaxPercentage * (taxableValue - taxIncentivesTotal);

                taxesRecord.SocialTax = socialTax;
            }

            return socialTax;
        }
    }
}
