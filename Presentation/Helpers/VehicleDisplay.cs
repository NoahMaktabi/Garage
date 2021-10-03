using System.Diagnostics;
using System.Text.Json.Serialization;
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
                    GetCarDetails(c).ShowAnimatedText(1);
                    break;
                case Truck t:
                    GetTruckDetails(t).ShowAnimatedText(1);
                    break;
                case Bus b:
                    GetBusDetails(b).ShowAnimatedText(1);
                    break;
                case Motorcycle m:
                    GetMcDetails(m).ShowAnimatedText(1);
                    break;
                case RecreationalVehicle r:
                    GetRvDetails(r).ShowAnimatedText(1);
                    break;
            }
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