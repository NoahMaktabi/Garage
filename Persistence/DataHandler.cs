using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Vehicles;
using Newtonsoft.Json;

namespace Persistence
{
    public static class DataHandler
    {
        #region PathStrings
        private const string CarFilePath = @"..\..\..\..\Persistence\ParkedCars.json";
        private const string TruckFilePath = @"..\..\..\..\Persistence\ParkedTrucks.json";
        private const string RvFilePath = @"..\..\..\..\Persistence\ParkedRvs.json";
        private const string McFilePath = @"..\..\..\..\Persistence\ParkedMcs.json";
        private const string BusFilePath = @"..\..\..\..\Persistence\ParkedBuses.json";
        #endregion

        #region RemoveVehicleFromFile

        /// <summary>
        /// Provided a vehicle object and a selected type from enum VehicleType.
        /// The provided vehicle will be removed from the file that contains all the vehicles of the provided type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vehicle"></param>
        /// <param name="vType"></param>
        /// <returns></returns>
        public static async Task RemoveFromParkedVehiclesAsync<T>(T vehicle, VehicleType vType) where T : Vehicle
        {
            switch (vType)
            {
                case VehicleType.Car:
                    await RemoveVehicleFromFileAsync(CarFilePath, vehicle);
                    break;
                case VehicleType.Bus:
                    await RemoveVehicleFromFileAsync(BusFilePath, vehicle);
                    break;
                case VehicleType.Mc:
                    await RemoveVehicleFromFileAsync(McFilePath, vehicle);
                    break;
                case VehicleType.Rv:
                    await RemoveVehicleFromFileAsync(RvFilePath, vehicle);
                    break;
                case VehicleType.Truck:
                    await RemoveVehicleFromFileAsync(TruckFilePath, vehicle);
                    break;
            }
        }
        #endregion

        #region AddToParkedVehicles
        /// <summary>
        /// Provided a vehicle object and a selected type from enum VehicleType.
        /// The provided vehicle will be added to the file that contains all the vehicles of the provided type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vehicle"></param>
        /// <param name="vType"></param>
        /// <returns></returns>
        public static async Task AddToParkedVehiclesAsync<T>(T vehicle, VehicleType vType) where T : Vehicle
        {
            switch (vType)
            {
                case VehicleType.Car:
                    await AddVehicleToFileAsync(CarFilePath, vehicle);
                    break;
                case VehicleType.Bus:
                    await AddVehicleToFileAsync(BusFilePath, vehicle);
                    break;
                case VehicleType.Mc:
                    await AddVehicleToFileAsync(McFilePath, vehicle);
                    break;
                case VehicleType.Rv:
                    await AddVehicleToFileAsync(RvFilePath, vehicle);
                    break;
                case VehicleType.Truck:
                    await AddVehicleToFileAsync(TruckFilePath, vehicle);
                    break;
            }
        }
        #endregion

        #region GetParkedVehicles

        

        /// <summary>
        /// A generic method that reads the file associated with the provided type and return a list of existing vehicles.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vType"></param>
        /// <returns>List of existing vehicles of the provided type</returns>
        public static async Task<List<T>> GetParkedVehiclesAsync<T>(VehicleType vType) where T : Vehicle
        {
            return vType switch
            {
                VehicleType.Car => await ReadFileAsync<T>(CarFilePath),
                VehicleType.Bus => await ReadFileAsync<T>(BusFilePath),
                VehicleType.Truck => await ReadFileAsync<T>(TruckFilePath),
                VehicleType.Mc => await ReadFileAsync<T>(McFilePath),
                VehicleType.Rv => await ReadFileAsync<T>(RvFilePath),
                _ => null
            };
        }

        /// <summary>
        /// Reads all files containing vehicles and return a list of all existing vehicles. 
        /// </summary>
        /// <returns>List of all existing vehicles.</returns>
        public static async Task<List<Vehicle>> GetParkedVehiclesAsync()
        {
            var allVehicles = new List<Vehicle>();
            var cars = await ReadFileAsync<Car>(CarFilePath);
            var trucks = await ReadFileAsync<Truck>(TruckFilePath);
            var mcsList = await ReadFileAsync<Motorcycle>(McFilePath);
            var rvs = await ReadFileAsync<RecreationalVehicle>(RvFilePath);
            var buses = await ReadFileAsync<Bus>(BusFilePath);
            allVehicles.AddRange(cars);
            allVehicles.AddRange(trucks);
            allVehicles.AddRange(mcsList);
            allVehicles.AddRange(rvs);
            allVehicles.AddRange(buses);
            return allVehicles;
        }
        #endregion

        #region HandleFiles
        private static async Task<List<T>> ReadFileAsync<T>(string path)
        {
            using var reader = new StreamReader(path);
            var jsonFromFile = await reader.ReadToEndAsync();
            var list = JsonConvert.DeserializeObject<List<T>>(jsonFromFile);
            return list;
        }

        private static async Task AddVehicleToFileAsync<T>(string path, T vehicle) where T : Vehicle
        {
            var list = await ReadFileAsync<T>(path);
            list.Add(vehicle);
            
            var jsonToWrite = JsonConvert.SerializeObject(list, Formatting.Indented);
            await using var writer = new StreamWriter(path, false);
           
            await writer.WriteAsync(jsonToWrite);
        }

        private static async Task RemoveVehicleFromFileAsync<T>(string path, T vehicle) where T : Vehicle
        {
            var list = await ReadFileAsync<T>(path);
            var vehicleInList = list.FirstOrDefault(v => v.LicensePlate == vehicle.LicensePlate);
            list.Remove(vehicleInList);
            var jsonToWrite = JsonConvert.SerializeObject(list, Formatting.Indented);
            await using var writer = new StreamWriter(path, false);
           
            await writer.WriteAsync(jsonToWrite);
        }
        #endregion
    }
}