using System;

namespace Domain
{
    public class ParkingSpot
    {
        public Guid Id { get; set; }
        public bool IsAvailable { get; set; }
        public Vehicle ParkedVehicle { get; set; }
    }
}