namespace BookMan.ConsoleApp.Controllers
{
    using Models; // Using class in models
    using Views; // Using class in views
    
    /// <summary>
    /// Class book controller, get data from model and init view (internal)
    /// </summary>
    internal class BookController
    {
        public void Single(int id)
        {
            Book book = new Book()
            {
                Id = 1,
                Authors = "JK. Rowling",
                Title = "Harry Potter",
                Publisher = "Van hoa",
                Year = 2001,
                Tags = "novel, harry potter",
                Description = "Story abour harry potter",
                Rating = 5,
                Reading = false,
            };
            // init book view
            BookSingleView bookSingleView = new BookSingleView(book);
            // render book view
            bookSingleView.Render();
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
        public void Update()
        {
            Book book = new Book();
            BookUpdateView updateView = new BookUpdateView(book);
            updateView.Render();
        }
    }
}