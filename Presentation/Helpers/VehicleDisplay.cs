using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Threading;
using Domain;
using Domain.Vehicles;
using Presentation.Interfaces;

namespace Presentation.Helpers
{
    public class VehicleDisplay : IVehicleDisplay
    {
        public void ShowVehicleDetails(Vehicle vehicle)
        {
            switch (vehicle)
            {
                case Car c:
                    DisplayString(GetCarDetails(c));
                    break;
                case Truck t:
                    DisplayString(GetTruckDetails(t));
                    break;
                case Bus b:
                    DisplayString(GetBusDetails(b));
                    break;
                case Motorcycle m:
                    DisplayString(GetMcDetails(m));
                    break;
                case RecreationalVehicle r:
                    DisplayString(GetRvDetails(r));
                    break;
            }
        }

        private static void DisplayString(string details)
        {
            Thread.Sleep(200);
            Console.WriteLine(details);
        }

        private static string GetRvDetails(RecreationalVehicle rv)
        {
            var vehicleInfo = GetVehicleCommonDetails(rv);
            vehicleInfo += $"\nHeight: {rv.Height}";
            vehicleInfo += $"\nNumber of wheels: {rv.Wheels}";
            return vehicleInfo;
        }

        private static string GetMcDetails(Motorcycle mc)
        {
            var vehicleInfo = GetVehicleCommonDetails(mc);
            vehicleInfo += $"\nType: {mc.Type}";
            vehicleInfo += $"\nHas alarm system: {(mc.HasAlarmSystem ? "Yes" : "No")}";
            return vehicleInfo;
        }

        private static string GetTruckDetails(Truck truck)
        {
            var vehicleInfo = GetVehicleCommonDetails(truck);
            vehicleInfo += $"\nIs a cooler truck: {(truck.CoolerTruck ? "Yes" : "No")}";
            vehicleInfo += $"\nHeight: {truck.Height}";
            vehicleInfo += $"\nNumber of wheels: {truck.Wheels}";
            vehicleInfo += $"\nHas a trailer: {(truck.WithTrailer ? "Yes" : "No")}";
            return vehicleInfo;
        }
        private static string GetBusDetails(Bus bus)
        {
            var vehicleInfo = GetVehicleCommonDetails(bus);
            vehicleInfo += $"\nHeight: {bus.Height}";
            vehicleInfo += $"\nEnergi type: {bus.FuelType}";
            return vehicleInfo;
        }
        private static string GetCarDetails(Car car)
        {
            var vehicleInfo = GetVehicleCommonDetails(car);
            vehicleInfo += $"\nType: {car.Type}";
            vehicleInfo += $"\nEnergi type: {car.FuelType}";
            return vehicleInfo;
        }

        private static string GetVehicleCommonDetails(Vehicle vehicle)
        {
            var info = "---------------------------";
            info += $"\nVehicle type: {vehicle.GetType().Name}";
            info += $"\nLicense plate: {vehicle.LicensePlate}";
            info += $"\nParking spot number: {vehicle.ParkingSpotNumber}";
            info += $"\nManufacturer: {vehicle.Make}";
            info += $"\nModel: {vehicle.Model}";
            info += $"\nYear: {vehicle.Year}";
            info += $"\nColor: {vehicle.Color.Name}";
            return info;
        }
    }
}