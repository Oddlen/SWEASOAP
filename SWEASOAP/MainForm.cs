using System;
using System.Linq;
using System.Windows.Forms;

namespace SWEASOAP
{
    public partial class MainForm : Form
    {
        private readonly ICurrencyConverter _CurrencyConverter;
        private IOrderedEnumerable<CurrencyInformation> _CurrencyInformation;

        public ComboBox GetFromCurrency() { return FromCurrency; }
        public ComboBox GetToCurrency() { return ToCurrency; }
        public Label GetResultValue() { return ResultValue; }
        public Label GetExchange() { return Exchange; }
        public DateTimePicker GetDateTimePicker() { return dateTimePicker; }
        public NumericUpDown GetInputValue() { return InputValue; }
        public Button GetConvertButton() { return ConvertButton; }

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

        public void PopulateDropDowns()
        {
            _CurrencyInformation = _CurrencyConverter.GetSupportedCurrencies().OrderBy(d => d.Description);
            
            // If no currenices are available, stop user fom pushing button 
            if (_CurrencyInformation.Count() < 1)
            {
                ConvertButton.Enabled = false;
                return;
            }
            
            FromCurrency.Items.AddRange(_CurrencyInformation.Select(d => d.Description).ToArray());
            ToCurrency.Items.AddRange(_CurrencyInformation.Select(d => d.Description).ToArray());
            FromCurrency.SelectedIndex = ToCurrency.SelectedIndex = 0;
        }

        public void ConvertButton_Click(object sender, EventArgs e)
        {
            if (InvalidInputData())
            {
                ResultValue.Text = "Ogiltig valuta";
                FromCurrency.SelectedIndex = ToCurrency.SelectedIndex = 0;
                Exchange.Text = "Kurs: -";
                return;
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
