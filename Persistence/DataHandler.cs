using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Domain;
using Domain.Vehicles;
using Newtonsoft.Json;

namespace Persistence
{
    public static class DataHandler
    {
        private const string CarFilePath = @"C:\Users\mctab\Desktop\Cex\Garage\Persistence\ParkedCars.json";
        private const string TruckFilePath = @"C:\Users\mctab\Desktop\Cex\Garage\Persistence\ParkedTrucks.json";
        private const string RvFilePath = @"C:\Users\mctab\Desktop\Cex\Garage\Persistence\ParkedRvs.json";
        private const string McFilePath = @"C:\Users\mctab\Desktop\Cex\Garage\Persistence\ParkedMcs.json";
        private const string BusFilePath = @"C:\Users\mctab\Desktop\Cex\Garage\Persistence\ParkedBuses.json";


        public static async Task AddToParkedVehicles<T>(T vehicle, VehicleType vType) where T : Vehicle
        {
            switch (vType)
            {
                case VehicleType.Car:
                    await WriteToFile(CarFilePath, vehicle);
                    break;
                case VehicleType.Bus:
                    await WriteToFile(BusFilePath, vehicle);
                    break;
                case VehicleType.Mc:
                    await WriteToFile(McFilePath, vehicle);
                    break;
                case VehicleType.Rv:
                    await WriteToFile(RvFilePath, vehicle);
                    break;
                case VehicleType.Truck:
                    await WriteToFile(TruckFilePath, vehicle);
                    break;
            }
        }

        public static async Task<List<T>> GetParkedVehicles<T>(VehicleType vType) where T : Vehicle
        {
            return vType switch
            {
                VehicleType.Car => await ReadFile<T>(CarFilePath),
                VehicleType.Bus => await ReadFile<T>(BusFilePath),
                VehicleType.Truck => await ReadFile<T>(TruckFilePath),
                VehicleType.Mc => await ReadFile<T>(McFilePath),
                VehicleType.Rv => await ReadFile<T>(RvFilePath),
                _ => null
            };
        }

        public static async Task<List<Vehicle>> GetParkedVehicles()
        {
            var allVehicles = new List<Vehicle>();
            var cars = await ReadFile<Car>(CarFilePath);
            var trucks = await ReadFile<Truck>(TruckFilePath);
            var mcsList = await ReadFile<Motorcycle>(McFilePath);
            var rvs = await ReadFile<RecreationalVehicle>(RvFilePath);
            var buses = await ReadFile<Bus>(BusFilePath);
            allVehicles.AddRange(cars);
            allVehicles.AddRange(trucks);
            allVehicles.AddRange(mcsList);
            allVehicles.AddRange(rvs);
            allVehicles.AddRange(buses);
            return allVehicles;
        }

        private static async Task<List<T>> ReadFile<T>(string path)
        {
            using var reader = new StreamReader(path);
            var jsonFromFile = await reader.ReadToEndAsync();
            var list = JsonConvert.DeserializeObject<List<T>>(jsonFromFile);
            return list;
        }

        private static async Task WriteToFile<T>(string path, T vehicle) where T : Vehicle
        {
            var list = await ReadFile<T>(path);
            list.Add(vehicle);
            
            var jsonToWrite = JsonConvert.SerializeObject(list, Formatting.Indented);
            await using var writer = new StreamWriter(path, false);
           
            await writer.WriteAsync(jsonToWrite);
        }
    }
}