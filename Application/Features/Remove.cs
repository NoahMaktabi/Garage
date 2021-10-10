using System;
using System.Linq;
using Domain;
using System.Threading.Tasks;
using Persistence;
using Domain.Vehicles;

namespace Application.Features
{
    public class Remove
    {
        public static async Task<string> RemoveVehicleAsync(Garage<Vehicle> garage, GarageManager manager, string licensePlate)
        {
            var vehicle = manager.GetVehicleByLicensePlate(licensePlate);
            if (vehicle == null)
            {
                return "There is no vehicle with this licensePlate";
            }
            var parkingSpot =
                garage.ParkingSpots.FirstOrDefault(p => p.Id == vehicle.ParkingSpotNumber);
            decimal cost = 0;
            double totalHours = 0;
            if (parkingSpot != null)
            {
                garage.ParkingSpots.Remove(parkingSpot);
                parkingSpot.IsAvailable = true;
                parkingSpot.ParkedVehicle = null;
                parkingSpot.ParkingMeter.EndTime = DateTime.Now;
                var start = parkingSpot.ParkingMeter.StartTime;
                totalHours = (DateTime.Now - start).TotalHours;
                
                cost = (parkingSpot.CostPerHour * (decimal)totalHours);
                await DataHandler.EditParkingSpotAsync(parkingSpot);
            }
            switch (vehicle)
            {
                case Car:
                    await DataHandler.RemoveFromParkedVehiclesAsync(vehicle, VehicleType.Car);
                    break;
                case Bus:
                    await DataHandler.RemoveFromParkedVehiclesAsync(vehicle, VehicleType.Bus);
                    break;
                case Truck:
                    await DataHandler.RemoveFromParkedVehiclesAsync(vehicle, VehicleType.Truck);
                    break;
                case Motorcycle:
                    await DataHandler.RemoveFromParkedVehiclesAsync(vehicle, VehicleType.Mc);
                    break;
                case RecreationalVehicle:
                    await DataHandler.RemoveFromParkedVehiclesAsync(vehicle, VehicleType.Rv);
                    break;
            }

            garage.Vehicles.Remove(vehicle);
            
            garage.ParkingSpots.Add(parkingSpot);
            garage.Capital += cost;

            var startTime = parkingSpot?.ParkingMeter.StartTime.ToLongDateString() + " - " +
                            parkingSpot?.ParkingMeter.StartTime.ToLongTimeString();
            var endTime = parkingSpot?.ParkingMeter.EndTime.ToLongDateString() + " - " +
                          parkingSpot?.ParkingMeter.EndTime.ToLongTimeString();
            
            return $"Vehicle with license plate {vehicle.LicensePlate} is now out of the garage. \n" +
                   $"The vehicle entered the garage on {startTime}. \nAnd exited the garage on {endTime}.\n" +
                   $"The cost for parking is {parkingSpot?.CostPerHour:C2} per hour.\n" +
                   $"The vehicle was parked for {totalHours:N2} hours. The total cost was {cost:C2}. \n" +
                   $"The amount is added to the garage. The capital is now {garage.Capital:C2}";
        }
    }
}