using System;
using BookMan.ConsoleApp.Framework;

namespace BookMan.ConsoleApp.Views
{
    using Models; // Using models
    
    /// <summary>
    /// View list of books
    /// </summary>
    internal class BookListView
    {
        protected Book[] books;

        /// <summary>
        /// Constructor list of books
        /// </summary>
        /// <param name="books">Book[] books</param>
        public BookListView(Book[] books)
        {
            this.books = books;
        }

        /// <summary>
        /// View list of book render method
        /// </summary>
        public void Render()
        {
            if (books.Length == 0)
            {
                ViewHelp.WriteLine("No book is found", ConsoleColor.Red);
            }
            else
            {
                ViewHelp.WriteLine("List of books");
                foreach (Book book in books)
                {
                    ViewHelp.WriteLine($"Id: {book.Id}, title: {book.Title}");
                }
            }
        }
    }
}