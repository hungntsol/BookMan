using System.Collections.Generic;
using BookMan.ConsoleApp.Models;

namespace BookMan.ConsoleApp.DataServices
{
    public interface IBookDataAccess
    {
        List<Book> Books { get; set; }
        void Load();
        void SaveChanges();
    }
}