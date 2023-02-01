using ImaginariaSalaryCalculator.Models;
using ImaginariaSalaryCalculator.TaxIncentivesCalculators;

namespace ImaginariaSalaryCalculator.Tests
{
    public class CharityCalculatorTests
    {
        [Fact]
        public void Calculate_ShouldReturn_CorrectCharityCalculation()
        {
            // Arrange
            var charityCalculator = new CharityCalculator();
            var taxPayerData = new TaxPayer("Fred Johnson", DateTime.Now, 2500, "1234567", 180);
            Taxes taxesRecord = new Taxes();

            // Act
            var result = charityCalculator.Calculate(taxPayerData, taxesRecord);

            // Assert
            Assert.Equal(180, result);
        }

        [Fact]
        public void Calculate_ShouldPopulateTaxesRecord()
        {
            // Arrange
            var calculator = new CharityCalculator();
            var taxPayerData = new TaxPayer("Fred Johnson", DateTime.Now, 2500, "1234567", 180);
            Taxes taxesRecord = new Taxes();

            // Act
            var result = calculator.Calculate(taxPayerData, taxesRecord);

            // Assert
            Assert.Equal(180, taxesRecord.CharitySpent);
        }
    }
}