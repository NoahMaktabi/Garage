using Domain;
using Domain.Vehicles;

namespace Presentation.Helpers
{
    public static class VehicleHandler
    {
        public static Truck GetTruckDetails()
        {
            var truck = (Truck)GetVehicleDetails();
            truck.Height = InputHandler.GetVehicleHeight();
            truck.CoolerTruck = InputHandler.GetBoolValue("Is the truck a cooler truck?");
            truck.WithTrailer = InputHandler.GetBoolValue("Does the truck have a trailer?");
            truck.Wheels = InputHandler.GetWheelsTotal();
            return truck;
        }
        public static Bus GetBusDetails()
        {
            var bus = (Bus)GetVehicleDetails();
            bus.Height = InputHandler.GetVehicleHeight();
            /*
             * Input handlers for bus properties
             */

            return bus;
        }
        public static Car GetCarDetails()
        {
            var car = (Car)GetVehicleDetails();
            /*
             * Input handlers for car properties
             */

            return car;
        }


        private static Vehicle GetVehicleDetails()
        {
            var vehicle = new Vehicle
            {
                LicensePlate = InputHandler.GetLicensePlate(),
                Make = InputHandler.GetString(prompt: "Please enter the brand/manufacturer of the vehicle"),
                Model = InputHandler.GetString(prompt: "Please enter the model of the vehicle"),
                Year = InputHandler.GetYear(),
                //Color input should be implemented
            };
            return vehicle;
        }
    }
}