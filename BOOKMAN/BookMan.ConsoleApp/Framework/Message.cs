using System;
using BookMan.ConsoleApp.Views;

namespace BookMan.ConsoleApp.Framework
{
    public enum  MessageType { Success, Information, Error, Confirguration}
    
    public class Message
    {
        public MessageType Type { get; set; } = MessageType.Success;
        public string Label { get; set; }
        public string Text { get; set; }
        public string BackRoute { get; set; }
    }

    public class MessageView : ViewBase<Message>
    {
        public MessageView() { }

        public MessageView(Message model) : base(model) { }

        public override void Render()
        {
            switch (model.Type)
            {
                case MessageType.Success:
                    ViewHelp.WriteLine(model.Label != null ? model.Label.ToUpper() : "SUCCESS", ConsoleColor.Green);
                    break;
                case MessageType.Error:
                    ViewHelp.WriteLine(model.Label != null ? model.Label.ToUpper() : "ERROR", ConsoleColor.Red);
                    break;
                case MessageType.Information:
                    ViewHelp.WriteLine(model.Label != null ? model.Label.ToUpper() : "INFORMATION:");
                    break;
                case MessageType.Confirguration:
                    ViewHelp.WriteLine(model.Label != null ? model.Label.ToUpper() : "CONFIGURATION", ConsoleColor.Cyan);
                    break;
            }

            if (model.Type != MessageType.Confirguration)
            {
                ViewHelp.WriteLine(model.Text);
            }
            else
            {
                ViewHelp.Write(model.Text, ConsoleColor.Magenta);
                var answer = Console.ReadLine().ToLower();
                if (answer.Contains("yes") || answer == "y" || answer == "Y") Router.Instance.Forward(model.BackRoute);
            }
        }
    }
}