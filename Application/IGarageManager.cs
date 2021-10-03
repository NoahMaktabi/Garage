using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Persistence;

namespace Application
{
    public interface IGarageManager
    {
        /// <summary>
        /// Provide a vehicle to park. The method will check for available spots
        /// in the garage and add the vehicle to the database. The method will also reserve a parking spot in the database for the vehicle. 
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>A string with info about the operation. If success with a spot number. If failure with info about that.</returns>
        Task<string> ParkAsync(Vehicle vehicle);

        /// <summary>
        /// Provide a valid licensePlate. The method will search the vehicles in the garage and return the requested vehicle. 
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <returns>A vehicle object matching the provided licensePlate if found. Otherwise null.</returns>
        Vehicle GetVehicleByLicensePlate(string licensePlate);

        /// <summary>
        /// Provide the vehicle type. Returns a list of vehicle of the provided type.
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns>Returns a list of vehicle of the provided type.</returns>
        List<Vehicle> GetParkedVehicles(VehicleType vehicleType);
    }
}