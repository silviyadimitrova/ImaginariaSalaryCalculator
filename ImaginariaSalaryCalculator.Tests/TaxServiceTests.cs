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

            TaxPayerDto taxPayerDto = new TaxPayerDto("Tom Johnson", "10/10/1986", 2500, "1234567", 0);
            TaxPayer taxPayerData = TaxPayer.Create(taxPayerDto);
            Taxes taxesRecord = new Taxes()
            {
                CharitySpent = 0,
                TotalTax = 625,
                GrossIncome = 2500,
                IncomeTax = 250,
                NetIncome = 1875,
                SocialTax = 375
            };

            // Act
            var result = await taxService.CalculateNetSalary(taxPayerData);

            // Assert
            taxesRecord.ShouldBeEquivalentTo(result);
        }
    }
}
