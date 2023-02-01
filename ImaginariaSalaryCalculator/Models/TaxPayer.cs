namespace ImaginariaSalaryCalculator.Models
{
    public class TaxPayer
    {
        public static TaxPayer Create(TaxPayerDto taxPayerDto)
        {
            // validate the date
            DateTime validDateOfBirth;
            if (!DateTime.TryParse(taxPayerDto.DateOfBirth, out validDateOfBirth))
                throw new FormatException("Date of birth should be in the format month/day/year.");

            // return new tax payer
            return new TaxPayer(taxPayerDto.FullName, validDateOfBirth, taxPayerDto.GrossIncome, taxPayerDto.SSN, taxPayerDto.CharitySpent);
        }

        public TaxPayer(string fullName, DateTime dateOfBirth, decimal grossIncome, string ssn, decimal charitySpent)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            GrossIncome = grossIncome;
            SSN = ssn;
            CharitySpent = charitySpent;
        }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal GrossIncome { get; set; }

        public string SSN { get; set; }

        public decimal CharitySpent { get; set; }
    }
}
