using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    
    /// <summary>
    /// Class access data in binary format
    /// </summary>
    public class BinaryDataAccess : IBookDataAccess
    {
        public List<Book> Books { get; set; } = new List<Book>();
        private readonly string _file = "data.dat";

        /// <summary>
        /// Method load data
        /// </summary>
        public void Load()
        {
            if (!File.Exists(_file))
            {
                SaveChanges();
                return;
            }

            using (FileStream stream = File.OpenRead(_file))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Books = formatter.Deserialize(stream) as List<Book>;
            }
        }
        
        /// <summary>
        /// Method save chang data in file
        /// </summary>
        public void SaveChanges()
        {
            using (FileStream stream = File.OpenWrite(_file))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Books);
            }
        }
    }
}