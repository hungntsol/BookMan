using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace BookMan.ConsoleApp.DataServices
{
    using Models; // Using models
    
    /// <summary>
    /// Class repository
    /// </summary>
    public class Repository
    {
        private readonly IBookDataAccess _context;

        /// <summary>
        /// Contructor initial context
        /// </summary>
        /// <param name="context">IBookDataAccess</param>
        public Repository(IBookDataAccess context)
        {
            _context = context;
            _context.Load();
        }

        /// <summary>
        /// Save data of books
        /// </summary>
        public void SaveChanges() => _context.SaveChanges();

        /// <summary>
        /// Getter books
        /// </summary>
        public List<Book> Books => _context.Books;

        /// <summary>
        /// Get book[] from data service
        /// </summary>
        /// <returns>Book[]</returns>
        public Book[] Select() => _context.Books.ToArray();

        /// <summary>
        /// Select book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book Select(int id)
        {
            return _context.Books.FirstOrDefault(book => book.Id == id);
        }

        /// <summary>
        /// Select books by key (search)
        /// </summary>
        /// <param name="key">string</param>
        /// <returns>Book[]</returns>
        public Book[] Select(string key)
        {
            key = key.ToLower();
            return _context.Books.Where(book => book.Title.Contains(key) ||
                                                book.Authors.Contains(key) ||
                                                book.Description.Contains(key) ||
                                                book.Publisher.Contains(key) ||
                                                book.Tags.Contains(key)).ToArray();
        }

        /// <summary>
        /// Select books are reading
        /// </summary>
        /// <returns>Book[]</returns>
        public Book[] SelectReading()
        {
            return _context.Books.Where(book => book.Reading == true).ToArray();
        }

        /// <summary>
        /// Group books by folder
        /// </summary>
        /// <param name="key">string</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<IGrouping<string, Book>> Stats(string key = "folder")
        {
            return _context.Books.GroupBy(book => Path.GetDirectoryName(book.File));
        }

        /// <summary>
        /// Insert book to context
        /// </summary>
        /// <param name="book">Book</param>
        public void Insert(Book book)
        {
            int id = _context.Books.Count == 0 ? 1 : _context.Books.Max(b => b.Id) + 1;
            book.Id = id;
            _context.Books.Add(book);
        }

        /// <summary>
        /// Delete book by id
        /// </summary>
        /// <param name="id">Int</param>
        /// <returns>Bool</returns>
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

        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="id">Int</param>
        /// <param name="_book">Book</param>
        /// <returns>Bool</returns>
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