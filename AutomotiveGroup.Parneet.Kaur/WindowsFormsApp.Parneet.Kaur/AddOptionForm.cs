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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WindowsFormsApp.Parneet.Kaur
{
    public class AddOptionForm : ACE.BIT.ADEV.Forms.AddOptionForm
    {
        public VehicleOption OptionBeingAdded;
        public AddOptionForm()
        {
            InitializeComponents();
            InitializeForm();

            btnAdd.Click += BtnAdd_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        /// <summary>
        /// Handles the Click Event of the Menu Item "Cancel".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click Event of the Menu Item "Add".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider.SetError(txtDescription, "Description is Required.");
            }
            try
            {
                decimal unitprice = decimal.Parse(txtUnitPrice.Text);
                if(unitprice < 0)
                {
                    errorProvider.SetError(txtUnitPrice, "The Value Must be Greater than Zero");
                    return;
                }
                OptionBeingAdded = new VehicleOption(txtDescription.Text, unitprice, (int)nudQuantity.Value);             
                this.Close();
                NewAddedOption();
            }
            catch (FormatException exception)
            {
                errorProvider.SetError(txtUnitPrice, exception.Message);
            }
        }

        /// <summary>
        /// Initializes the Components of the Form 
        /// </summary>
        private void InitializeComponents()
        {
            nudQuantity.Minimum = 1;
            nudQuantity.Maximum = 100;
            nudQuantity.ReadOnly = true;

            this.errorProvider.SetIconPadding(txtUnitPrice, 3);
            this.errorProvider.SetIconPadding(txtDescription, 3);

            this.errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        /// <summary>
        /// Initializes the Form.
        /// </summary>
        private void InitializeForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Updates the Vehicleoption.
        /// </summary>
        /// <returns>OptionBeingAdded</returns>
        private VehicleOption NewAddedOption()
        {
            return OptionBeingAdded;
        }
    }
}
