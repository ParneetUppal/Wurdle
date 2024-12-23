using Business.Parneet.Kaur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


/*
 * Name: Parneet Kaur Uppal 
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 03/18/2024
 * Updated: 03/24/2024
 */

namespace ConsoleApp.Parneet.Kaur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // 1. Declare and define a variable that references a VehicleQuote object. 
            VehicleQuote quote;

            quote = new VehicleQuote(562356m, 0.6m, 896562m);
            
            // 2. Define a methoConsole.WriteLine(quote.salePrice);d in this class that handles the event that occurs when the sale price changes.
            //    The handler method will print: "The sale price changed to {sale-price}."
            //    Subscribe to the event below using the handler method you just defined.

            quote.SalePriceChanged += Quote_SalePriceChanged;

            // 3. Define a method in this class that handles the event that occurs when an option is added to the quote.
            //    The handler method will print: "The following option was added to the quote:\n{vehicle-option}" 
            //    Subscribe to the event below using the handler method you just defined.
            quote.VehicleOptionAdded += Quote_VehicleOptionAdded;

            // 4. Define a method in this class that handles the event that occurs when trade-in value has been changed.
            //    The handler method will print "The trade-in value has been changed."
            //    Subscribe to the event below using the handler method you just defined.            
            quote.TradeinvalueChanged += Quote_TradeinvalueChanged;

            // 5. Declare and define a variable to reference a new instance of the VehicleOption class.
            VehicleOption option = new VehicleOption("Tail Lamps", 25m, 2);

            // 6. Add the VehicleOption created in the previous statement to the options of the
            //    VehicleQuote instance.
            quote.AddOption(option);

            // 7. Add two more VehicleOption objects to the VehicleQuote instance. Only use two statements
            //    to accomplish this step.
            quote.AddOption(new VehicleOption("Sunroof", 800m,5));
            quote.AddOption(new VehicleOption("GPS Navigation", 800m, 5));

            // 8. Change the sale price of the VehicleQuote to a different value than its current state.
            quote.SalePrice = 98899m;
            
            // 9. Add another VehicleOption to the VehicleQuote.
            quote.AddOption(new VehicleOption("Alloy Wheels", 800m, 5));

            // 10. Change the trade-in value of the VehicleQuote to a different value than its current state.
            quote.TradeInValue = 34000;

            // 11. Repeat the previous statement.
            quote.TradeInValue = 49000;
            
            Console.WriteLine("Press Key to continue....");
            Console.ReadKey();
        }

        /// <summary>
        /// Handles the OnTradeinvalueChanged event of the VehicleQuote. 
        /// </summary>
        private static void Quote_TradeinvalueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The trade-in value has been changed.");
        }

        /// <summary>
        /// Handles the OnVehicleOptionAdded event of the VehicleQuote.
        /// </summary>
        private static void Quote_VehicleOptionAdded(object sender, VehicleOptionAddedEventArgs e)
        {
            Console.WriteLine($"The following option was added to the quote:\n{e.VehicleOptionAdded}");
        }

        /// <summary>
        /// Handles the OnSalePriceChanged event of the Quote. 
        /// </summary>
        private static void Quote_SalePriceChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The sale price Changed to {0:C}",((Quote)sender).SalePrice);
        }
    }
}
