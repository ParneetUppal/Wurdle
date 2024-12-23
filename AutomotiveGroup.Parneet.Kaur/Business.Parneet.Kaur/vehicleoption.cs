/*
 * Name: Parneet Kaur Uppal 
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 02/05/2024
 * Updated: 02/10/2024
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parneet.Kaur
{
    /// <summary>
    /// Represents a customizable option that can be added to a vehicle, such as upgrades or accessories.
    /// </summary>
    public class VehicleOption
    {
        /// <summary>
        /// Gets the description of the vehicle option.
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the price per unit of the vehicle option.
        /// </summary>
        public decimal UnitPrice
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the number of the option ordered.
        /// </summary>
        public int Quantity
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes an instance of the VehicleOption class with the specified description, unit price, and quantity.
        /// </summary>
        /// <param name="Description">Description of the vehicle option.</param>
        /// <param name="UnitPrice">Price per unit of the vehicle option.</param>
        /// <param name="Quantity">Number of the option ordered.</param>
        public VehicleOption(string Description, decimal UnitPrice, int Quantity)
        {
            if (Description.Trim().Length == 0)
            {
                throw new ArgumentException($"The {Description} must" +
                    $" contain non-whitespace characters."
                    , "Description"
                    );
            }
            this.Description = Description;

            if (UnitPrice <= 0)
            {
                throw new ArgumentOutOfRangeException("UnitPrice",
                    $"The {UnitPrice} must be 0 or greater."
                    );
            }
            this.UnitPrice = UnitPrice;

            if (Quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Quantity",
                    $"The {Quantity} must be 0 or greater."
                    );
            }
            this.Quantity = Quantity;
        }

        /// <summary>
        /// Overrides the ToString method to provide a formatted string representation of the VehicleOption.
        /// </summary>
        /// <returns>A formatted string representing the VehicleOption.</returns>
        public override string ToString()
        {
            return $"{Description} x {Quantity} @ {UnitPrice:C}";
        }
    }

}
