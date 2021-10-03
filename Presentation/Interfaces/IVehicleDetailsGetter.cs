using Domain.Vehicles;

namespace Presentation.Interfaces
{
    public interface IVehicleDetailsGetter
    {
        Motorcycle GetMcDetails();
        RecreationalVehicle GetRvDetails();
        Truck GetTruckDetails();
        Bus GetBusDetails();
        Car GetCarDetails();
    }
}