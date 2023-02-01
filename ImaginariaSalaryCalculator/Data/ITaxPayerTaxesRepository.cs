using ImaginariaSalaryCalculator.Models;

namespace ImaginariaSalaryCalculator.Data
{
    public interface ITaxPayerTaxesRepository
    {
        Dictionary<string, Taxes> GetAll();

        Task<Dictionary<string, Taxes>> GetAllAsync();

        Task<Dictionary<string, Taxes>> GetAllCacheAsync();
    }
}
