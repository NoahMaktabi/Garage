using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain;
using Domain.Vehicles;
using Newtonsoft.Json;
using Persistence;
using Presentation.Helpers;
using Presentation.Interfaces;

namespace Presentation
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var garage = new Garage<Vehicle>();
            var manager = new GarageManagement(garage, 50);

            //var list = await DataHandler.GetParkedVehiclesAsync();
            foreach (var vehicle in garage)
            {
                Console.WriteLine(vehicle.LicensePlate);
            }
            Console.WriteLine($"Available spots: {garage.ParkingSpots.Count(s => s.IsAvailable)}");
            var bus = new Bus
            {
                LicensePlate = "BUS987",
                Color = Color.Black,
                Make = "MAN",
                Model = "ManPower",
                Year = 2001,
                FuelType = FuelType.Diesel,
                Height = 3.6
            };

            IVehicleDetailsGetter getter = new VehicleDetailsGetter();
            var car = getter.GetCarDetails();
            car.GetType().Name.ShowAnimatedText(4);
            car.FuelType.ToString().ShowAnimatedText(4);
            car.Type.ToString().ShowAnimatedText(4);
            car.LicensePlate.ShowAnimatedText(4);
            car.Color.ToString().ShowAnimatedText(4);
            car.Year.ToString().ShowAnimatedText(4);

            // var response = await manager.ParkAsync(bus);

            Console.WriteLine("\n\n\nNew Entry");
            Console.WriteLine($"Available spots: {garage.ParkingSpots.Count(s => s.IsAvailable)}");
            foreach (var vehicle in garage)
            { 
                Console.WriteLine($"RegNr: {vehicle.LicensePlate} -- ParkingSpot: {vehicle.ParkingSpotNumber}");
            }

            //await DataHandler.AddToParkedVehiclesAsync(nCar, VehicleType.Car);
            //list = await DataHandler.GetParkedVehiclesAsync();
            //list.ForEach(c =>
            //{
            //    Console.WriteLine(c.LicensePlate);
            //});

        }
    }
}
