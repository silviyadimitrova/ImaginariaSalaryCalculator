namespace ImaginariaSalaryCalculator.TaxIncentivesCalculators
{
    public interface ITaxIncentivesCalculatorFactory
    {
        IList<ITaxIncentivesCalculator> Create();
    }
}
