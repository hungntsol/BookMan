using System;
using System.Collections.Generic;
using System.Text;
using BookMan.ConsoleApp.Controllers;
using BookMan.ConsoleApp.DataServices;
using BookMan.ConsoleApp.Framework;

namespace BookMan.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var context = new SimpleDataAccess();
            BookController bookController = new BookController(context);
            
            Router r = Router.Instance;
            
            r.Register("about", About);
            r.Register("help", Help);
            r.Register("update", p => bookController.Update(int.Parse(p["id"])));
            r.Register("create", p => bookController.Create());
            r.Register("list", p => bookController.ListView());
            r.Register("list file", p => bookController.ListView(p["path"]));
            r.Register("single", p => bookController.Single(int.Parse(p["id"])));
            r.Register("single file", p => bookController.Single(int.Parse(p["id"]), p["path"]));
            
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