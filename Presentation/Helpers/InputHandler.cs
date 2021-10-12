using System;
using System.Drawing;
using Domain.Vehicles;

namespace Presentation.Helpers
{
    public static class InputHandler
    {
        public static int GetParkingCost()
        {
            Console.Clear();
            Console.CursorVisible = true;
            const string prompt = "What is the cost of parking per hour in your garage? Enter a positive number";
            var invalidMsg = $"Invalid input. Please enter a positive number between 1 - 200!";
            var costPerHour = GetIntFromUserInput(prompt, invalidMsg, 1, 200);
            Console.CursorVisible = false;
            return costPerHour;
        }

        public static int GetGarageCapital()
        {
            Console.Clear();
            Console.CursorVisible = true;
            const string prompt = "What is the garage's start capital? Enter a positive number";
            var invalidMsg = $"Invalid input. Please enter a positive number!";
            var capital = GetIntFromUserInput(prompt, invalidMsg, 0, 9999999);
            Console.CursorVisible = false;
            return capital;
        }

        public static int GetGarageCapacity(int existingVehiclesCount)
        {
            Console.Clear();
            Console.CursorVisible = true;
            var prompt = $"How many spots do you want your garage to have? \nYou already have {existingVehiclesCount} customers so the amount should be more.";
            var invalidMsg = $"Invalid input. Please enter a number higher than {existingVehiclesCount} as you already have so many vehicles ready to park";
            var year = GetIntFromUserInput(prompt, invalidMsg, existingVehiclesCount, 500);
            Console.CursorVisible = false;
            return year;
        }

        public static CarType GetCarType()
        {
            Console.Clear();
            Console.CursorVisible = true;
            const string prompt = @"Enter car's type. Enter a number representing the type of the car:
1- Sedan.
2- Wagon. 
3- Pickup.
4- Coupé.
5- Van.
";
            const string invalidMsg = "Invalid input. Please enter a number between 1 - 5.";
            var typeNumer = GetIntFromUserInput(prompt, invalidMsg, 1, 5);
            return typeNumer switch
            {
                1 => CarType.Sedan,
                2 => CarType.Wagon,
                3 => CarType.Pickup,
                4 => CarType.Coupé,
                5 => CarType.Van,
                _ => throw new NotImplementedException(),
            };
        }


        public static FuelType GetFuelType()
        {
            Console.Clear();
            Console.CursorVisible = true;
            const string prompt = @"Enter vehicle's fuel/energi type. Enter a number representing the fuel type of the vehicle:
1- Gas (Bensin).
2- Diesel. 
3- Electrical.
";
            const string invalidMsg = "Invalid input. Please enter a number between 1 - 3.";
            var typeNumer = GetIntFromUserInput(prompt, invalidMsg, 1, 3);
            return typeNumer switch
            {
                1 => FuelType.Bensin,
                2 => FuelType.Diesel,
                3 => FuelType.Electrical,
                _ => throw new NotImplementedException(),
            };
        }

        /// <summary>
        /// Asks the user to enter a number from a list to choose a color and returns the color.
        /// </summary>
        /// <returns>A color that the user chooses.</returns>
        public static Color GetColor()
        {
            Console.Clear();
            Console.CursorVisible = true;
            const string prompt = @"Enter vehicle's color. Enter a number representing the color of the vehicle:
1- White.
2- Black.
3- Red.
4- Yellow.
5- Blue.
6- Green.
7- Gray. 
";
            const string invalidMsg = "Invalid input. Please enter a number between 1 - 7.";
            var colorNumber = GetIntFromUserInput(prompt, invalidMsg, 1, 7);
            return colorNumber switch
            {
                1 => Color.White,
                2 => Color.Black,
                3 => Color.Red,
                4 => Color.Yellow,
                5 => Color.Blue,
                6 => Color.Green,
                7 => Color.Gray,
                _ => Color.White,
            };
        }

        public static int GetWheelsTotal()
        {
            Console.Clear();
            Console.CursorVisible = true;
            const string msg = "How many wheel does your vehicle have?";
            var invalidMsg = $"Invalid input. Please enter a number between 2 - 30";
            var year = GetIntFromUserInput(msg, invalidMsg, 2, 30);
            Console.CursorVisible = false;
            return year;
        }

        public static int GetYear()
        {
            Console.Clear();
            Console.CursorVisible = true;
            const string msg = "What year was the car manufactured?";
            var invalidMsg = $"Invalid input. Please enter a number between 1950 - {DateTime.Now.Year}";
            var year = GetIntFromUserInput(msg, invalidMsg, 1950, DateTime.Now.Year);
            Console.CursorVisible = false;
            return year;
        }
        public static double GetVehicleHeight()
        {
            Console.Clear();
            const string msg = "Please enter the height of the vehicle.";
            const string invalidMsg = "You did not enter a valid number. Please try again. Max height is 5 meters";
            Console.CursorVisible = true;
            var height = GetDoubleFromUserInput(msg, invalidMsg, 1, 5);
            Console.CursorVisible = false;
            return height;
        }

