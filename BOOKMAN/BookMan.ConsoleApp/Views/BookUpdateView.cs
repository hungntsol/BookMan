using System;
using  BookMan.ConsoleApp.Framework;

namespace BookMan.ConsoleApp.Views
{
    using Models; // Using model class
    
    /// <summary>
    /// View update book
    /// </summary>
    internal class BookUpdateView : ViewBase<Book>
    {
        /// <summary>
        /// Constructor init update book view
        /// </summary>
        /// <param name="book">Book book</param>
        public BookUpdateView(Book model) : base(model) { }

        /// <summary>
        /// Update book render method
        /// </summary>
        public override void Render()
        {
            var model = base.model as Book;
            
            if (model == null)
            {
                ViewHelp.WriteLine("Can not find this book", ConsoleColor.Red);
                return;
            }

            ViewHelp.Write("Update book information", ConsoleColor.Green);
            Console.WriteLine();

            string authors = ViewHelp.InputString($"Authors: ", model.Authors);
            string title = ViewHelp.InputString("Title: ", model.Title);
            string publisher = ViewHelp.InputString(("Publisher: "), model.Publisher);
            int year = ViewHelp.InputInt("Year: ", model.Year);
            string description = ViewHelp.InputString($"Description: ", model.Description);

            var req = "do update ? " +
                      $"id = {model.Id} & title = {title} & authors = {authors} & publisher = {publisher} & year = {year} & description = {description}";
            _router.Forward(req);
        }
    }
}