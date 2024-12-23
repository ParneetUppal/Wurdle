/*
 * Name: Parneet Kaur Uppal 
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 01/15/2024
 * Updated: 02/05/2024
 */
using System;
using System.Globalization;

namespace Business.Parneet.Kaur
{
    /// <summary>
    /// Represents a vehicle with properties such as Year, Model, Manufacturer, Color, and SalePrice.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Gets the year of the vehicle's production.
        /// </summary>
        public int Year
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string Model
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the manufacturer's name of the vehicle.
        /// </summary>
        public string Manufacturer
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the color of the vehicle using the PaintColor enum.
        /// </summary>
        public PaintColor Color
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the sale price of the vehicle.
        /// </summary>
        public decimal SalePrice
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes an instance of the Vehicle class with specified Year, Model, Manufacturer, Color, and SalePrice.
        /// </summary>
        /// <param name="Year">Year of the vehicle production.</param>
        /// <param name="Model">The model of the vehicle.</param>
        /// <param name="Manufacturer">Vehicle's manufacturer.</param>
        /// <param name="Color">Vehicle's color using the PaintColor enum.</param>
        /// <param name="SalePrice">Vehicle's sale price.</param>
        public Vehicle(int Year, string Model, string Manufacturer, PaintColor Color, decimal SalePrice)
        {
            if (Year < 1950 || Year > DateTime.Now.Year + 1)
            {
                throw new ArgumentOutOfRangeException("Year",
                    $"The {Year} must be in the range of {1950}" +
                    $" to {DateTime.Now.Year + 1}."
                    );
            }
            this.Year = Year;

            if (Manufacturer.Trim().Length == 0)
            {
                throw new ArgumentException(
                    $"The {Manufacturer} must contain non-whitespace characters.",
                    "Manufacturer"
                );
            }
            this.Manufacturer = Manufacturer;

            if (Model.Trim().Length == 0)
            {
                throw new ArgumentException(
                    $"The {Model} must contain non-whitespace characters.",
                    "Model"
                );
            }
            this.Model = Model;
            this.Color = Color;

            if (SalePrice <= 0)
            {
                throw new ArgumentOutOfRangeException("Saleprice",
                    $"The {SalePrice} must be 0 or greater."
                    );
            }
            this.SalePrice = SalePrice;
        }

        /// <summary>
        /// Generates a formatted string including year, manufacturer, model, and color of the vehicle.
        /// </summary>
        /// <returns>A formatted string.</returns>
        public override string ToString()
        {
            return $"{Year}, {Manufacturer}, {Model}, {Color.ToString()},{SalePrice:c}";
        }
    }
}
