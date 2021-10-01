namespace Domain.Vehicles
{
    public class Truck : Vehicle
    {
        public int Wheels { get; set; }
        public bool WithTrailer { get; set; }
        public bool CoolerTruck { get; set; }
        public double Height { get; set; }
    }
}