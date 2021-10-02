using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
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
            var list = await DataHandler.GetParkedVehiclesAsync();
            list.ForEach(c =>
            {
                Console.WriteLine(c.LicensePlate);
            });
            
            //await DataHandler.AddToParkedVehiclesAsync(nCar, VehicleType.Car);
            //list = await DataHandler.GetParkedVehiclesAsync();
            //list.ForEach(c =>
            //{
            //    Console.WriteLine(c.LicensePlate);
            //});

        }
    }
}
