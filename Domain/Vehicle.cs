using System.Drawing;

namespace Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Color Color { get; set; }
        public string LicensePlate { get; set; }
    }
}