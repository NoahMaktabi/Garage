using Domain;
using Domain.Vehicles;

namespace Presentation.Helpers
{
    public static class VehicleHandler
    {
        public static Truck GetTruckDetails()
        {
            var truck = GetVehicleDetails<Truck>();
            truck.Height = InputHandler.GetVehicleHeight();
            truck.CoolerTruck = InputHandler.GetBoolValue("Is the truck a cooler truck?");
            truck.WithTrailer = InputHandler.GetBoolValue("Does the truck have a trailer?");
            truck.Wheels = InputHandler.GetWheelsTotal();
            return truck;
        }
        public static Bus GetBusDetails()
        {
            var bus = GetVehicleDetails<Bus>();
            bus.Height = InputHandler.GetVehicleHeight();
            /*
             * Input handlers for bus properties
             */

            return bus;
        }
        public static Car GetCarDetails()
        {
            var car = GetVehicleDetails<Car>();
            /*
             * Input handlers for car properties
             */

            return car;
        }


        private static T GetVehicleDetails<T>() where T : Vehicle
        {
            var vehicle = new
            {
                LicensePlate = InputHandler.GetLicensePlate(),
                Make = InputHandler.GetString(prompt: "Please enter the brand/manufacturer of the vehicle"),
                Model = InputHandler.GetString(prompt: "Please enter the model of the vehicle"),
                Year = InputHandler.GetYear(),
                //Color input should be implemented
            };
            return vehicle as T;
        }
    }
}