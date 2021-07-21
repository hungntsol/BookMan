using System;
using BookMan.ConsoleApp.Views;

namespace BookMan.ConsoleApp.Framework
{
    public class ControllerBase
    {
        public virtual void Render(ViewBase viewBase)
        {
            viewBase.Render();
        }
        
        public virtual void Render<T>(ViewBase<T> viewBase, string path = "", bool both = false)
        {
            if (string.IsNullOrEmpty(path))
            {
                viewBase.Render();
                return;
            }

            if (both)
            {
                viewBase.Render();
                viewBase.RenderJsonToFile(path);
                return;
            }
            
            viewBase.RenderJsonToFile(path);
        }

        public virtual void Render(Message message)
        {
            Render(new MessageView(message));
        }

        public virtual void Success(string text, string label = "SUCCESS")
        {
            Render(new Message() {Type = MessageType.Success, Text = text, Label = label});
        }

        public virtual void Error(string text, string label = "ERROR")
        {
            Render(new Message() {Type = MessageType.Error, Text = text, Label = label});
        }

        public virtual void Information(string text, string label = "INFORMATION")
        {
            Render(new Message() {Type = MessageType.Information, Text = text, Label = label});
        }

        public virtual void Configuration(string text, string route, string label = "CONFIGURATION")
        {
            Render(new Message() {Type = MessageType.Confirguration, Text = text, Label = label, BackRoute = route});
        }
    }
}