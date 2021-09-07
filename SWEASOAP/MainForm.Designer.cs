
namespace SWEASOAP
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromCurrency = new System.Windows.Forms.ComboBox();
            this.ToCurrency = new System.Windows.Forms.ComboBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.InputValue = new System.Windows.Forms.NumericUpDown();
            this.ResultValue = new System.Windows.Forms.Label();
            this.Exchange = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InputValue)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 74);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // FromCurrency
            // 
            this.FromCurrency.FormattingEnabled = true;
            this.FromCurrency.Location = new System.Drawing.Point(172, 6);
            this.FromCurrency.Name = "FromCurrency";
            this.FromCurrency.Size = new System.Drawing.Size(220, 21);
            this.FromCurrency.TabIndex = 1;
            // 
            // ToCurrency
            // 
            this.ToCurrency.FormattingEnabled = true;
            this.ToCurrency.Location = new System.Drawing.Point(172, 48);
            this.ToCurrency.Name = "ToCurrency";
            this.ToCurrency.Size = new System.Drawing.Size(220, 21);
            this.ToCurrency.TabIndex = 2;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(317, 75);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(75, 23);
            this.ConvertButton.TabIndex = 3;
            this.ConvertButton.Text = "Konvertera";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(12, 9);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(28, 13);
            this.FromLabel.TabIndex = 4;
            this.FromLabel.Text = "Från";
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(12, 51);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(20, 13);
            this.ToLabel.TabIndex = 5;
            this.ToLabel.Text = "Till";
            // 
            // InputValue
            // 
            this.InputValue.DecimalPlaces = 2;
            this.InputValue.Location = new System.Drawing.Point(46, 7);
            this.InputValue.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.InputValue.Name = "InputValue";
            this.InputValue.Size = new System.Drawing.Size(120, 20);
            this.InputValue.TabIndex = 6;
            // 
            // ResultValue
            // 
            this.ResultValue.AutoSize = true;
            this.ResultValue.Location = new System.Drawing.Point(43, 51);
            this.ResultValue.Name = "ResultValue";
            this.ResultValue.Size = new System.Drawing.Size(10, 13);
            this.ResultValue.TabIndex = 7;
            this.ResultValue.Text = "-";
            // 
            // Exchange
            // 
            this.Exchange.AutoSize = true;
            this.Exchange.Location = new System.Drawing.Point(218, 80);
            this.Exchange.Name = "Exchange";
            this.Exchange.Size = new System.Drawing.Size(37, 13);
            this.Exchange.TabIndex = 8;
            this.Exchange.Text = "Kurs: -";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(404, 201);
            this.Controls.Add(this.Exchange);
            this.Controls.Add(this.ResultValue);
            this.Controls.Add(this.InputValue);
            this.Controls.Add(this.ToLabel);
            this.Controls.Add(this.FromLabel);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.ToCurrency);
            this.Controls.Add(this.FromCurrency);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "MainForm";
            this.Text = "Valutakonverterare";
            ((System.ComponentModel.ISupportInitialize)(this.InputValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox FromCurrency;
        private System.Windows.Forms.ComboBox ToCurrency;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.NumericUpDown InputValue;
        private System.Windows.Forms.Label ResultValue;
        private System.Windows.Forms.Label Exchange;
    }
}

