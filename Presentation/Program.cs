using System;
using System.Collections.Generic;
using Domain;
using Domain.Vehicles;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var garage = new Garage<Vehicle>()
            {
                Vehicles = new List<Vehicle>()
                {
                    new Car {Id = 1, Make = "Volvo", Model = "S60", Year = 2010, CarType = "Sedan"},
                    new Car {Id = 2, Make = "Volvo", Model = "S90", Year = 2012, CarType = "Sedan"},
                    new Car {Id = 3, Make = "Volvo", Model = "S80", Year = 2014, CarType = "Sedan"},
                    new Car {Id = 4, Make = "Volvo", Model = "S40", Year = 2011, CarType = "Sedan"},
                }
            };
            foreach (var vehicle in garage)
            {
                Console.WriteLine(vehicle.Year);
            }
            
        }
    }
}
