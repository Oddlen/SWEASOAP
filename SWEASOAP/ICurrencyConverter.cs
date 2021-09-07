using System;
using System.Collections.Generic;

namespace SWEASOAP
{
    public interface ICurrencyConverter
    {
        IEnumerable<CurrencyInformation> GetSupportedCurrencies();
        DateTime GetClosestSupportedDate(DateTime dateTime);
        decimal GetConversionRate(DateTime conversionDate, string fromCurrencyId, string toCurrencyId);
    }
}
