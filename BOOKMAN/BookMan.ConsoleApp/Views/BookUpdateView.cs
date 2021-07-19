using System;
using  BookMan.ConsoleApp.Framework;

namespace BookMan.ConsoleApp.Views
{
    using Models; // Using model class
    
    /// <summary>
    /// View update book
    /// </summary>
    public class BookUpdateView
    {
        protected Book book = new Book();

        /// <summary>
        /// Constructor init update book view
        /// </summary>
        /// <param name="book">Book book</param>
        public BookUpdateView(Book book)
        {
            this.book = book;
        }

        /// <summary>
        /// Update book render method
        /// </summary>
        public void Render()
        {
            ViewHelp.Write("Update book information", ConsoleColor.Green);
            Console.WriteLine();

            string authors = ViewHelp.InputString($"Authors: ", book.Authors);
            
            string title = ViewHelp.InputString("Title: ", book.Title);
            
            string publisher = ViewHelp.InputString(("Publisher: "), book.Publisher);
            
            int year = ViewHelp.InputInt("Year: ", book.Year);

            string description = ViewHelp.InputString($"Description: ", book.Description);
        }
    }
}