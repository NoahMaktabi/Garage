using System;
using System.Collections.Generic;
using Domain;
using Presentation.Helpers;
using Presentation.Interfaces;

namespace Presentation.MenuSystem.SubMenus
{
    public class ShowSearchHits
    {
        private readonly IVehicleDisplay _vehicleDisplay;
        
        public ShowSearchHits()
        {
            _vehicleDisplay = new VehicleDisplay();
        }

        public void Run(List<Vehicle> vehicles)
        {
            var vehicleCount = vehicles.Count;
            
            if (vehicleCount > 0)
            {
                Console.Clear();
                Console.WriteLine(vehicleCount + " vehicles was found in the garage!");
                vehicles.ForEach(_vehicleDisplay.ShowVehicleDetails);
            }
            else
            {
                "Couldn't find any vehicles with the provided search query.".ShowAnimatedText(5);
            }
            
            "\nPress any key to return to the list.".ShowAnimatedText(10);
            /* TODO return to main menu */
        }
    }
}