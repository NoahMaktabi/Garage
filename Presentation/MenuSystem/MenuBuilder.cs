using System;

namespace Presentation.MenuSystem
{
    public class MenuBuilder
    {
        private int _selectedIndex;
        private readonly string[] _options;
        private readonly string _prompt;

        public MenuBuilder(string prompt, string[] options)
        {
            _prompt = prompt;
            _options = options;
            _selectedIndex = 0;
        }


        /// <summary>
        /// Runs the menu with a specific design. 
        /// </summary>
        private void DisplayOptions()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine(_prompt + "\n");
            for (var i = 0; i < _options.Length; i++)
            {
                var currentOption = _options[i];
                string prefix;
                if (i == _selectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($" {prefix} << {currentOption} >>");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Responsible for presenting the menu and looping until the user presses enter on an option.
        /// The menu then returns the selected option as an int representing the selectedIndex of the options array. 
        /// </summary>
        /// <returns>int representing the selectedIndex of the options array.</returns>
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                Console.CursorVisible = false;
                DisplayOptions();

                var keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex--;
                    if (_selectedIndex == -1)
                    {
                        _selectedIndex = _options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if (_selectedIndex == _options.Length)
                    {
                        _selectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return _selectedIndex;
        }
    }
}