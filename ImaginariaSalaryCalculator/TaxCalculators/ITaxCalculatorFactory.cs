namespace ImaginariaSalaryCalculator.TaxCalculators
{
    public interface ITaxCalculatorFactory
    {
        IList<ITaxDeductionCalculator> Create();
    }
}