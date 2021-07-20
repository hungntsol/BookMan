using BookMan.ConsoleApp.DataServices;

namespace BookMan.ConsoleApp.Controllers
{
    using Models; // Using class in models
    using Views; // Using class in views
    
    /// <summary>
    /// Class book controller, get data from model and init view (internal)
    /// </summary>
    internal class BookController
    {
        protected Repository _repository;

        public BookController(SimpleDataAccess context)
        {
            _repository = new Repository(context);
        }

        public void Single(int id, string _path = "")
        {
            var book = _repository.Select(id);
            
            // init book view
            BookSingleView bookSingleView = new BookSingleView(book);
            // render book view
            bookSingleView.Render();
            
            if (!string.IsNullOrEmpty(_path)) bookSingleView.RenderToFile(_path);
        }

        /// <summary>
        /// Create a new book
        /// </summary>
        public void Create()
        {
            BookCreateView createView = new BookCreateView();
            createView.Render();
        }

        /// <summary>
        /// Update book information
        /// </summary>
        public void Update(int id)
        {
            var book = _repository.Select(id);
            BookUpdateView updateView = new BookUpdateView(book);
            updateView.Render();
        }

        /// <summary>
        /// View list of books
        /// </summary>
        public void ListView(string _path = "")
        {
            var books = _repository.Select();
            BookListView bookListView = new BookListView(books);
            bookListView.Render();

            if (!string.IsNullOrEmpty(_path)) bookListView.RenderToFile(_path);
        }
    }
}