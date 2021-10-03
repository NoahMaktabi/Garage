using System.Linq;
using System.Threading.Tasks;
using Application.Features;
using Domain;
using Persistence;

namespace Application
{
    public class GarageManagement
    {
        private readonly Garage<Vehicle> _garage;

        public GarageManagement(Garage<Vehicle> garage, int garageCapacity)
        {
            _garage = garage;
            _garage.Vehicles = DataHandler.GetParkedVehiclesAsync().Result;
            _garage.Capacity = garageCapacity;
            DataHandler.SetParkingSpotsAsync(garageCapacity, _garage.Vehicles).Wait();
            _garage.ParkingSpots = DataHandler.GetParkingSpotsAsync().Result;
        }

        /// <summary>
        /// Provide a vehicle to park. The method will check for available spots
        /// in the garage and add the vehicle to the database. The method will also reserve a parking spot in the database for the vehicle. 
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>A string with info about the operation. If success with a spot number. If failure with info about that.</returns>
        public async Task<string> ParkAsync(Vehicle vehicle)
        {
            return await Park.ParkVehicleAsync(_garage, vehicle);
        }
    }
}