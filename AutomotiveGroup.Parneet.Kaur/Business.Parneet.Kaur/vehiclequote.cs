/*
 * Name: Parneet Kaur Uppal 
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 02/05/2024
 * Updated: 03/24/2024
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parneet.Kaur
{
    /// <summary>
    /// Represents a quote for a vehicle, extending the base Quote class. 
    /// Includes information about the sale price, tax rate, trade-in value, and optional vehicle options.
    /// </summary>
    public class VehicleQuote : Quote
    {
        private decimal TradeinValue;
        private List<VehicleOption> options = new List<VehicleOption>();
        private Vehicle vehicle;

        /// <summary>
        /// Occurs When <see cref="TradeInValue"/> Changes.
        /// </summary>
        public event EventHandler TradeinvalueChanged;

        /// <summary>
        /// Occurs When an Option is added to the VehicleOption list. 
        /// </summary>
        public event EventHandler<VehicleOptionAddedEventArgs> VehicleOptionAdded;

        /// <summary>
        /// Occurs When VehicleOption is Removed from the List. 
        /// </summary>
        public event EventHandler VehicleOptionRemoved;

        /// <summary>
        /// Gets or sets the trade-in value for the vehicle.
        /// </summary>
        public decimal TradeInValue
        {
            get
            {
                return this.TradeinValue;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("TradeInValue",
                        "The Value must be 0 or greater."
                        );
                }
                if (TradeinValue != value)
                {
                    TradeinValue = value;
                    OnTradeInValueChange();
                }
            }
        }

        /// <summary>
        /// Gets or sets the list of optional vehicle options associated with the quote.
        /// </summary>
        public List<VehicleOption> Options
        {
            get
            {
                return this.options;
            }
            set
            {
                this.options = value;
            }
        }

        /// <summary>
        /// Gets or sets the vehicle associated with the quote.
        /// </summary>
        public Vehicle Vehicle
        {
            get
            {
                return this.vehicle;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("vehicle", "The value must be a reference to the Vehicle.");
                }
                this.vehicle = value;
                UpdateSalePrice();
            }
        }

        /// <summary>
        /// Initializes an instance of the <see cref="VehicleQuote"/> class with the specified sale price, tax rate, and optional trade-in value.
        /// </summary>
        /// <param name="SalePrice">The sale price of the vehicle.</param>
        /// <param name="TaxRate">The tax rate applied to the sale price.</param>
        /// <param name="TradeInValue">Optional trade-in value for the vehicle (default is 0).</param>
        public VehicleQuote(decimal SalePrice, decimal TaxRate, decimal TradeInValue)
            : base(SalePrice, TaxRate)
        {
            if (TradeInValue < 0)
            {
                throw new ArgumentOutOfRangeException("TradeInValue",
                    "The value must be 0 or greater."
                    );
            }
            this.TradeinValue = TradeInValue;
            this.Options = new List<VehicleOption>();
        }

        /// <summary>
        /// Updates the Saleprice of the Vehicle. 
        /// </summary>
        public void UpdateSalePrice()
        {
            SalePrice = Vehicle.SalePrice;
        }

        /// <summary>
        /// Adds a specified <see cref="VehicleOption"/> to the list of options
        /// in the <see cref="VehicleQuote"/>.
        /// </summary>
        /// <param name="option">The <see cref="VehicleOption"/> to be added</param>
        /// <exception cref="ArgumentNullException">Thrown when the specified option is null.</exception>
        public void AddOption(VehicleOption option)
        {
            if (option == null)
            {
                throw new ArgumentNullException("option", "The option must reference an object.");
            }

            this.Options.Add(option);

            OnVehicleOptionAdded(new VehicleOptionAddedEventArgs(option));
        }

        /// <summary>
        /// Removes a specified <see cref="VehicleOption"/> from the 
        /// list of options in the <see cref="VehicleQuote"/>.
        /// </summary>
        /// <param name="option">The <see cref="VehicleOption"/> to be removed. It must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when the specified option is null</exception>
        public void RemoveOption(VehicleOption option)
        {
            if (option == null)
            {
                throw new ArgumentNullException("option", "The options must be a value.");
            }
            this.Options.Remove(option);

            OnVehicleOptionRemoved();
        }

        /// <summary>
        /// Returns a copy of the options in the <see cref="VehicleQuote"/>.
        /// The method creates and returns an entirely new List containing the same 
        /// <see cref="VehicleOption"/> objects as the internal options state.
        /// The internal options state remains unchanged, and this method ensures that the reference to the original list is not exposed.
        /// </summary>
        /// <returns>A new <see cref="List{T}"/> containing a copy of the <see cref="VehicleOption"/> objects.</returns>
        public List<VehicleOption> GetCopyOptions()
        {
            return new List<VehicleOption>(Options);
        }

        /// <summary>
        /// Calculates and returns the sum of the prices of all <see cref="VehicleOption"/> 
        /// objects in the <see cref="VehicleQuote"/>.
        /// </summary>
        /// <returns>The sum of the prices of all <see cref="VehicleOption"/> 
        /// objects in the <see cref="VehicleQuote"/>.</returns>
        public decimal GetOptionsSum()
        {
            decimal sum = 0;

            foreach (VehicleOption option in Options)
            {
                sum += option.UnitPrice * option.Quantity;
            }

            return sum;
        }

        /// <summary>
        /// Calculates and returns the subtotal of the <see cref="VehicleQuote"/>.
        /// The subtotal is the sum of the sale price and the total price of the 
        /// options added to the <see cref="VehicleQuote"/>.
        /// </summary>
        /// <returns>The subtotal of the <see cref="VehicleQuote"/>.</returns>
        public decimal VehicleQuoteSubtotal()
        {
            decimal optionTotal = GetOptionsSum();
            return SalePrice + optionTotal;
        }

        /// <summary>
        /// Overrides the base class method to calculate 
        /// and return the sales tax based on a percentage of the subtotal.
        /// </summary>
        /// <returns>The Calculated sales tax.</returns>
        public virtual decimal SalesTax()
        {
            decimal subTotal = VehicleQuoteSubtotal();
            return subTotal * TaxRate;
        }

        /// <summary>
        /// Overrides the base class method to calculate 
        /// and return the total of the <see cref="VehicleQuote"/>.
        /// The total is the sum of the subtotal and sales tax, rounded to two decimal places.
        /// </summary>
        /// <returns>The calculated total of the <see cref="VehicleQuote"/>.</returns>
        public virtual decimal CalculateTotal()
        {
            decimal subTotal = VehicleQuoteSubtotal();
            decimal salesTax = SalesTax();
            decimal total = subTotal + salesTax;

            return Math.Round(total, 2);
        }

        /// <summary>
        /// Calculates and returns the amount due for the vehicle being purchased.
        /// The amount due is the <see cref="VehicleQuote"/> total minus the trade-in value.
        /// </summary>
        /// <returns>The calculated amount due for the vehicle being purchased.</returns>
        public decimal CalculateAmountDue()
        {
            decimal total = CalculateTotal();
            return total - TradeInValue;
        }

        /// <summary>
        /// Overrides the base class method to return a
        /// string representation of the <see cref="VehicleQuote"/> in the specified format.
        /// </summary>
        /// <returns>A string representation of the <see cref="VehicleQuote"/>.</returns>
        public override string ToString()
        {
            decimal amountDue = CalculateAmountDue();
            return $"VehicleQuote: {amountDue:C}";
        }

        /// <summary>
        /// Raises the <see cref="TradeinvalueChanged"/> event.
        /// </summary>
        protected virtual void OnTradeInValueChange()
        {
            if(TradeinvalueChanged!= null)
            {
                TradeinvalueChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raises the <see cref="VehicleOptionAdded"/> event. 
        /// </summary>
        protected virtual void OnVehicleOptionAdded(VehicleOptionAddedEventArgs eventArgs)
        {
            if(VehicleOptionAdded!= null)
            {
                VehicleOptionAdded(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Raises the <see cref="VehicleOptionRemoved"/> event.
        /// </summary>
        protected virtual void OnVehicleOptionRemoved()
        {
            if(VehicleOptionRemoved!= null)
            {
                VehicleOptionRemoved (this, EventArgs.Empty);
            }
        }
    }
}
