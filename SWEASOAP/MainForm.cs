using System;
using System.Linq;
using System.Windows.Forms;

namespace SWEASOAP
{
    public partial class MainForm : Form
    {
        private ICurrencyConverter _CurrencyConverter;
        private IOrderedEnumerable<CurrencyInformation> _CurrencyInformation;
        public MainForm(ICurrencyConverter currencyConverter)
        {
            InitializeComponent();
            _CurrencyConverter = currencyConverter;

            // Set default date as latest supported date
            dateTimePicker.Value = _CurrencyConverter.GetClosestSupportedDate(DateTime.Now); ;

            // Update inputfield to allow numbers above 100
            InputValue.Maximum = decimal.MaxValue;

            PopulateDropDowns();
        }

        private void PopulateDropDowns()
        {
            _CurrencyInformation = _CurrencyConverter.GetSupportedCurrencies().OrderBy(d => d.Description);
            FromCurrency.Items.AddRange(_CurrencyInformation.Select(d => d.Description).ToArray());
            ToCurrency.Items.AddRange(_CurrencyInformation.Select(d => d.Description).ToArray());
            FromCurrency.SelectedIndex = ToCurrency.SelectedIndex = 0;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (InvalidInputData())
            {
                ResultValue.Text = "Ogiltig valuta";
                FromCurrency.SelectedIndex = ToCurrency.SelectedIndex = 0;
            }
            var rate = _CurrencyConverter.GetConversionRate(dateTimePicker.Value, GetSelectedCurrencyId(FromCurrency), GetSelectedCurrencyId(ToCurrency));
            
            if (rate < 0)
            {
                ResultValue.Text = "Valutakurs hittades inte";
                Exchange.Text = "Kurs: -";
                return;
            }
            Exchange.Text = "Kurs: " + rate.ToString(); ;
            ResultValue.Text = Math.Round(rate * InputValue.Value, 2).ToString("0.00");
        }

        private bool InvalidInputData()
        {
            // Round for normal currency handeling
            InputValue.Value = Math.Round(InputValue.Value, 2);
            
            // Stop conversions for furure dates 
            if (dateTimePicker.Value > DateTime.Now) dateTimePicker.Value = DateTime.Now;

            dateTimePicker.Value = _CurrencyConverter.GetClosestSupportedDate(dateTimePicker.Value);
            return FromCurrency.SelectedItem == null || ToCurrency.SelectedItem == null;
        }

        private string GetSelectedCurrencyId(ComboBox box)
        {
            return _CurrencyInformation.Where(c => c.Description == (string) box.SelectedItem).Single().Id;
        }
    }
}
