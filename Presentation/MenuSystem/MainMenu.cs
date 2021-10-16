using System;
using System.Threading.Tasks;
using Application;
using Domain;
using Presentation.Helpers;
using Presentation.Interfaces;
using Presentation.MenuSystem.SubMenus;

namespace Presentation.MenuSystem
{
    public class MainMenu
    {
        private readonly IGarageManager _manager;
        private readonly IVehicleDisplay _display;

        public MainMenu(IGarageManager manager)
        {
            _manager = manager;
            _display = new VehicleDisplay();
        }
        public async Task Run()
        {
            var prompt = @"
Welcome to your garage. What would you like to do?
(Use the arrow keys to cycle through options and press enter to select an option)";
            prompt += $"\nThe capital of the garage is {_manager.GetCapital():C2}";
            prompt += $"\nYou have {_manager.GetTotalSpots()} parking spots in your garage.";
            prompt += $"\nYou have {_manager.GetUsedSpots()} used/unavailable parking spots.";
            prompt += $"\nYou have {_manager.GetAvailableSpots()} available parking spots.";


            string[] options =
            {
                "View parked vehicles", 
                "Park a vehicle", 
                "Remove a vehicle", 
                "View garage status",
                "Find a vehicle by license plate",
                "Search vehicles",
                "Exit",
            };
            var menu = new MenuBuilder(prompt, options);
            var selectedIndex = menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    await ShowParkedVehicles(_manager);
                    break;
                case 1:
                    ParkVehicle();
                    break;
                case 2:
                    await RemoveVehicle();
                    break;
                case 3:
                    ViewGarageStatus();
                    break;
                case 4:
                    FindVehicleByLicensePlate();
                    break;
                case 5:
                    SearchVehicles();
                    break;
                case 6:
                    ExitApp();
                    break;
                
            }
        }

        
        private async Task ShowParkedVehicles(IGarageManager manager)
        {
            var showVehiclesMenu = new ShowVehiclesMenu(manager);
            while (!showVehiclesMenu.Run())
            {
                await this.Run();
            }
        }
        private void ParkVehicle()
        {
            throw new NotImplementedException();
        }

        private async Task RemoveVehicle()
        {
            var licensePlate = InputHandler.GetLicensePlate();
            var vehicle = _manager.GetVehicleByLicensePlate(licensePlate);
            
            var result = await _manager.RemoveVehicle(licensePlate);
            result.ShowAnimatedText(5);
            "Press any key to go back to main menu...".ShowAnimatedText(10);
            Console.ReadKey(true);
            await this.Run();
        }

        private void ViewGarageStatus()
        {
            throw new NotImplementedException();
        }

        private async Task FindVehicleByLicensePlate()
        {
            var licensePlate = InputHandler.GetLicensePlate();
            var vehicle = _manager.GetVehicleByLicensePlate(licensePlate);
            
            if (vehicle == null)
            {
                "No vehicle was found with provided license plate.".ShowAnimatedText(10);
            }
            else
            {
                "The following vehicle was found!".ShowAnimatedText(10);
                _display.ShowVehicleDetails(vehicle);
            }
            
            "Press any key to go back to main menu...".ShowAnimatedText(10);
            Console.ReadKey(true);
            await this.Run();
        }

        private async Task SearchVehicles()
        {
            var query = InputHandler.GetSearchQuery();
            var vehicles = _manager.FindParkedVehicles(query);
            
            var showSearchHits = new ShowSearchHits();
            showSearchHits.Run(vehicles);
            Console.ReadKey(true);
            await this.Run();
        }

        
        private static void ExitApp()
        {
            "Thank you for using this app. Take care".ShowAnimatedText(4);
            Environment.Exit(0);
        }
    }
}