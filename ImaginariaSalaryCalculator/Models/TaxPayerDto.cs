using System.ComponentModel.DataAnnotations;

namespace ImaginariaSalaryCalculator.Models
{
    public class TaxPayerDto
    {
        public TaxPayerDto(string fullName, string dateOfBirth, decimal grossIncome, string ssn, decimal charitySpent)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            GrossIncome = grossIncome;
            SSN = ssn;
            CharitySpent = charitySpent;
        }

        [Required(ErrorMessage = "Full name is required.")]
        [RegularExpression(@"^[A-Za-z]+\s[A-Za-z]+(\s[A-Za-z]+)*$",
         ErrorMessage = "A full name is required. Only letters are allowed.")]
        public string FullName { get; set; }

        [RegularExpression(@"^[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}$", ErrorMessage = "Date of birth should be in the format month/day/year.")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gross Income is required.")]
        [RegularExpression(@"^[1-9]*\.?\d*$")]
        public decimal GrossIncome { get; set; }

        [Required(ErrorMessage = "SSN is required.")]
        [RegularExpression(@"^\d{5,10}$", ErrorMessage = "5 to 10 digit ssn number is required.")]
        public string SSN { get; set; }

        [RegularExpression(@"^[0]$||^([1-9][0-9]*)$")]
        public decimal CharitySpent { get; set; }
    }
}
