using System;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain.Vehicles;
using Persistence;
using Presentation.Helpers;
using Presentation.Interfaces;

namespace Presentation.MenuSystem.SubMenus
{
    public class ShowVehiclesMenu
    {
        private readonly IGarageManager _manager;
        private readonly IVehicleDisplay _vehicleDisplay;

        public ShowVehiclesMenu(IGarageManager manager)
        {
            _manager = manager;
            _vehicleDisplay = new VehicleDisplay();
        }
        public bool Run()
        {
            const string prompt = "Below is a list of the vehicles in the garage with the total of each type. \nChoose to type to show details.";
            startLabel:
            var options = GetMenuOptions();
            var menu = new MenuBuilder(prompt, options);
            var selectedIndex = menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    ShowVehicleList(_vehicleDisplay, VehicleType.All);
                    break;
                case 1:
                    ShowVehicleList(_vehicleDisplay, VehicleType.Car);
                    break;
                case 2:
                    ShowVehicleList(_vehicleDisplay, VehicleType.Truck);
                    break;
                case 3:
                    ShowVehicleList(_vehicleDisplay, VehicleType.Bus);
                    break;
                case 4:
                    ShowVehicleList(_vehicleDisplay, VehicleType.Mc);
                    break;
                case 5:
                    ShowVehicleList(_vehicleDisplay, VehicleType.Rv);
                    break;
                case 6:
                    return false;
            }
            "\nPress any key to return to the list.".ShowAnimatedText(10);
            Console.ReadKey(true);
            goto startLabel;
        }

        private void ShowVehicleList(IVehicleDisplay vehicleDisplay, VehicleType vehicleType)
        {
            var list = _manager.GetParkedVehicles(vehicleType);
            list.ForEach(vehicleDisplay.ShowVehicleDetails);
        }


        private string[] GetMenuOptions()
        {
            var options = new string[7];
            var list = _manager.GetParkedVehicles(VehicleType.All);
            options[0] = $"All vehicles: [{list.Count}]";
            options[1] = $"Cars: [{list.Count(v => v is Car)}]";
            options[2] = $"Trucks: [{list.Count(v => v is Truck)}]";
            options[3] = $"Buses: [{list.Count(v => v is Bus)}]";
            options[4] = $"Motorcycles: [{list.Count(v => v is Motorcycle)}]";
            options[5] = $"Recreational vehicles(RVs): [{list.Count(v => v is RecreationalVehicle)}]";
            options[6] = "Back to main menu";
            return options;
        }
    }
}