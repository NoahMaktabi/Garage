using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features;
using Domain;
using Domain.Vehicles;
using Persistence;

namespace Application
{
    public class GarageManager : IGarageManager
    {
        private readonly Garage<Vehicle> _garage;

        public GarageManager(Garage<Vehicle> garage, int garageCapacity)
        {
            _garage = garage;
            _garage.Vehicles = DataHandler.GetParkedVehiclesAsync().Result;
            _garage.Capacity = garageCapacity;
            DataHandler.SetParkingSpotsAsync(garageCapacity, _garage.Vehicles).Wait();
            _garage.ParkingSpots = DataHandler.GetParkingSpotsAsync().Result;
        }

        #region ParkVehicle

        
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
        #endregion

        #region GetVehicle

        /// <summary>
        /// Provide a valid licensePlate. The method will search the vehicles in the garage and return the requested vehicle. 
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <returns>A vehicle object matching the provided licensePlate if found. Otherwise null.</returns>
        public Vehicle GetVehicleByLicensePlate(string licensePlate)
        {
            return _garage.FirstOrDefault(v => v.LicensePlate == licensePlate);
        }
        #endregion

        #region GetVehiclesByType

        /// <summary>
        /// Provide the vehicle type. Returns a list of vehicle of the provided type.
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns>Returns a list of vehicle of the provided type.</returns>
        public List<Vehicle> GetParkedVehicles(VehicleType vehicleType)
        {
            return vehicleType switch
            {
                VehicleType.All => _garage.Vehicles,
                VehicleType.Bus => _garage.Vehicles.Where(v => v is Bus).ToList(),
                VehicleType.Car => _garage.Vehicles.Where(v => v is Car).ToList(),
                VehicleType.Truck => _garage.Vehicles.Where(v => v is Truck).ToList(),
                VehicleType.Rv => _garage.Vehicles.Where(v => v is RecreationalVehicle).ToList(),
                VehicleType.Mc => _garage.Vehicles.Where(v => v is Motorcycle).ToList(),
                _ => null,
            };
        }
        #endregion
    }
}