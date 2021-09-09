using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWEASOAP;
using SWEASOAPTests;
using System;
using System.Collections.Generic;

namespace SWEATests
{
    [TestClass]
    public class MainFormTests
    {
        [TestMethod]
        public void MainFormConstructorTest()
        {
            var info = new List<CurrencyInformation>
            {
                new CurrencyInformation{Description = "b", Id = "2"},
                new CurrencyInformation{Description = "a", Id = "1"},
                new CurrencyInformation{Description = "c", Id = "3"},
            };
            var date = new DateTime(2020, 1, 1);
            decimal rate = 5;
            var service = new MockSweaService(date, rate, info);
            var form = new MainForm(service);

            Assert.AreEqual(date, form.GetDateTimePicker().Value);
            Assert.AreEqual(decimal.MaxValue, form.GetInputValue().Maximum);
            Assert.AreEqual(0, form.GetFromCurrency().SelectedIndex);
            Assert.AreEqual(0, form.GetToCurrency().SelectedIndex);
            Assert.AreEqual("a", (string)form.GetFromCurrency().SelectedItem);
            Assert.AreEqual("a", (string)form.GetToCurrency().SelectedItem);
        }

        [TestMethod]
        public void FutrueDateSelected()
        {
            var info = new List<CurrencyInformation>
            {
                new CurrencyInformation{Description = "b", Id = "2"},
                new CurrencyInformation{Description = "a", Id = "1"},
                new CurrencyInformation{Description = "c", Id = "3"},
            };
            var date = new DateTime(2020, 1, 1);
            decimal rate = 5;
            var service = new MockSweaService(date, rate, info);
            var form = new MainForm(service);

            form.GetDateTimePicker().Value = new DateTime(2030, 1, 1);
            form.ConvertButton_Click(null, null);

            Assert.AreEqual(new DateTime(2020, 1, 1), form.GetDateTimePicker().Value);
        }

        [TestMethod]
        public void InvalidCurrencySelected()
        {
            var info = new List<CurrencyInformation>
            {
                new CurrencyInformation{Description = "b", Id = "2"},
                new CurrencyInformation{Description = "a", Id = "1"},
                new CurrencyInformation{Description = "c", Id = "3"},
            };
            var date = new DateTime(2020, 1, 1);
            decimal rate = 5;
            var service = new MockSweaService(date, rate, info);
            var form = new MainForm(service);

            form.GetFromCurrency().SelectedItem = null;
            form.ConvertButton_Click(null, null);

            Assert.AreEqual("Ogiltig valuta", form.GetResultValue().Text);
            Assert.AreEqual("Kurs: -", form.GetExchange().Text);
        }

        [TestMethod]
        public void SuccessfulConversion()
        {
            var info = new List<CurrencyInformation>
            {
                new CurrencyInformation{Description = "b", Id = "2"},
                new CurrencyInformation{Description = "a", Id = "1"},
                new CurrencyInformation{Description = "c", Id = "3"},
            };
            var date = new DateTime(2020, 1, 1);
            decimal rate = 5;
            var service = new MockSweaService(date, rate, info);
            var form = new MainForm(service);

            form.GetInputValue().Value = (decimal)1.25;
            form.ConvertButton_Click(null, null);

            Assert.AreEqual(form.GetResultValue().Text, "6.25");
            Assert.AreEqual(form.GetExchange().Text, "Kurs: 5");
        }

        [TestMethod]
        public void NoAvailableCurrencies()
        {
            var info = new List<CurrencyInformation>();
            var date = new DateTime(2020, 1, 1);
            decimal rate = 5;
            var service = new MockSweaService(date, rate, info);
            var form = new MainForm(service);

            Assert.IsFalse(form.GetConvertButton().Enabled);
        }

        [TestMethod]
        public void ConversionNotPossible()
        {
            var info = new List<CurrencyInformation>
            {
                new CurrencyInformation{Description = "b", Id = "2"},
                new CurrencyInformation{Description = "a", Id = "1"},
                new CurrencyInformation{Description = "c", Id = "3"},
            };
            var date = new DateTime(2020, 1, 1);
            decimal rate = -1;
            var service = new MockSweaService(date, rate, info);
            var form = new MainForm(service);

            form.ConvertButton_Click(null, null);

            Assert.AreEqual("Valutakurs hittades inte", form.GetResultValue().Text);
            Assert.AreEqual("Kurs: -", form.GetExchange().Text);
        }
    }
}
