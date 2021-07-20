using BookMan.ConsoleApp.Framework;
using System.IO;
using Newtonsoft.Json;

namespace BookMan.ConsoleApp.Views
{
    /// <summary>
    /// Class view base
    /// </summary>
    public class ViewBase
    {
        protected object model;
        protected Router _router = Router.Instance;

        public ViewBase() { }

        public ViewBase(object model)
        {
            this.model = model;
        }

        /// <summary>
        /// Render json model to path file
        /// </summary>
        /// <param name="path">string</param>
        public void RenderJsonToFile(string path)
        {
            ViewHelp.WriteLine($"Save file to: {path}");
            var jsonData = JsonConvert.SerializeObject(model);
            File.WriteAllText(path, jsonData);
            ViewHelp.WriteLine("Done");
        }
    }
}