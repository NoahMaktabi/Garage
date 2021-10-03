using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Vehicles;
using Persistence;

namespace Application.Features
{
    public class Park
    {
        /// <summary>
        /// Provide an instance of garage and the vehicle to park. The method will check for available spots
        /// in the garage and add the vehicle to the database. The method will also reserve a parking spot in the database for the vehicle. 
        /// </summary>
        /// <param name="garage"></param>
        /// <param name="vehicle"></param>
        /// <returns>A string with info about the operation. If success with a spot number. If failure with info about that.</returns>
        public static async Task<string> ParkVehicleAsync(Garage<Vehicle> garage, Vehicle vehicle)
        {
            var availableSpot = garage.ParkingSpots.FirstOrDefault(s => s.IsAvailable);
            if (availableSpot == null)
                return "There are no available parking spots in the garage!";
            
            availableSpot.IsAvailable = false;
            vehicle.ParkingSpotNumber = availableSpot.Id;
            availableSpot.ParkedVehicle = vehicle;
            await DataHandler.EditParkingSpotAsync(availableSpot);

            switch (vehicle)
            {
                case Car:
                    await DataHandler.AddToParkedVehiclesAsync(vehicle, VehicleType.Car);
                    break;
                case Bus:
                    await DataHandler.AddToParkedVehiclesAsync(vehicle, VehicleType.Bus);
                    break;
                case Truck:
                    await DataHandler.AddToParkedVehiclesAsync(vehicle, VehicleType.Truck);
                    break;
                case Motorcycle:
                    await DataHandler.AddToParkedVehiclesAsync(vehicle, VehicleType.Mc);
                    break;
                case RecreationalVehicle:
                    await DataHandler.AddToParkedVehiclesAsync(vehicle, VehicleType.Rv);
                    break;
            }
            garage.Vehicles.Add(vehicle);

            return $"The vehicle with license plate {vehicle.LicensePlate} is now parked in parking spot number {vehicle.ParkingSpotNumber}";
        }
    }
}