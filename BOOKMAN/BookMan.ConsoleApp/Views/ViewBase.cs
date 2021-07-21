using BookMan.ConsoleApp.Framework;
using System.IO;
using Newtonsoft.Json;

namespace BookMan.ConsoleApp.Views
{
    public abstract class ViewBase
    {
        protected Router _router = Router.Instance;
        public ViewBase() { }
        public virtual void Render() { }
    }
    
    /// <summary>
    /// Class view base
    /// </summary>
    public abstract class ViewBase<T> : ViewBase
    {
        protected T model;

        public ViewBase() { }

        public ViewBase(T model)
        {
            this.model = model;
        }

        /// <summary>
        /// Render json
        /// </summary>
        public virtual void Render() { }
        
        /// <summary>
        /// Render json model to path file
        /// </summary>
        /// <param name="path">string</param>
        public virtual void RenderJsonToFile(string path)
        {
            ViewHelp.WriteLine($"Save file to: {path}");
            var jsonData = JsonConvert.SerializeObject(model);
            File.WriteAllText(path, jsonData);
            ViewHelp.WriteLine("Done");
        }
    }
}