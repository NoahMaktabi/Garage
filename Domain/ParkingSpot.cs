
namespace Domain
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public Vehicle ParkedVehicle { get; set; }
    }
}