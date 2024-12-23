/*
 * Name: Parneet Kaur 
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-04-10
 * Updated: 2024-04-11
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.BIT.ADEV.Forms;
using Business.Parneet.Kaur;

namespace WindowsFormsApp.Parneet.Kaur
{
    public class QuoteForm : ACE.BIT.ADEV.Forms.QuoteForm
    {
        private const decimal taxRate = 0.12m;
        private VehicleQuote quoteAdded;

        public QuoteForm()
        {
            InitializeComponent();

            this.mnuNew.Click += MnuNew_Click;
            this.mnuExit.Click += MnuExit_Click;
            this.mnuAddOption.Click += MnuAddOption_Click;
            this.mnuRemoveOption.Click += MnuRemoveOption_Click;
            this.mnuFinancing.Click += MnuFinancing_Click;
            this.mnuAbout.Click += MnuAbout_Click;
            this.cboVehicle.SelectedIndexChanged += CboVehicle_Click;
            this.nudTradeInValue.ValueChanged += NudTradeInValue_ValueChanged;
        }

        //EVENTS//
        /// <summary>
        /// Handles the ValueChanged Event of the Menu Item "TradeinValue".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NudTradeInValue_ValueChanged(object sender, EventArgs e)
        {
            if (quoteAdded != null)
            {
                quoteAdded.TradeInValue = nudTradeInValue.Value;
                txtAmountDue.Text = $"{quoteAdded.CalculateAmountDue():C2}";
            }
        }

        /// <summary>
        /// Handles the Click Event of the Menu Item "Combobox".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboVehicle_Click(object sender, EventArgs e)
        {
            if (cboVehicle.SelectedIndex == -1)
            {
                ResetForm();
            }
            else
            {
                EnableFormControls();

                Vehicle selectVehicle = cboVehicle.SelectedItem as Vehicle;

                if (quoteAdded==null)
                {
                    quoteAdded = new VehicleQuote(selectVehicle.SalePrice, taxRate,nudTradeInValue.Value);        
                }
                else
                {
                    quoteAdded.Vehicle = selectVehicle;
                }
                txtSalePrice.Text = $"{quoteAdded.SalePrice}";
                UpdateQuote();
            }
        }

        /// <summary>
        /// Handles the Click Event of the Menu Item "About".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Click Event of the Menu Item "Financing".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuFinancing_Click(object sender, EventArgs e)
        {
            FinancingForm finance = new FinancingForm(quoteAdded);
            finance.ShowDialog();
        }

        /// <summary>
        /// Handles the Click Event of the Menu Item "AddOption".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuAddOption_Click(object sender, EventArgs e)
        {
            AddOptionForm addoptionform = new AddOptionForm();
            addoptionform.ShowDialog();
            VehicleOption newOption = addoptionform.OptionBeingAdded;

            if (newOption != null)
            {
                lstVehicleOptions.Items.Add(newOption);
                quoteAdded.AddOption(newOption);
                UpdateQuote();
            }
        }

        /// <summary>
        /// Handles the Click Event of the Menu Item "RemoveOption".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuRemoveOption_Click(object sender, EventArgs e)
        {
            if (lstVehicleOptions.SelectedIndex != -1)
            {
                int selectedindex = lstVehicleOptions.SelectedIndex;

                VehicleOption selectedOption = (VehicleOption)lstVehicleOptions.SelectedItem;

                lstVehicleOptions.Items.RemoveAt(selectedindex);
                quoteAdded.RemoveOption(selectedOption);

                UpdateQuote();
            }
        }

        /// <summary>
        /// Handles the Click Event of the Menu Item "Exit".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click Event of the Menu Item "New".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MnuNew_Click(object sender, EventArgs e)
        {
            DialogResult buttonclicked = MessageBox.Show("Are you sure You want to clear the Form?",
                this.Text = "New Quote",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (DialogResult.Yes == buttonclicked)
            {
                ResetForm();
            }
        }

        //METHODS//
        /// <summary>
        /// Initializes the QuoteForm Form
        /// </summary>
        private void InitializeComponent()
        {
            //Form Components
            this.Text = "Vehicle Quote - Parneet Kaur";
            this.StartPosition = FormStartPosition.CenterScreen;

            //lbltaxrate Components 
            this.lblTaxRate.Text = $"Tax ({taxRate}%)";

            //nudtradeinvalue Components 
            this.nudTradeInValue.Minimum = 0;
            this.nudTradeInValue.Maximum = 1000000;
            this.nudTradeInValue.DecimalPlaces = 2;
            this.nudTradeInValue.Increment = 500;
            this.nudTradeInValue.Value = 0;
            this.nudTradeInValue.Enabled = false;

            //errorprovider Components 
            foreach (Control control in Controls)
            {
                errorProvider.SetIconPadding(control, 3);
            }

            //cbovehicle Components
            cboVehicle.Items.Add(new Vehicle(2022, "Mercedes-Benz G-Class", "Mercedes-Benz", PaintColor.Black, 150000m));
            cboVehicle.Items.Add(new Vehicle(2023, "Civic", "Honda", PaintColor.Blue, 25000m));
            cboVehicle.Items.Add(new Vehicle(2021, "Camry", "Toyota", PaintColor.Black, 30000m));
            cboVehicle.Items.Add(new Vehicle(2024, "F-150", "Ford", PaintColor.White, 40000m));
            cboVehicle.Items.Add(new Vehicle(2022, "Accord", "Honda", PaintColor.Silver, 28000m));
            cboVehicle.Items.Add(new Vehicle(2015, "Zonda", "Pagani", PaintColor.Black, 18000000m));
            cboVehicle.Items.Add(new Vehicle(2024, "Corolla", "Toyota", PaintColor.Red, 26000m));
            cboVehicle.Items.Add(new Vehicle(2022, "Mustang", "Ford", PaintColor.Blue, 45000m));
            cboVehicle.Items.Add(new Vehicle(2023, "4Runner", "Toyota", PaintColor.White, 35000m));
            cboVehicle.Items.Add(new Vehicle(2021, "Civic", "Honda", PaintColor.Green, 27000m));

            cboVehicle.SelectedIndex = -1;
            cboVehicle.Focus();

            //Disables controls 
            foreach (Control control in Controls)
            {
                if (control != cboVehicle)
                {
                    control.Enabled = false;
                }
            }

            //listbox Add and Remove Disabled
            btnAddOption.Enabled = false;
            btnRemoveOption.Enabled = false;

            //Textboxes Empty 
            txtSalePrice.Text = string.Empty;
            txtTotalOptions.Text = string.Empty;
            txtSubtotal.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtAmountDue.Text = string.Empty;
        }

        /// <summary>
        /// Updates the QuoteForm Form 
        /// </summary>
        private void UpdateQuote()
        {
            //Total Options
            txtTotalOptions.Text = $"{quoteAdded.GetOptionsSum():C2}";
            //subtotal
            txtSubtotal.Text = $"{quoteAdded.VehicleQuoteSubtotal():C2}";
            //Tax calculate 
            txtTax.Text = $"{quoteAdded.SalesTax():C2}";
            //Total
            txtTotal.Text = $"{quoteAdded.CalculateTotal():C2}";
            //AmountDue 
            txtAmountDue.Text = $"{quoteAdded.CalculateAmountDue():C2}";
        }

        /// <summary>
        /// Enables the initially disabled Controls 
        /// </summary>
        private void EnableFormControls()
        {
            foreach (Control control in Controls)
            {
                if (control != cboVehicle)
                {
                    control.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Resets the QuoteForm Form 
        /// </summary>
        private void ResetForm()
        {
            txtSalePrice.Text = string.Empty;
            txtTotalOptions.Text = string.Empty;
            txtSubtotal.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtAmountDue.Text = string.Empty;

            foreach (Control control in Controls)
            {
                if (control != cboVehicle)
                {
                    control.Enabled = false;
                }
            }
        }

    }
}

