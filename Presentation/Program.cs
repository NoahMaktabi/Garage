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
