using Domain;
using Domain.Vehicles;
using Presentation.Interfaces;

namespace Presentation.Helpers
{
    public class VehicleDetailsGetter : IVehicleDetailsGetter
    {

        public Motorcycle GetMcDetails()
        {
            var vehicle = GetVehicleDetails();
            var mc = ConvertToMotorcycle(vehicle);
            mc.HasAlarmSystem = InputHandler.GetBoolValue("Does the mc have an alarm system?");
            mc.Type = InputHandler.GetString("What is the type of the mc? Harley, Cross, etc...");
            return mc;
        }

        public RecreationalVehicle GetRvDetails()
        {
            var vehicle = GetVehicleDetails();
            var rv = ConvertToRv(vehicle);
            rv.Height = InputHandler.GetVehicleHeight();
            rv.Wheels = InputHandler.GetWheelsTotal();
            return rv;
        }

        public Truck GetTruckDetails()
        {
            var vehicle = GetVehicleDetails();
            var truck = ConvertToTruck(vehicle);
            truck.Height = InputHandler.GetVehicleHeight();
            truck.CoolerTruck = InputHandler.GetBoolValue("Is the truck a cooler truck?");
            truck.WithTrailer = InputHandler.GetBoolValue("Does the truck have a trailer?");
            truck.Wheels = InputHandler.GetWheelsTotal();
            return truck;
        }
        public Bus GetBusDetails()
        {
            var vehicle = GetVehicleDetails();
            var bus = ConvertToBus(vehicle);
            bus.Height = InputHandler.GetVehicleHeight();
            bus.FuelType = InputHandler.GetFuelType();
            return bus;
        }
        public Car GetCarDetails()
        {
            var vehicle = GetVehicleDetails();
            var car = ConvertToCar(vehicle);
            car.FuelType = InputHandler.GetFuelType();
            car.Type = InputHandler.GetCarType();
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
                Color = InputHandler.GetColor(),
            };
            return vehicle;
        }

        private static Car ConvertToCar(Vehicle vehicle)
        {
            var car = new Car
            {
                LicensePlate = vehicle.LicensePlate,
                Color = vehicle.Color,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
            };
            return car;
        }

        private static Bus ConvertToBus(Vehicle vehicle)
        {
            var bus = new Bus
            {
                LicensePlate = vehicle.LicensePlate,
                Color = vehicle.Color,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
            };
            return bus;
        }

        private static Truck ConvertToTruck(Vehicle vehicle)
        {
            var truck = new Truck
            {
                LicensePlate = vehicle.LicensePlate,
                Color = vehicle.Color,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
            };
            return truck;
        }

        private static Motorcycle ConvertToMotorcycle(Vehicle vehicle)
        {
            var mc = new Motorcycle
            {
                LicensePlate = vehicle.LicensePlate,
                Color = vehicle.Color,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
            };
            return mc;
        }

        private static RecreationalVehicle ConvertToRv(Vehicle vehicle)
        {
            var rv = new RecreationalVehicle
            {
                LicensePlate = vehicle.LicensePlate,
                Color = vehicle.Color,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
            };
            return rv;
        }
    }
}