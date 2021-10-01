using System;
using System.Threading;

namespace Presentation.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Shows the given text in an animated form in console.
        /// </summary>
        /// <param name="text">The text to be animated in console</param>
        /// <param name="animationInMs">How much time in milliseconds between each letter</param>
        public static void ShowAnimatedText(this string text, int animationInMs = 30)
        {
            foreach (var letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(animationInMs);
            }
            Console.WriteLine();
        }
    }
}