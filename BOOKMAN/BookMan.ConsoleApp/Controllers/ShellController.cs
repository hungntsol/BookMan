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
        public ShellController(SimpleDataAccess context)
        {
            _repository = new Repository(context);
        }

        public void Shell(string folder, string ext = ".pdf")
        {
            if (!Directory.Exists(folder))
            {
                Error($"File not found");
                return;
            }

            var files = Directory.GetFiles(folder, ext ?? "*.pdf", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                _repository.Insert(new Book() {Title = Path.GetFileNameWithoutExtension(file), File = file});
            }

            if (files.Length > 0)
            {
                Success($"{files.Length} item(s) found");
                return;
            }
            Information("No item found", "Sorry");
        }
    }
}