using System;
using System.IO;
using BookMan.ConsoleApp.Framework;
using Newtonsoft.Json;

namespace BookMan.ConsoleApp.Views
{
    using Models;
    
    /// <summary>
    /// View information of a book(internal)
    /// </summary>
    internal class BookSingleView : ViewBase
    {
        /// <summary>
        /// Constructor for BookSingleView class
        /// </summary>
        /// <param name="book">Book</param>
        public BookSingleView(Book book) : base(book) { }

        /// <summary>
        /// View book information render method
        /// </summary>
        public void Render()
        {
            if (model == null) // Check book is null or not
            { 
                ViewHelp.WriteLine("This book is not existed !", ConsoleColor.Red);
                return;
            }
            else
            {
                ViewHelp.WriteLine("Book information", ConsoleColor.Green);
                /*
                 * Print book information to console 
                 */
                var model = base.model as Book;
                Console.WriteLine($"Authors:        {model.Authors}");
                Console.WriteLine($"Title:          {model.Title}");
                Console.WriteLine($"Publisher:      {model.Publisher}");
                Console.WriteLine($"Year:           {model.Year}");
                Console.WriteLine($"Edition:        {model.Edition}");
                Console.WriteLine($"Tags:           {model.Tags}");
                Console.WriteLine($"Description:    {model.Description}");
                Console.WriteLine($"Rating:         {model.Rating}");
                Console.WriteLine($"Reading:        {model.Reading}");
                Console.WriteLine($"File:           {model.File}");
                Console.WriteLine($"FileName:       {model.FileName}");
            }
        }
    }
}