        /// <summary>
        /// Get boolean value from user by asking for Y or N input.
        /// You have to provide a msg to show the user, ex. Is your pet insured?
        /// </summary>
        /// <param name="message"></param>
        /// <param name="clearConsole"></param>
        /// <returns>Boolean value</returns>
        public static bool GetBoolValue(string message, bool clearConsole = true)
        {
            if (clearConsole)
                Console.Clear();

            message.ShowAnimatedText(2);
            "Please press Y or N for yes or no.".ShowAnimatedText(2);
            var keyPressed = Console.ReadKey(true);

            while ((keyPressed.Key != ConsoleKey.Y) && (keyPressed.Key != ConsoleKey.N))
            {
                message.ShowAnimatedText(2);
                "Please press Y or N for yes or no.".ShowAnimatedText(2);
                keyPressed = Console.ReadKey(true);
            }

            return keyPressed.Key == ConsoleKey.Y;
        }


        /// <summary>
        /// Print out the provided prompt to console and asks for a string
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns>string from console ReadLine</returns>
        public static string GetString(string prompt)
        {
            Console.Clear();
            prompt.ShowAnimatedText(5);
            Console.CursorVisible = true;
            var str = Console.ReadLine();
            Console.CursorVisible = false;
            return str;
        }

        /// <summary>
        /// Asks the user to provide a licensePlate. Checks the length of the plate.
        /// If its 6 characters long then its valid. Otherwise the user has to try again. 
        /// </summary>
        /// <returns>A string with a valid license plate.</returns>
        public static string GetLicensePlate()
        {
            Console.Clear();
            "Please enter a license plate for the vehicle.".ShowAnimatedText(5);
            Console.CursorVisible = true;
            var plate = Console.ReadLine();
            while (!IsValidLicensePlate(plate))
            {
                "Invalid license plate. Please enter a valid license plate. Ex: ABC123".ShowAnimatedText(2);
                plate = Console.ReadLine();
            }

            Console.CursorVisible = false;
            return plate?.ToUpper().Trim();
        }
        
        /// <summary>
        /// Asks the user to provide a vehicle model, make or year.
        /// </summary>
        /// <returns>Query string.</returns>
        public static string GetSearchQuery()
        {
            Console.Clear();
            "Please enter a model, make or year to search for.".ShowAnimatedText(5);
            Console.CursorVisible = true;
            var query = Console.ReadLine();
            Console.CursorVisible = false;
            
            return query;
        }

        private static bool IsValidLicensePlate(string licensePlate)
        {
            return licensePlate.Trim().Length == 6;
        }


        /// <summary>
        /// Writes msgToUser, then request input from user,
        /// then converts input into double,
        /// checks that double is between or equals min and max before returning.
        /// invalidMsg must be provided in case the user types wrong input
        /// </summary>
        /// <param name="msgToUser">Msg to write to user before asking for input. Ex: Type your age,</param>
        /// <param name="invalidMsg">Msg to provide in case the input is not a number or not inside the min/max param</param>
        /// <param name="min">Minimum number allowed</param>
        /// <param name="max">Maximum number allowed</param>
        /// <returns>Valid double from the criteria defined in the parameters</returns>
        public static double GetDoubleFromUserInput(string msgToUser, string invalidMsg, double min, double max)
        {
            Console.Clear();
            msgToUser.ShowAnimatedText(3);
            Console.CursorVisible = true;
            var input = Console.ReadLine();
            var success = double.TryParse(input, out var number);
            while (!success || !ValidDouble(number, min, max))
            {
                invalidMsg.ShowAnimatedText(3);
                input = Console.ReadLine();
                success = double.TryParse(input, out number);
            }
            Console.CursorVisible = false;
            return number;
        }

        private static bool ValidDouble(double number, double min, double max)
        {
            return number >= min && number <= max;
        }

        /// <summary>
        /// Writes msgToUser, then request input from user,
        /// then converts input into int,
        /// checks that int is between or equals min and max before returning.
        /// invalidMsg must be provided in case the user types wrong input
        /// </summary>
        /// <param name="msgToUser">Msg to write to user before asking for input. Ex: Type your age,</param>
        /// <param name="invalidMsg">Msg to provide in case the input is not a number or not inside the min/max param</param>
        /// <param name="min">Minimum number allowed</param>
        /// <param name="max">Maximum number allowed</param>
        /// <returns>Valid int from the criteria defined in the parameters</returns>
        public static int GetIntFromUserInput(string msgToUser, string invalidMsg, int min, int max)
        {
            Console.Clear();
            msgToUser.ShowAnimatedText(3);
            Console.CursorVisible = true;
            var input = Console.ReadLine();
            var success = int.TryParse(input, out var number);
            while (!success || !ValidInt(number, min, max))
            {
                invalidMsg.ShowAnimatedText(3);
                input = Console.ReadLine();
                success = int.TryParse(input, out number);
            }
            Console.CursorVisible = false;
            return number;
        }

        private static bool ValidInt(int number, int min, int max)
        {
            return number >= min && number <= max;
        }
    }
}