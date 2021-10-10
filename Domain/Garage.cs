using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public int Capacity { get; set; }
        public List<T> Vehicles { get; set; }
        public List<ParkingSpot> ParkingSpots { get; set; }
        public decimal Capital { get; set; }
        
        
        public IEnumerator<T> GetEnumerator()
        {
            return Vehicles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Vehicles.GetEnumerator();
        }
    }
}