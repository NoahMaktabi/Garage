using System.Collections.Generic;

namespace Domain
{
    public class Garage
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public int ParkingSpaces { get; set; }
    }
}