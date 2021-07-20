using System;
using System.IO;
using BookMan.ConsoleApp.Framework;
using Newtonsoft.Json;

namespace BookMan.ConsoleApp.Views
{
    using Models; // Using models
    
    /// <summary>
    /// View list of books
    /// </summary>
    internal class BookListView : ViewBase
    {

        /// <summary>
        /// Constructor list of books
        /// </summary>
        /// <param name="books">Book[] books</param>
        public BookListView(Book[] books) : base(books)
        {
        }

        /// <summary>
        /// View list of book render method
        /// </summary>
        public void Render()
        {
            if (((Book[]) model).Length == 0)
            {
                ViewHelp.WriteLine("No book is found", ConsoleColor.Red);
            }
            else
            {
                ViewHelp.WriteLine("List of books");
                foreach (Book book in model as Book[])
                {
                    ViewHelp.WriteLine($"Id: {book.Id}, title: {book.Title}");
                }
            }
        }
        
    }
}