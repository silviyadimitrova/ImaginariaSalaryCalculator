namespace ImaginariaSalaryCalculator.TaxCalculators
{
    public class TaxCalculatorFactory : ITaxCalculatorFactory
    {

        public IList<ITaxDeductionCalculator> Create()
        {
            IList<ITaxDeductionCalculator> calculators = new List<ITaxDeductionCalculator>();

            calculators.Add(new IncomeTaxCalculator());
            calculators.Add(new SocialTaxCalculator());

            return calculators;
        }
    }
}
