using ImaginariaSalaryCalculator.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ImaginariaSalaryCalculator.Data
{
    public class TaxPayerTaxesRepository : ITaxPayerTaxesRepository
    {
        private readonly IMemoryCache _memoryCache;

        public TaxPayerTaxesRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Dictionary<string, Taxes> GetAll()
        {
            Dictionary<string, Taxes> output = new()
            {
                { "48756845", new() { CharitySpent = 0, GrossIncome = 1500, NetIncome = 1300, TotalTax = 200, IncomeTax = 120, SocialTax = 10 } },
                { "9876555", new() { CharitySpent = 35, GrossIncome = 1500, NetIncome = 1300, TotalTax = 200, IncomeTax = 160, SocialTax = 30 } },
                { "234567", new() { CharitySpent = 80, GrossIncome = 3000, NetIncome = 2200, TotalTax = 500, IncomeTax = 150, SocialTax = 80 } },
            };

            return output;
        }

        public async Task<Dictionary<string, Taxes>> GetAllAsync()
        {
            Dictionary<string, Taxes> output = new()
            {
                { "48756845", new() { CharitySpent = 0, GrossIncome = 1500, NetIncome = 1300, TotalTax = 200, IncomeTax = 120, SocialTax = 10 } },
                { "9876555", new() { CharitySpent = 35, GrossIncome = 1500, NetIncome = 1300, TotalTax = 200, IncomeTax = 160, SocialTax = 30 } },
                { "234567", new() { CharitySpent = 80, GrossIncome = 3000, NetIncome = 2200, TotalTax = 500, IncomeTax = 150, SocialTax = 80 } },
            };

            await Task.Delay(0);

            return output;
        }

        public async Task<Dictionary<string, Taxes>> GetAllCacheAsync()
        {
            Dictionary<string, Taxes> taxPayersTaxes;

            // If not found in cache, take them from the database and cache them
            if (!_memoryCache.TryGetValue("taxPayersTaxes", out taxPayersTaxes))
            {
                // TODO: Replace with an awaitable real call to the DB and make the call awaitable

                // A: Use to test for a new tax payer
                taxPayersTaxes = new()
                {
                    { "48756845", new() { CharitySpent = 0, GrossIncome = 1500, NetIncome = 1300, TotalTax = 200, IncomeTax = 120, SocialTax = 10 } },
                    { "9876555", new() { CharitySpent = 35, GrossIncome = 1500, NetIncome = 1300, TotalTax = 200, IncomeTax = 160, SocialTax = 30 } },
                    { "234567", new() { CharitySpent = 80, GrossIncome = 3000, NetIncome = 2200, TotalTax = 500, IncomeTax = 150, SocialTax = 80 } },
                };

                // B: Uncomment, to test available data in the db/cache

                // Enter the below object as an input:
                // {
                //  "fullName": "Tom Jonhson",
                //  "dateOfBirth": "05/06/1985",
                //  "grossIncome": 2500,
                //  "ssn": "123456",
                //  "charitySpent": 0
                //  }

                // taxPayersTaxes["123456"] = new() { CharitySpent = 0, GrossIncome = 2500, NetIncome = 2200, TotalTax = 625, IncomeTax = 250, SocialTax = 375 };


                if (taxPayersTaxes != null && taxPayersTaxes.Count > 0)
                {
                    // Refresh it every 10 minutes.
                    _memoryCache.Set(
                        "taxPayersTaxes",
                        taxPayersTaxes,
                        new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(10))
                        .SetPriority(CacheItemPriority.High));
                }
            }

            return taxPayersTaxes;
        }
    }
}
