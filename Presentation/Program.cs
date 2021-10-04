using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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
            var manager = new GarageManager(garage, 50);

            // Search test
            //var results = manager.FindParkedVehicles("volv");
            //foreach (var result in results)
            //{
            //    Console.WriteLine(result.Make);
            //    Console.WriteLine(result.Model);
            //    Console.WriteLine(result.Year);
            //}
            
            //Console.WriteLine($"Available spots: {garage.ParkingSpots.Count(s => s.IsAvailable)}");

            //IVehicleDetailsGetter getter = new VehicleDetailsGetter();
            //var car = getter.GetCarDetails();
            IVehicleDisplay display = new VehicleDisplay();
            //display.ShowVehicleDetails(car);

            // var response = await manager.ParkAsync(bus);

            //Console.WriteLine("\n\n\nNew Entry");
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
