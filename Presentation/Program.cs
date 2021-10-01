using System;
using System.Collections.Generic;
using System.Drawing;
using Domain;
using Domain.Vehicles;

namespace Presentation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var garage = new Garage<Vehicle>()
            {
                Vehicles = new List<Vehicle>()
                {
                    new Car { Make = "Volvo", Model = "S60", Year = 2010, Type = CarType.Sedan, Color = Color.Blue},
                    new Car {Make = "Volvo", Model = "S90", Year = 2012, Type = CarType.Sedan},
                    new Car { Make = "Volvo", Model = "S80", Year = 2014, Type = CarType.Sedan},
                    new Car {Make = "Volvo", Model = "S40", Year = 2011, Type = CarType.Sedan},
                }
            };
            foreach (var vehicle in garage)
            {
                Console.WriteLine(vehicle.Year);
                
            }

            foreach (var vehicle in garage)
            {
                
            }


        }


    }
}
