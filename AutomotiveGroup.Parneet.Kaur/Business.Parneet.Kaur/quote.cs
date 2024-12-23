/*
 * Name: Parneet Kaur Uppal 
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 01/15/2024
 * Updated: 03/24/2024
 */
using System;

namespace Business.Parneet.Kaur
{
    /// <summary>
    /// Represents the Total Quoted Amount for the Vehicle after integration of tax.
    /// </summary>
    public abstract class Quote
    {
        /// <summary>
        /// Gets or sets the Tax rate applied to the vehicle sale price.
        /// </summary>
        public decimal salePrice;

        /// <summary>
        /// Occurs when <see cref="SalePrice"/> Changes. 
        /// </summary>
        public event EventHandler SalePriceChanged;

        public decimal TaxRate
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the Sale price of the vehicle.
        /// </summary>
        public decimal SalePrice
        {
            get
            {
                return this.salePrice;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value",
                        "The value must be greater than 0."
                        );
                }
                if(salePrice != value)
                {
                    salePrice = value;
                    OnSalepriceChange();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Quote"/> class with the specified sale price and tax rate.
        /// </summary>
        /// <param name="SalePrice">The sale price of the vehicle.</param>
        /// <param name="TaxRate">The tax rate applied to the sale price.</param>
        public Quote(decimal SalePrice, decimal TaxRate)
        {
            if (SalePrice <= 0)
            {
                throw new ArgumentOutOfRangeException("Saleprice",
                    $"The {SalePrice} must be greater than 0."
                    );
            }
            this.SalePrice = SalePrice;
            if (TaxRate <= 0 || TaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("Taxrate",
                    $"The {TaxRate} must be within the range of 0 to 1 (inclusive)."
                    );
            }
            this.TaxRate = TaxRate;
        }

        /// <summary>
        /// Calculates the tax charge for the vehicle by multiplying the sale price and tax rate.
        /// </summary>
        /// <returns>The product of sale price and tax rate in the form of decimal.</returns>
        public virtual decimal CalculateTaxCharge()
        {
            return SalePrice * TaxRate;
        }

        /// <summary>
        /// Sums up the value of tax charge and sale price to get the total calculated amount.
        /// </summary>
        /// <returns>The total calculated amount in the form of decimal.</returns>
        public virtual  decimal CalculateTotalCharge()
        {
            return SalePrice + CalculateTaxCharge();
        }

        /// <summary>
        /// Generates a formatted string representing the total calculated amount of the vehicle.
        /// </summary>
        /// <returns>A formatted string representing the total calculated amount.</returns>
        public override string ToString()
        {
            return $"Quote: {CalculateTotalCharge():C}";
        }

        /// <summary>
        /// Raises the SalePriceChanged Event. 
        /// </summary>
        protected virtual void OnSalepriceChange()
        {
            if (SalePriceChanged != null)
            {
                SalePriceChanged(this, EventArgs.Empty);
            }
        }
    }
}
