using System.Collections.Generic;
using System.IO;
using BookMan.ConsoleApp.Models;
using Newtonsoft.Json;

namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    
    /// <summary>
    /// Class access data in json format
    /// </summary>
    public class JsonDataAccess : IBookDataAccess
    {
        public List<Book> Books { get; set; } = new List<Book>();
        private readonly string _file = Config.Instance.DataFile;

        public void Load()
        {
            if (!File.Exists(_file))
            {
                SaveChanges();
                return;
            }

            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader reader = new StreamReader(_file))
            using (JsonReader jsonReader = new JsonTextReader(reader))
            {
                Books = serializer.Deserialize<List<Book>>(jsonReader);
            }
        }

        public void SaveChanges()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter writer = new StreamWriter(_file))
            using (JsonWriter jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, Books);
            }
        }
    }
}