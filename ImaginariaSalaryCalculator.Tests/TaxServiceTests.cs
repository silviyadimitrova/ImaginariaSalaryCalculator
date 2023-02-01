using ImaginariaSalaryCalculator.Models;
using ImaginariaSalaryCalculator.Services;
using ImaginariaSalaryCalculator.TaxCalculators;
using ImaginariaSalaryCalculator.TaxIncentivesCalculators;
using Shouldly;

namespace ImaginariaSalaryCalculator.Tests
{
    public class TaxServiceTests
    {
        [Fact]
        public async void CalculateNetSalary_ShouldCalculateCorrectValue()
        {
            // Arrange
            ITaxIncentivesCalculatorFactory taxIncentivesCalculatorFactory = new TaxIncentivesCalculatorFactory();
            ITaxCalculatorFactory taxCalculatorFactory = new TaxCalculatorFactory();
            ITaxService taxService = new TaxService(taxIncentivesCalculatorFactory, taxCalculatorFactory);

            var taxPayerData = new TaxPayer("Tom Johnson", DateTime.Now, 2500, "1234567", 0);
            Taxes taxesRecord = new Taxes()
            {
                CharitySpent = 0,
                TotalTax = 625,
                GrossIncome = 2500,
                IncomeTax = 250.00M,
                NetIncome = 1875.00M,
                SocialTax = 375.00M
            };

            // Act
            var result = await taxService.CalculateNetSalary(taxPayerData);

            // Assert
            taxesRecord.ShouldBeEquivalentTo(result);
        }
    }
}
