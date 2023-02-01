using ImaginariaSalaryCalculator.Models;

namespace ImaginariaSalaryCalculator.Services
{
    public interface ITaxService
    {
        Task<Taxes> CalculateNetSalary(TaxPayer taxPayerData);
    }
}
