using System.Collections.Generic;

namespace BookMan.ConsoleApp.DataServices
{
    using Models; // Using models
    
    /// <summary>
    /// Simple data class
    /// </summary>
    public class SimpleDataAccess
    {
        public List<Book> Books { get; set; }

        public void Load()
        {
            Books = new List<Book>
            {
                new Book {Id = 0, Title = "Book 0"},
                new Book {Id = 1, Title = "Book 1"},
                new Book {Id = 2, Title = "Book 2"},
                new Book {Id = 3, Title = "Book 3"},
                new Book {Id = 4, Title = "Book 4"},
                new Book {Id = 5, Title = "Book 5"}
            };
        }

        public void SaveChanges()
        {
            
        }
    }
}