using System;
using System.Text;
using BookMan.ConsoleApp.Framework;

namespace BookMan.ConsoleApp
{
    internal partial class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var text = Config.Instance.PrompText;
            var color = Config.Instance.PrompColor;
            
            ConfigRouter();

            var isBreak = false;
            while (!isBreak)
            {
                Console.Write($"{text} ", color);
                var request = Console.ReadLine();

                try
                {
                    Router.Instance.Forward(request);
                }
                catch (Exception e)
                {
                    ViewHelp.WriteLine(e.Message, ConsoleColor.Red);
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }

        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("Book manager", ConsoleColor.Green);
        }

        private static void Help(Parameter parameter)
        {
            if (parameter == null)
            {
                ViewHelp.WriteLine("Supported command", ConsoleColor.Green);
                ViewHelp.WriteLine(Router.Instance.GetRoutes(), ConsoleColor.Yellow);
                ViewHelp.WriteLine("Type help ? cmd=<command> to get more detail", ConsoleColor.Cyan);
                return;
            }

            var command = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(command));
        }
    }
}