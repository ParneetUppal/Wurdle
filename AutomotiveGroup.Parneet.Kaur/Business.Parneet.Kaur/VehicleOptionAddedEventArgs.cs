using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parneet.Kaur
{
    /// <summary>
    /// Represents Event Data for VehicleOption added.
    /// </summary>
    public class VehicleOptionAddedEventArgs
    {
        /// <summary>
        /// Represents the option added to the quote. 
        /// </summary>
        public VehicleOption VehicleOptionAdded 
        { 
            get; 
            private set; 
        }

        /// <summary>
        /// Initializes a new instance of the VehicleOptionAddedEventArgs class.
        /// </summary>
        /// <param name="optionAdded"></param>
        public VehicleOptionAddedEventArgs(VehicleOption optionAdded)
        {
            this.VehicleOptionAdded = optionAdded;
        }
    }
}
