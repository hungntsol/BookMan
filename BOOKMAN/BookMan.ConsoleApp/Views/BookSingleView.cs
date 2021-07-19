using System;
using BookMan.ConsoleApp.Framework;

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
    }
}