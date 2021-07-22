using System;
using BookMan.ConsoleApp.Framework;

namespace BookMan.ConsoleApp.Controllers
{
    /// <summary>
    /// Class config controller
    /// </summary>
    internal class ConfigController : ControllerBase
    {
        private Config _config = Config.Instance;

        public void ConfigPrompText(string text)
        {
            _config.PrompText = text;
            Success("Command text has been changed");
        }

        public void ConfigPrompColor(string color)
        {
            if (Enum.TryParse(color, true, out ConsoleColor consoleColor))
            {
                _config.PrompColor = consoleColor;
                Success("Command color has been changed");
            }
        }

        public void CurrentDataAccess()
        {
            Information($"Current data access engine: {_config.DataAccess}" +
                        $"\nCurrent data file: {_config.DataFile}");
        }
        
        public void ConfigDataAccess(string da, string df)
        {
            _config.DataAccess = da;
            _config.DataFile = df;
            Success("DataAccess and data file have been changed");
        }
    }
}