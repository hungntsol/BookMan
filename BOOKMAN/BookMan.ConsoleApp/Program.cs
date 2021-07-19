using System;
using BookMan.ConsoleApp.Controllers;

namespace BookMan.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BookController bookController = new BookController();
            bool isBreak = false;
            while (!isBreak)
            {
                Console.Write("Request > ");
                string request = Console.ReadLine();

                switch (request.ToLower())
                {
                    case "single":
                        bookController.Single(1);
                        break;
                    case "create":
                        bookController.Create();
                        break;
                    case "update":
                        bookController.Update();
                        break;
                    default:
                        Console.WriteLine("Unknown request");
                        isBreak = true;
                        break;
                }
            } 
        }
    }
}