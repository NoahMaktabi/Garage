using System;
using System.Threading.Tasks;
using Application;
using Domain;
using Persistence;
using Presentation.Helpers;
using Presentation.MenuSystem;

namespace Presentation
{
    public static class MenuRunner
    {
        public static async Task Run()
        {
            "Welcome to your garage......".ShowAnimatedText(30);
            "The application is loading".ShowAnimatedText(30);
#pragma warning disable CA1416 // Validate platform compatibility
            Console.WindowHeight = 50;
#pragma warning restore CA1416 // Validate platform compatibility
            "*********".ShowAnimatedText(350);
            var garage = new Garage<Vehicle>
            {
                Vehicles = await DataHandler.GetParkedVehiclesAsync(),
                Capital = InputHandler.GetGarageCapital(),
            };
            var costPerHour = InputHandler.GetParkingCost();
            var garageCapacity = InputHandler.GetGarageCapacity(garage.Vehicles.Count);
            garage.Capacity = garageCapacity;

            IGarageManager manager = new GarageManager(garage, costPerHour);
            var mainMenu = new MainMenu(manager);
            await mainMenu.Run();
        }
    }
}