using System;

namespace BookMan.ConsoleApp.Framework
{
    public class ViewHelp
    {
        /// <summary>
        /// Console.WriteLine() with color
        /// </summary>
        /// <param name="message">string message</param>
        /// <param name="color">ConsoleColor color</param>
        /// <param name="reset">bool reset color</param>
        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool reset = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (reset)
            {
                Console.ResetColor();
            }
        }
        
        /// <summary>
        /// Console.Write() with color
        /// </summary>
        /// <param name="message">string message</param>
        /// <param name="color">ConsoleColor color</param>
        /// <param name="reset">bool reset</param>
        public static void Write(string message, ConsoleColor color = ConsoleColor.White, bool reset = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (reset)
            {
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Read string from console
        /// </summary>
        /// <param name="label">string label</param>
        /// <param name="color">ConsoleColor color</param>
        /// <returns>string value</returns>
        public static string InputString(string label, ConsoleColor color = ConsoleColor.White)
        {
            Write(label);
            string value = Console.ReadLine();
            return value;
        }

        /// <summary>
        /// Read string from console (overloading with old value)
        /// </summary>
        /// <param name="label">string label</param>
        /// <param name="oldValue">string currentValue</param>
        /// <param name="color">ConsoleColor color</param>
        /// <returns>string value</returns>
        public static string InputString(string label, string oldValue, ConsoleColor color = ConsoleColor.White)
        {
            WriteLine($"{label}: {oldValue}");
            Write($"New {label}: ");
            string value = Console.ReadLine();
            return value;
        }

        /// <summary>
        /// Read Int32 number from console
        /// </summary>
        /// <param name="label">string label</param>
        /// <param name="color">ConsoleColor color</param>
        /// <returns>Int32 value</returns>
        public static int InputInt(string label, ConsoleColor color = ConsoleColor.White)
        {
            while (true)
            {
                string str = InputString(label);
                bool isSuccess = int.TryParse(str, out int value);
                if (isSuccess)
                {
                    return value;
                }
            }
        }

        /// <summary>
        /// Read Int32 number from console
        /// </summary>
        /// <param name="label">string label</param>
        /// <param name="oldValue">string currentValue</param>
        /// <param name="color">ConsoleColor color</param>
        /// <returns>Int32 value</returns>
        public static int InputInt(string label, int oldValue, ConsoleColor color = ConsoleColor.White)
        {
            while (true)
            {
                string str = InputString(label, $"{oldValue}");
                bool isSuccess = int.TryParse(str, out int value);
                if (isSuccess)
                {
                    return value;
                }
            }
        }

        /// <summary>
        /// Read bool from console
        /// </summary>
        /// <param name="label">string label</param>
        /// <param name="color">ConsoleColor color</param>
        /// <returns>bool value</returns>
        public static bool InputBool(string label, ConsoleColor color = ConsoleColor.White)
        {
            Write($"{label} [y/n]", ConsoleColor.Green);
            ConsoleKeyInfo readingChar = Console.ReadKey();
            bool @reading = readingChar.KeyChar == 'y' || readingChar.KeyChar == 'Y' ? true : false;
            return @reading;
        }
    }
}