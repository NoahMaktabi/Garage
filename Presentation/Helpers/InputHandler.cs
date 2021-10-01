using System;

namespace Presentation.Helpers
{
    public static class InputHandler
    {
        


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