namespace ImaginariaSalaryCalculator.Models
{
    public class Taxes
    {
        public Taxes()
        {
            this.GrossIncome = 0;
            this.CharitySpent = 0;
            this.IncomeTax = 0;
            this.SocialTax = 0;
            this.TotalTax = IncomeTax + SocialTax;
            this.NetIncome = 0;
        }

        public decimal GrossIncome { get; set; }

        public decimal CharitySpent { get; set; }

        public decimal IncomeTax { get; set; }

        public decimal SocialTax { get; set; }

        public decimal TotalTax { get; set; }

        public decimal NetIncome { get; set; }
    }
}
