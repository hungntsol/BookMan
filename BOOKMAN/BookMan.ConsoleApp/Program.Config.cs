using System;
using System.Text;

namespace BookMan.ConsoleApp
{
    using Models;
    using Controllers;
    using Framework;
    using DataServices;
    
    internal partial class Program
    {
        private static void ConfigRouter()
        {
            SimpleDataAccess context = new SimpleDataAccess();
            BookController bookController = new BookController(context);
            ShellController shellController = new ShellController(context);
        
            Router r = Router.Instance;
        
            r.Register("about", About);
            r.Register("help", Help);
            
            // Update a book (id)
            r.Register("update", p => bookController.Update(Extension.ToInt(p["id"])));
            r.Register("do update", p => bookController.Update(Extension.ToInt(p["id"]), toBook(p)));
            
            // Create a book
            r.Register("create", p => bookController.Create());
            r.Register("do create", p => bookController.Create(toBook(p)));
            
            // View list books
            r.Register("list", p => bookController.ListView());
            r.Register("list file", p => bookController.ListView(p["path"]));
            
            // View single book (id)
            r.Register("single", p => bookController.Single(int.Parse(p["id"])));
            r.Register("single file", p => bookController.Single(int.Parse(p["id"]), p["path"]));
            
            // Delete a book (id)
            r.Register("delete", p => bookController.Delete(Extension.ToInt(p["id"])));
            r.Register("do delete", p => bookController.Delete(Extension.ToInt(p["id"]), true));
            
            r.Register("add shell", p => shellController.Shell(p["path"], p["ext"]));
            
            
            Models.Book toBook(Parameter p)
            {
                var b = new Models.Book();
                if (p.ConstainKey("id")) b.Id = Extension.ToInt(p["id"]);
                if (p.ConstainKey("title")) b.Title = p["title"];
                if (p.ConstainKey("authors")) b.Authors = p["authors"];
                if (p.ConstainKey("publisher")) b.Publisher = p["publisher"];
                if (p.ConstainKey("year")) b.Year = Extension.ToInt(p["year"]);
                if (p.ConstainKey("edition")) b.Edition = Extension.ToInt(p["edition"]);
                if (p.ConstainKey("description")) b.Description = p["description"];
                return b;
            }
        }
    }
}