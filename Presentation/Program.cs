using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            await DataHandler.AddToParkedVehicles(newBus, VehicleType.Bus);

            var list = await DataHandler.GetParkedVehicles();
            list.ForEach(c =>
            {
                Console.WriteLine(c.LicensePlate);
            });
        }
    }
}
