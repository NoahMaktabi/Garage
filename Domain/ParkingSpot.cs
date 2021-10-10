
namespace Domain
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public Vehicle ParkedVehicle { get; set; }
        public ParkingMeter ParkingMeter { get; set; } = new ParkingMeter();
        public decimal CostPerHour { get; set; }
    }
}