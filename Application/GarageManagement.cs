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

        public async Task<string> ParkAsync(Vehicle vehicle)
        {
            return await Park.ParkVehicle(_garage, vehicle);
        }
    }
}