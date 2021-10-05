using System;
using System.Collections.Generic;
using System.Drawing;
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

        public GarageManager(Garage<Vehicle> garage)
        {
            _garage = garage;
            DataHandler.SetParkingSpotsAsync(_garage.Capacity, _garage.Vehicles).Wait();
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
                VehicleType.All => _garage.Vehicles.OrderBy(v => v.ParkingSpotNumber).ToList(),
                VehicleType.Bus => _garage.Vehicles.Where(v => v is Bus).OrderBy(v => v.ParkingSpotNumber).ToList(),
                VehicleType.Car => _garage.Vehicles.Where(v => v is Car).OrderBy(v => v.ParkingSpotNumber).ToList(),
                VehicleType.Truck => _garage.Vehicles.Where(v => v is Truck).OrderBy(v => v.ParkingSpotNumber).ToList(),
                VehicleType.Rv => _garage.Vehicles.Where(v => v is RecreationalVehicle).OrderBy(v => v.ParkingSpotNumber).ToList(),
                VehicleType.Mc => _garage.Vehicles.Where(v => v is Motorcycle).OrderBy(v => v.ParkingSpotNumber).ToList(),
                _ => null,
            };
        }

        #endregion

        #region Search
        /// <summary>
        /// Find and return parked vehicles that matches the search query
        /// Searchable properties: Model, Make, Year
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Returns a list of vehicles.</returns>
        public List<Vehicle> FindParkedVehicles(string query)
        {
            query = query.Trim().ToLower();
            
            return _garage.Vehicles.FindAll(
                vehicle => vehicle.Model.ToLower().Contains(query) ||
                           vehicle.Make.ToLower().Contains(query) ||
                           (int.TryParse(query, out int year) && vehicle.Year == year)
            );
        }
        #endregion
    }
}