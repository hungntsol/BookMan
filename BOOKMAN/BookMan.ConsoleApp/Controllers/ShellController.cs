using System.IO;
using System.Diagnostics;

namespace BookMan.ConsoleApp.Controllers
{
    using Models;
    using Framework;
    using Views;
    using DataServices;
    
    /// <summary>
    /// Shell class find book in folder
    /// </summary>
    public class ShellController : ControllerBase
    {
        protected Repository _repository;

        /// <summary>
        /// Constructor shell class
        /// </summary>
        /// <param name="context">SimpleDataAccess</param>
        public ShellController(IBookDataAccess context)
        {
            _repository = new Repository(context);
        }

        /// <summary>
        /// File all .pdf file in path and insert to context
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="ext"></param>
        public void Shell(string folder, string ext = ".pdf")
        {
            // Create new file if not exited
            if (!Directory.Exists(folder))
            {
                Error($"File not found");
                return;
            }

            // Get all files in directory
            var files = Directory.GetFiles(folder, ext ?? "*.pdf", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                // Insert each file to context
                _repository.Insert(new Book() {Title = Path.GetFileNameWithoutExtension(file), File = file});
            }

            if (files.Length > 0)
            {
                Success($"{files.Length} item(s) found");
                return;
            }
            Information("No item found", "Sorry");
        }

        /// <summary>
        /// Save data context in file
        /// </summary>
        public void Save()
        {
            _repository.SaveChanges();
            Success("Data saved");
        }

        /// <summary>
        /// Read file 
        /// </summary>
        /// <param name="id">Int</param>
        public void Read(int id)
        {
            var book = _repository.Select(id);
            if (book == null)
            {
                Error("Book is not existed");
                return;
            }

            if (!File.Exists(book.File))
            {
                Error($"This book has been moved or deleted");
                return;
            }

            Process.Start(book.File);
            string req = $"mark ? id = {book.Id} & reading = true";
            Router.Instance.Forward(req);
            Success($"Reading book {book.Title}");
        }
    }
}