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

        /// <summary>
        /// Write json data to file
        /// </summary>
        /// <param name="_path">string path</param>
        public void RenderToFile(string _path)
        {
            ViewHelp.WriteLine($"Saving data to: {_path}");
            var jsonData = JsonConvert.SerializeObject(books);
            File.WriteAllText(_path, jsonData);
            ViewHelp.WriteLine("Done");
        }
    }
}