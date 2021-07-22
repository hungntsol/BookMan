using System;
using System.Collections.Generic;
using System.Linq;
using BookMan.ConsoleApp.Framework;
using BookMan.ConsoleApp.Models;

namespace BookMan.ConsoleApp.Views
{
    /// <summary>
    /// List book in group of folder
    /// </summary>
    internal class BookStatsView : ViewBase<IEnumerable<IGrouping<string, Book>>>
    {
        public BookStatsView(IEnumerable<IGrouping<string, Book>> model) : base(model)
        {
        }

        /// <summary>
        /// Override render method
        /// </summary>
        public override void Render()
        {
            foreach (var root in model)
            {
                ViewHelp.WriteLine($"{root.Key}: ", ConsoleColor.DarkCyan);
                foreach (var file in root)
                {
                    ViewHelp.WriteLine($"{file.Id}: {file.Title}", file.Reading ? ConsoleColor.Green : ConsoleColor.White);
                }
            }
        }
    }
}