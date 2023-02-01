using ImaginariaSalaryCalculator.Models;
using ImaginariaSalaryCalculator.TaxCalculators;

namespace ImaginariaSalaryCalculator.Tests
{
    public class IncomeCalculatorTests
    {
        [Fact]
        public void Calculate_ShouldReturn_CorrectIncomeCalculation()
        {
            // Arrange
            var incomeCalculator = new IncomeTaxCalculator();
            var taxPayerData = new TaxPayer("Fred Johnson", DateTime.Now, 2500, "1234567", 180);
            Taxes taxesRecord = new Taxes();

            // Act
            var result = incomeCalculator.Calculate(taxPayerData, taxesRecord, 180);

            // Assert
            Assert.Equal(232, result);
        }

        [Fact]
        public void Calculate_ShouldPopulateTaxesRecord()
        {
            // Arrange
            var incomeCalculator = new IncomeTaxCalculator();
            var taxPayerData = new TaxPayer("Fred Johnson", DateTime.Now, 2500, "1234567", 180);
            Taxes taxesRecord = new Taxes();

            // Act
            var result = incomeCalculator.Calculate(taxPayerData, taxesRecord, 180);

            // Assert
            Assert.Equal(232, taxesRecord.IncomeTax);
        }
    }
}
