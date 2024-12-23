/*
 * Name: Parneet Kaur 
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-04-10
 * Updated: 2024-04-11
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.BIT.ADEV.Forms;
using Business.Parneet.Kaur;

namespace WindowsFormsApp.Parneet.Kaur
{
    public class FinancingForm: ACE.BIT.ADEV.Forms.FinancingForm
    {
        private VehicleQuote financequote;

        public FinancingForm(VehicleQuote quote)
        {
            this.financequote = quote;

            InitializeComponents();
            InitializeForm();
        }

        /// <summary>
        /// Initializes the Components of the Form. 
        /// </summary>
        public void InitializeComponents()
        {
            cboLoanTerm.Items.Add(3);
            cboLoanTerm.Items.Add(4);
            cboLoanTerm.Items.Add(5);
            cboLoanTerm.Items.Add(6);
            cboLoanTerm.Items.Add(7);

            cboLoanTerm.SelectedIndex = 2;

            nudAnnualInterestRate.Minimum = 0;
            nudAnnualInterestRate.Maximum = 25;
            nudAnnualInterestRate.Increment = 0.25m;
            nudAnnualInterestRate.DecimalPlaces=2;
            nudAnnualInterestRate.Value = 3.00m;

            this.lblQuotedPrice.Text = financequote.CalculateAmountDue().ToString("C2");

            CalculateAndDisplayMonthlyPayment();

            this.nudAnnualInterestRate.ValueChanged += NudAnnualInterestRate_ValueChanged;
            this.cboLoanTerm.SelectedValueChanged += CboLoanTerm_SelectedValueChanged;

        }

        //EVENTS 
        /// <summary>
        /// Handles the ValueChanged Event of the Menu Item "Loan Term".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboLoanTerm_SelectedValueChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayMonthlyPayment();
        }

        /// <summary>
        /// Handles the ValueChanged Event of the Menu Item "AnnualInterestRate".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NudAnnualInterestRate_ValueChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayMonthlyPayment();
        }

        //METHODS
        /// <summary>
        /// Initializes the Form. 
        /// </summary>
        public void InitializeForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Calculates the Monthly Payment. 
        /// </summary>
        private void CalculateAndDisplayMonthlyPayment()
        {
            int loanTerm = (int)cboLoanTerm.SelectedItem;
            decimal annualInterestRate = nudAnnualInterestRate.Value;
            decimal monthlyInterestRate = (annualInterestRate / 12)/100;
            int numberOfPayments = loanTerm * 12;

            decimal denominator = (decimal)Math.Pow(1 + (double)monthlyInterestRate, numberOfPayments) - 1;

            decimal monthlyPayment = financequote.CalculateAmountDue() *
                (monthlyInterestRate * (decimal)Math.Pow(1 + (double)monthlyInterestRate, numberOfPayments)) / denominator;

            txtMonthlyPayment.Text = monthlyPayment.ToString("C2");
        }
    }
}
