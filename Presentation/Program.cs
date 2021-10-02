using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Domain;
using Domain.Vehicles;
using Newtonsoft.Json;
using Persistence;

namespace Presentation
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var garage = new Garage<Vehicle>()
            {
                Vehicles = new List<Vehicle>()
                {
                    new Car { Make = "Volvo", Model = "S60", Year = 2010, Type = CarType.Sedan, Color = Color.Blue, FuelType = FuelType.Bensin, LicensePlate = "ABC123"},
                    new Car {Make = "Volvo", Model = "C90", Year = 2012, Type = CarType.Coupé, Color = Color.Wheat, FuelType = FuelType.Bensin, LicensePlate = "ADD123"},
                    new Car { Make = "Volvo", Model = "D80", Year = 2014, Type = CarType.Pickup, Color = Color.Black, FuelType = FuelType.Bensin, LicensePlate = "AYT123"},
                    new Car {Make = "Volvo", Model = "V40", Year = 2011, Type = CarType.Wagon, Color = Color.White, FuelType = FuelType.Bensin, LicensePlate = "AKJ123"},
                    new Truck {Make = "Scania", Model = "Monster", Year = 2011, Color = Color.Aqua, Height = 3.44, LicensePlate = "TRK233", CoolerTruck = true, Wheels = 8, WithTrailer = false},
                    new Truck {Make = "Scania", Model = "Monster", Year = 2006, Color = Color.Yellow, Height = 3.84, LicensePlate = "TRK232", CoolerTruck = true, Wheels = 8, WithTrailer = false},
                    new Truck {Make = "Scania", Model = "Monster", Year = 2015, Color = Color.Black, Height = 2.84, LicensePlate = "TRK234", CoolerTruck = true, Wheels = 8, WithTrailer = false},
                    new Bus {Make = "Volvo", Model = "B40", Year = 2016, LicensePlate = "BUS123", Color = Color.Azure, Height = 2.45, FuelType = FuelType.Diesel},
                    new Bus {Make = "Volvo", Model = "B40", Year = 2018, LicensePlate = "BUS133", Color = Color.Azure, Height = 2.45, FuelType = FuelType.Diesel},
                    new Bus {Make = "Volvo", Model = "B40", Year = 2019, LicensePlate = "BUS143", Color = Color.Azure, Height = 2.45, FuelType = FuelType.Diesel},
                    new Motorcycle {Make = "Yamaha", Model = "MC12", Year = 2019, LicensePlate = "MCC111", Color = Color.Azure, HasAlarmSystem = true, Type = "Race"},
                    new Motorcycle {Make = "Suzuki", Model = "MC15", Year = 2020, LicensePlate = "MCC124", Color = Color.Azure, HasAlarmSystem = true, Type = "Race"},
                    new Motorcycle {Make = "BMW", Model = "MC16", Year = 2009, LicensePlate = "MCC952", Color = Color.Azure, HasAlarmSystem = true, Type = "Race"},
                    new RecreationalVehicle {Make = "BMW", Model = "RV11", Year = 2009, LicensePlate = "RVV445", Color = Color.Azure, Height = 3, Wheels = 6},
                    new RecreationalVehicle {Make = "Seat", Model = "RV51", Year = 2011, LicensePlate = "RVV645", Color = Color.Azure, Height = 3, Wheels = 6},
                    new RecreationalVehicle {Make = "Kia", Model = "RV41", Year = 2016, LicensePlate = "RVV754", Color = Color.Azure, Height = 3, Wheels = 6},
                }
            };
            foreach (var vehicle in garage)
            {
                //Console.WriteLine(vehicle.GetType().Name);
                var vType = VehicleType.Car;
                switch (vehicle)
                {
                    case Car:
                        vType = VehicleType.Car;
                        break;
                    case Truck:
                        vType = VehicleType.Truck;
                        break;
                    case Bus:
                        vType = VehicleType.Bus;
                        break;
                    case Motorcycle:
                        vType = VehicleType.Mc;
                        break;
                    case RecreationalVehicle:
                        vType = VehicleType.Rv;
                        break;
                }

                await DataHandler.AddToParkedVehicles(vehicle, vType);
            }

            //var cars = await DataHandler.GetParkedVehicles<Car>(VehicleType.Car);
            //cars.ForEach(c =>
            //{
            //    Console.WriteLine(c.LicensePlate);
            //});
            //Console.WriteLine();

        }


    }
}
