using SWEASOAP;
using System;
using System.Collections.Generic;

namespace SWEASOAPTests
{
    public class MockSweaService : ICurrencyConverter
    {
        private DateTime ClosestDate;
        private decimal Rate;
        private IEnumerable<CurrencyInformation> Currencies;

        public MockSweaService(DateTime closestDate, decimal rate, IEnumerable<CurrencyInformation> currencies)
        {
            ClosestDate = closestDate;
            Rate = rate;
            Currencies = currencies;
        }
        public DateTime GetClosestSupportedDate(DateTime dateTime)
        {
            return ClosestDate;
        }

        public decimal GetConversionRate(DateTime conversionDate, string fromCurrencyId, string toCurrencyId)
        {
            return Rate;
        }

        public IEnumerable<CurrencyInformation> GetSupportedCurrencies()
        {
            return Currencies;
        }
    }
}
