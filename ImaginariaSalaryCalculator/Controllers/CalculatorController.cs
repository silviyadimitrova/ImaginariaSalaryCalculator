using ImaginariaSalaryCalculator.Models;
using ImaginariaSalaryCalculator.Services;
using Microsoft.AspNetCore.Mvc;
using ImaginariaSalaryCalculator.Data;

namespace ImaginariaSalaryCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ITaxService _taxService;
        private readonly ITaxPayerTaxesRepository _taxPayerTaxesRepository;

        public CalculatorController(ITaxService taxService, ITaxPayerTaxesRepository taxPayerTaxesRepository)
        {
            _taxService = taxService;
            _taxPayerTaxesRepository = taxPayerTaxesRepository;
        }

        [HttpPost(Name = "CalculateTaxOnGrossSalary")]
        public async Task<Taxes> CalculateTaxOnGrossSalary(TaxPayerDto taxPayerDataDto)
        {
            TaxPayer taxPayerData = TaxPayer.Create(taxPayerDataDto);

            // get all calculated values, if such exist, from cache or db
            Dictionary<string, Taxes> taxPayersTaxes = await _taxPayerTaxesRepository.GetAllCacheAsync();

            // Check if the tax payer data is already calculated
            Taxes taxPayerTaxes;
            if (taxPayersTaxes.TryGetValue(taxPayerData.SSN, out taxPayerTaxes))
            {
                taxPayerTaxes = taxPayersTaxes[taxPayerData.SSN];
            }
            else
            {
                // if not, calculate and add to db and cache
                taxPayerTaxes = await _taxService.CalculateNetSalary(taxPayerData);
            }

            return taxPayerTaxes;
        }
    }
}