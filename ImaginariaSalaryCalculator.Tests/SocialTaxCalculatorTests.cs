using ImaginariaSalaryCalculator.Models;
using ImaginariaSalaryCalculator.TaxCalculators;

namespace ImaginariaSalaryCalculator.Tests
{
    public class SocialTaxCalculatorTests
    {
        [Fact]
        public void Calculate_ShouldReturn_CorrectSocialCalculation()
        {
            // Arrange
            var socialCalculator = new SocialTaxCalculator();
            var taxPayerData = new TaxPayer("Fred Johnson", DateTime.Now, 2500, "1234567", 200);
            Taxes taxesRecord = new Taxes();

            // Act
            var result = socialCalculator.Calculate(taxPayerData, taxesRecord, 200);

            // Assert
            Assert.Equal(345, result);
        }

        [Fact]
        public void Calculate_ShouldPopulateTaxesRecord()
        {
            // Arrange
            var socialCalculator = new SocialTaxCalculator();
            var taxPayerData = new TaxPayer("Fred Johnson", DateTime.Now, 2500, "1234567", 200);
            Taxes taxesRecord = new Taxes();

            // Act
            var result = socialCalculator.Calculate(taxPayerData, taxesRecord, 200);

            // Assert
            Assert.Equal(345, taxesRecord.SocialTax);
        }

    }
}
