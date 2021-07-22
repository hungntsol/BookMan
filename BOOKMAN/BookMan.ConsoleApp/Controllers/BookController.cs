using BookMan.ConsoleApp.DataServices;
using BookMan.ConsoleApp.Framework;

namespace BookMan.ConsoleApp.Controllers
{
    using Models; // Using class in models
    using Views; // Using class in views
    
    /// <summary>
    /// Class book controller, get data from model and init view (internal)
    /// </summary>
    internal class BookController : ControllerBase
    {
        protected Repository _repository;

        public BookController(IBookDataAccess context)
        {
            _repository = new Repository(context);
        }

        public void Single(int id, string path = "")
        {
            var model = _repository.Select(id);
            Render(new BookSingleView(model), path);
        }

        /// <summary>
        /// Create a new book
        /// </summary>
        public void Create(Book model = null)
        {
            if (model == null)
            {
                Render(new BookCreateView());
                return;
            }

            _repository.Insert(model);
            Success("Book created");
        }

        /// <summary>
        /// Update book information
        /// </summary>
        public void Update(int id, Book book = null)
        {
            if (book == null)
            {
                var model = _repository.Select(id);
                Render(new BookUpdateView(model));
                return;
            }

            _repository.Update(id, book);
            Success("Update success");
        }

        /// <summary>
        /// View list of books
        /// </summary>
        public void ListView(string path = "")
        {
            var models = _repository.Select();
            Render(new BookListView(models), path);
        }

        public void MarkBookReading(int id, bool reading = false)
        {
            var model = _repository.Select(id);
            if (model == null)
            {
                Error($"Book not found");
                return;
            }

            model.Reading = reading;
            Success($"The book {model.Title} is marked as {(reading ? "reading" : "unread")}");
        }

        /// <summary>
        /// View list of books are in reading mode
        /// </summary>
        public void ListViewReading()
        {
            var models = _repository.SelectReading();
            Render(new BookListView(models));
        }

        public void ListStats()
        {
            var models = _repository.Stats();
            Render(new BookStatsView(models));
        }

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="id">Int</param>
        /// <param name="process">Bool</param>
        public void Delete(int id, bool process = false)
        {
            if (process == false)
            {
                var model = _repository.Select(id);
                Configuration($"Do you want to delete book: {model.Title} [Y] = yes\n", $"do delete ? id = {model.Id}");
            }
            else
            {
                _repository.Delete(id);
                Success("Delete book success");
            }
        }
    }
}