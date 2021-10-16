using System;
using System.Threading.Tasks;
using Application;
using Domain.Vehicles;
using Presentation.Helpers;
using Presentation.Interfaces;

namespace Presentation.MenuSystem.SubMenus
{
    public class ParkVehicleMenu
    {
        private readonly IGarageManager _manager;
        private readonly IVehicleDisplay _vehicleDisplay;
        private readonly IVehicleDetailsGetter _getter;

        public ParkVehicleMenu(IGarageManager manager)
        {
            _manager = manager;
            _vehicleDisplay = new VehicleDisplay();
            _getter = new VehicleDetailsGetter();
        }

        public async Task<bool> Run()
        {
            const string prompt = "Please choose the type of the vehicle that you want to park:";
            var options = new string[]
            {
                "Car",
                "Truck",
                "Bus",
                "RV",
                "Motorcycle"
            };

            var menu = new MenuBuilder(prompt, options);
            var selectedIndex = menu.Run();
            string result = "";
            switch (selectedIndex)
            {
                case 0:
                    var car = _getter.GetCarDetails();
                    result = await _manager.ParkAsync(car);
                    break;
                case 1:
                    var truck = _getter.GetTruckDetails();
                    result = await _manager.ParkAsync(truck);
                    break;
                case 2:
                    var bus = _getter.GetBusDetails();
                    result = await _manager.ParkAsync(bus);
                    break;
                case 3:
                    var rv = _getter.GetRvDetails();
                    result = await _manager.ParkAsync(rv);
                    break;
                case 4:
                    var mc = _getter.GetMcDetails();
                    result = await _manager.ParkAsync(mc);
                    break;
            }
            
            result.ShowAnimatedText(5);
            
            "Press any key to return to main menu...".ShowAnimatedText(5);
            Console.ReadKey(true);
            
            return false;
        }
    }
}