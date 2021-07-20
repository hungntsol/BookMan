using System.Collections.Generic;

namespace BookMan.ConsoleApp.DataServices
{
    using Models; // Using models
    
    /// <summary>
    /// Class repository
    /// </summary>
    public class Repository
    {
        private readonly SimpleDataAccess _context;

        public Repository(SimpleDataAccess context)
        {
            _context = context;
            _context.Load();
        }

        public void SaveChanges() => _context.SaveChanges();

        public List<Book> Books => _context.Books;

        public Book[] Select() => _context.Books.ToArray();

        public Book Select(int id)
        {
            foreach (var book in _context.Books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }

            return null;
        }

        public Book[] Select(string key)
        {
            var temp = new List<Book>();
            key = key.ToLower();
            foreach (var book in _context.Books)
            {
                var logic = book.Title.Contains(key) ||
                                book.Authors.Contains(key) ||
                                book.Description.Contains(key) ||
                                book.Publisher.Contains(key) ||
                                book.Tags.Contains(key);
                if (logic)
                {
                    temp.Add(book);
                }
            }

            return temp.ToArray();
        }

        public void Insert(Book book)
        {
            int lastIndex = _context.Books.Count - 1;
            var id = lastIndex < 0 ? 1 : lastIndex + 1;
            book.Id = id;
            _context.Books.Add(book);
        }

        public bool Delete(int id)
        {
            Book book = Select(id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            return true;
        }

        public bool Update(int id, Book _book)
        {
            Book book = Select(id);
            if (book == null) return false;
            book.Authors = _book.Authors;
            book.Title = _book.Title;
            book.Description = _book.Description;
            book.Publisher = _book.Publisher;
            book.Year = _book.Year;
            return true;
        }
    }
}