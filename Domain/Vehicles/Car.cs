namespace Domain.Vehicles
{
    public class Car : Vehicle
    {
        public CarType Type { get; set; }
    }

    public enum CarType
    {
        Sedan,
        Wagon,
        Pickup,
        Coupé,
        Van,
    }
}