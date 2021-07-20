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
    internal class BookSingleView
    {
        protected readonly Book book;

        /// <summary>
        /// Constructor for BookSingleView class
        /// </summary>
        /// <param name="book">Book for displaying</param>
        public BookSingleView(Book book)
        {
            this.book = book;
        }

        /// <summary>
        /// View book information render method
        /// </summary>
        public void Render()
        {
            if (book == null) // Check book is null or not
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
                Console.WriteLine($"Authors:        {book.Authors}");
                Console.WriteLine($"Title:          {book.Title}");
                Console.WriteLine($"Publisher:      {book.Publisher}");
                Console.WriteLine($"Year:           {book.Year}");
                Console.WriteLine($"Edition:        {book.Edition}");
                Console.WriteLine($"Tags:           {book.Tags}");
                Console.WriteLine($"Description:    {book.Description}");
                Console.WriteLine($"Rating:         {book.Rating}");
                Console.WriteLine($"Reading:        {book.Reading}");
                Console.WriteLine($"File:           {book.File}");
                Console.WriteLine($"FileName:       {book.FileName}");
            }
        }
        
        /// <summary>
        /// Write json data to file
        /// </summary>
        /// <param name="_path">string path</param>
        public void RenderToFile(string _path)
        {
            ViewHelp.WriteLine($"Saving data to: {_path}");
            var jsonData = JsonConvert.SerializeObject(book);
            File.WriteAllText(_path, jsonData);
            ViewHelp.WriteLine("Done");
        }
    }
}