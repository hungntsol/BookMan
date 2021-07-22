using System;

namespace BookMan.ConsoleApp.Models
{
    /// <summary>
    ///  Describe book class
    /// </summary>
    [Serializable]
    public class Book
    {
        private int _id;
        private string _authors = "Unknown author";
        private string _title = "Unknown title";
        private string _publisher = "Unknown publisher";
        private int _year = thisYear;
        private int _edition;
        private string _file;

        private static readonly int thisYear = DateTime.Now.Year;
        
        /// <summary>
        /// Description for book
        /// </summary>
        public string Description { get; set; } = "A new book";

        /// <summary>
        /// Global ISBN
        /// </summary>
        /// 
        public string Isbn { get; set; } = "";

        /// <summary>
        /// Tags for search
        /// </summary>
        public string Tags { get; set; } = "";

        /// <summary>
        /// Check book is reading
        /// </summary>
        public bool Reading { get; set; } = false;
        
        /// <summary>
        /// Rating for book
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Getter and setter for book id (unique)
        /// </summary>
        public int Id
        {
            get => _id;
            set
            {
                if (value >= 0)
                {
                    _id = value;
                }
            }
        }

        /// <summary>
        /// Getter and setter authors of book, value is not empty
        /// </summary>
        public string Authors
        {
            get => _authors;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _authors = value;
                }
            }
        }

        /// <summary>
        /// Getter and setter title of books, value is not empty
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _title = value;
                }
            }
        }

        /// <summary>
        /// Getter and setter publisher of books, value is not empty
        /// </summary>
        public string Publisher
        {
            get => _publisher;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _publisher = value;
                }
            }
        }

        /// <summary>
        /// Getter and setter publish year of book, must be > 1950
        /// </summary>
        public int Year
        {
            get => _year;
            set
            {
                if (value > 1950 && value < thisYear)
                {
                    _year = value;
                }
            }
        }

        /// <summary>
        /// Getter and setter number of edition, value must > 1
        /// </summary>
        public int Edition
        {
            get => _edition;
            set
            {
                if (value >= 1)
                {
                    _edition = value;
                }
            }
        }

        /// <summary>
        /// Getter and setter book file (path)
        /// </summary>
        public string File
        {
            get => _file;
            set
            {
                if (System.IO.File.Exists(value))
                {
                    _file = value;
                }
            }
        }

        /// <summary>
        /// Getter book file (not path)
        /// </summary>
        public string FileName => System.IO.Path.GetFileName(_file);
    }
}