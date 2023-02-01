using ImaginariaSalaryCalculator.TaxCalculators;

namespace ImaginariaSalaryCalculator.TaxIncentivesCalculators
{
    public class TaxIncentivesCalculatorFactory : ITaxIncentivesCalculatorFactory
    {
        public IList<ITaxIncentivesCalculator> Create()
        {
            IList<ITaxIncentivesCalculator> calculators = new List<ITaxIncentivesCalculator>();

            calculators.Add(new CharityCalculator());

            return calculators;
        }
    }
}
