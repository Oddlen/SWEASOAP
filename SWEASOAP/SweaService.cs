using SWEASOAP.SweaSOAPService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWEASOAP
{
    public class SweaService : ICurrencyConverter
    {
        public DateTime GetClosestSupportedDate(DateTime dateTime)
        {
            var client = new SweaWebServicePortTypeClient();
            var dayInformation = client.getCalendarDays(dateTime, dateTime);
            while(dayInformation[0].bankday == "N")
            {
                dateTime = dateTime.AddDays(-1);
                dayInformation = client.getCalendarDays(dateTime, dateTime);
            }
            return dateTime;
        }

        public IEnumerable<CurrencyInformation> GetSupportedCurrencies()
        {
            var supportedCurrencies = new SweaWebServicePortTypeClient().getAllCrossNames(LanguageType.sv);
            var result = from currency in supportedCurrencies
                         select new CurrencyInformation { Id = currency.seriesid, Description = currency.seriesdescription };
            return result;
        }

        public decimal GetConversionRate(DateTime conversionDate, string fromCurrencyId, string toCurrencyId)
        {
            var parameters = new CrossRequestParameters
            {
                aggregateMethod = AggregateMethodType.D,
                languageid = LanguageType.sv,
                datefrom = conversionDate,
                dateto = conversionDate,
                crossPair = new[] { new CurrencyCrossPair { seriesid1 = fromCurrencyId, seriesid2 = toCurrencyId } }

            };
            var result = new SweaWebServicePortTypeClient().getCrossRates(parameters);

            // If conversion failed, return -1
            if (result.groups == null) return -1;

            if (result.groups[0].series[0].seriesid1 == fromCurrencyId) 
                return Convert.ToDecimal(result.groups[0].series[0].resultrows[0].value);

            return Convert.ToDecimal(result.groups[0].series[1].resultrows[0].value);
        }
    }
}
