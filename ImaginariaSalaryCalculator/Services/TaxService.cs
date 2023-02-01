using ImaginariaSalaryCalculator.Models;
using ImaginariaSalaryCalculator.TaxIncentivesCalculators;
using ImaginariaSalaryCalculator.TaxCalculators;

namespace ImaginariaSalaryCalculator.Services
{
    public class TaxService : ITaxService
    {
        private readonly IList<ITaxDeductionCalculator> _taxCalculator;
        private readonly IList<ITaxIncentivesCalculator> _taxIncentivesCalculator;

        public TaxService(ITaxIncentivesCalculatorFactory taxIncentivesCalculatorFactory, ITaxCalculatorFactory taxCalculatorFactory)
        {
            _taxCalculator = taxCalculatorFactory.Create();
            _taxIncentivesCalculator = taxIncentivesCalculatorFactory.Create();
        }

        public async Task<Taxes> CalculateNetSalary(TaxPayer taxPayerData)
        {
            Taxes taxes = new Taxes();
                        
            decimal taxIncentivesTotal = CalculateAllTaxIncentives(taxPayerData, taxes);
            
            decimal taxesValueTotal = CalculateAllTaxes(taxPayerData, taxes, taxIncentivesTotal);

            taxes.TotalTax = taxesValueTotal;

            taxes.GrossIncome = taxPayerData.GrossIncome;
            taxes.NetIncome = taxPayerData.GrossIncome - taxesValueTotal;

            // Make awaitable call
            // TODO: Add the new taxes item to the data base
            Dictionary<string, Taxes> taxPayersTaxes = new()
            {
                { "48756845", new() { CharitySpent = 0, GrossIncome = 1500, NetIncome = 1300, TotalTax = 200, IncomeTax = 120, SocialTax = 10 } },
                { "9876555", new() { CharitySpent = 35, GrossIncome = 1500, NetIncome = 1300, TotalTax = 200, IncomeTax = 160, SocialTax = 30 } },
                { "234567", new() { CharitySpent = 80, GrossIncome = 3000, NetIncome = 2200, TotalTax = 500, IncomeTax = 150, SocialTax = 80 } },
            };
            taxPayersTaxes[taxPayerData.SSN] = taxes;

            return taxes;
        }

        private decimal CalculateAllTaxIncentives(TaxPayer taxPayerData, Taxes taxes)
        {
            decimal runningTaxIncentivesValue = 0;

            foreach (ITaxIncentivesCalculator calculator in _taxIncentivesCalculator)
            {
                runningTaxIncentivesValue += calculator.Calculate(taxPayerData, taxes);
            }

            return runningTaxIncentivesValue;
        }

        private decimal CalculateAllTaxes(TaxPayer taxPayerData, Taxes taxes, decimal taxIncentivesTotal)
        {
            decimal runningTaxesValue = 0;

            foreach (ITaxDeductionCalculator calculator in _taxCalculator)
            {
                runningTaxesValue += calculator.Calculate(taxPayerData, taxes, taxIncentivesTotal);
            }

            return runningTaxesValue;
        }
    }
}
