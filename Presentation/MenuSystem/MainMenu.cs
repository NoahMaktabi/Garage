using System;
using Application;
using Domain;
using Presentation.Helpers;
using Presentation.MenuSystem.SubMenus;

namespace Presentation.MenuSystem
{
    public class MainMenu
    {
        private readonly IGarageManager _manager;

        public MainMenu(IGarageManager manager)
        {
            _manager = manager;
        }
        public void Run()
        {
            const string prompt = @"
Welcome to your garage. What would you like to do?
(Use the arrow keys to cycle through options and press enter to select an option)";


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
                    ShowParkedVehicles(_manager);
                    break;
                case 1:
                    ParkVehicle();
                    break;
                case 2:
                    RemoveVehicle();
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

        
        private void ShowParkedVehicles(IGarageManager manager)
        {
            var showVehiclesMenu = new ShowVehiclesMenu(manager);
            while (!showVehiclesMenu.Run())
            {
                this.Run();
            }
        }
        private void ParkVehicle()
        {
            throw new NotImplementedException();
        }

        private void RemoveVehicle()
        {
            throw new NotImplementedException();
        }

        private void ViewGarageStatus()
        {
            throw new NotImplementedException();
        }

        private void FindVehicleByLicensePlate()
        {
            throw new NotImplementedException();
        }

        private void SearchVehicles()
        {
            throw new NotImplementedException();
        }

        
        private static void ExitApp()
        {
            "Thank you for using this app. Take care".ShowAnimatedText(4);
            Environment.Exit(0);
        }
    }
}