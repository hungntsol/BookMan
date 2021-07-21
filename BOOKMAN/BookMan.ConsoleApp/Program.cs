using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BookMan.ConsoleApp.Controllers;
using BookMan.ConsoleApp.DataServices;
using BookMan.ConsoleApp.Framework;

namespace BookMan.ConsoleApp
{
    internal partial class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            ConfigRouter();
            
            bool isBreak = false;
            while (!isBreak)
            {
                Console.Write("Request > ");
                string request = Console.ReadLine();

                Router.Instance.Forward(request);
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
                ViewHelp.WriteLine("Type help ? cmd=<commad> to get more detail", ConsoleColor.Cyan);
                return;
            }
            
            var command = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(command));
        }
    }
}