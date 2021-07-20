using System;
using System.Collections.Generic;

namespace BookMan.ConsoleApp.Framework
{
    /// <summary>
    /// Get param of query
    /// </summary>
    public class Parameter
    {
        private readonly Dictionary<string, string> _pairs = new Dictionary<string, string>();

        /// <summary>
        /// Overloading this[]
        /// </summary>
        /// <param name="key">string key</param>
        public string this[string key]
        {
            get
            {
                if (_pairs.ContainsKey(key)) return _pairs[key];
                else return null;
            }
            set => _pairs[key] = value;
        }

        public Parameter(string parameter)
        {
            var pairs = parameter.Split(new[] {'&'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in pairs)
            {
                var p = pair.Split('=');
                if (p.Length == 2)
                {
                    this[p[0].Trim()] = p[1].Trim();
                }
            }
        }
    }
}