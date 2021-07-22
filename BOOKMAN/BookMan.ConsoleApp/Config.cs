using System;
using BookMan.ConsoleApp.DataServices;
using BookMan.ConsoleApp.Properties;

namespace BookMan.ConsoleApp
{
    /// <summary>
    /// Class config project
    /// </summary>
    internal class Config
    {
        private static Config _instance;
        public static Config Instance = _instance ?? (_instance = new Config());
        
        private Config() { }
        
        private Properties.Settings _settings = Settings.Default;
        public void Reload() => _settings.Reload();

        /// <summary>
        /// Constructor DataAccess type
        /// </summary>
        public IBookDataAccess BookDataAccess
        {
            get
            {
                var da = _settings.DataAccess;
                switch (da.ToLower())
                {
                    case "json": return new JsonDataAccess();
                    case "binary" : return new BinaryDataAccess();
                    default: return new JsonDataAccess();
                }
            }
        }

        public string DataAccess
        {
            get => _settings.DataAccess;
            set
            {
                _settings.DataAccess = value;
                _settings.Save();
            }
        }

        public string PrompText
        {
            get => _settings.PrompText;
            set
            {
                _settings.PrompText = value;
                _settings.Save();
            }
        }

        public ConsoleColor PrompColor
        {
            get => _settings.PrompColor;
            set
            {
                _settings.PrompColor = value;
                _settings.Save();
            }
        }

        public string DataFile
        {
            get => _settings.DataFile;
            set
            {
                _settings.DataFile = value;
                _settings.Save();
            }
        }
    }
}