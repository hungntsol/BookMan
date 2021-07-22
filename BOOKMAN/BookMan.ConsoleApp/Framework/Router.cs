using System;
using System.Collections.Generic;
using System.Text;

namespace BookMan.ConsoleApp.Framework
{
    using RoutingTable = Dictionary<string, ControllerAction>;
    
    /// <summary>
    /// Delete for method:
    /// - Output: void
    /// - Input: Parameter parameter
    /// </summary>
    public delegate void ControllerAction(Parameter parameter = null);
    
    /// <summary>
    /// Class router
    /// </summary>
    public class Router
    {
        private static Router _instance;
        private readonly RoutingTable _rountingTable;
        private readonly Dictionary<string, string> _helpTable;

        public static Router Instance => _instance ?? (_instance = new Router());

        private Router()
        {
            _rountingTable = new RoutingTable();
            _helpTable = new Dictionary<string, string>();
        }

        /// <summary>
        /// Push all route command to table
        /// </summary>
        /// <returns>StringBuilder</returns>
        public string GetRoutes()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var k in _rountingTable.Keys)
            {
                stringBuilder.Append($"k");
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Push all help command to table
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetHelp(string key)
        {
            if (_helpTable.ContainsKey(key)) return _helpTable[key];
            else return "Document not exited";
        }

        /// <summary>
        /// Create route
        /// </summary>
        /// <param name="route">string</param>
        /// <param name="action">Parameter</param>
        /// <param name="help">string</param>
        public void Register(string route, ControllerAction action, string help = "")
        {
            if (!_rountingTable.ContainsKey(route))
            {
                _rountingTable[route] = action;
                _helpTable[route] = help;
            }
        }

        /// <summary>
        /// Direct command
        /// </summary>
        /// <param name="request">string</param>
        /// <exception cref="Exception">Command not found</exception>
        public void Forward(string request)
        {
            var req = new Request(request);
            if (!_rountingTable.ContainsKey(req.Route)) throw new Exception("Command not found");
            if (req.Parameter == null)
            {
                _rountingTable[req.Route]?.Invoke();
            }
            else
            {
                _rountingTable[req.Route]?.Invoke(req.Parameter);
            }
        }

        /// <summary>
        /// Analyse request
        /// </summary>
        private class Request
        {
            /// <summary>
            ///  Param of request
            /// </summary>
            public string Route { get; set; }
            
            /// <summary>
            /// Param of request
            /// </summary>
            public Parameter Parameter { get; set; }

            /// <summary>
            /// Get request
            /// </summary>
            /// <param name="req"></param>
            public Request(string req)
            {
                Analyse(req);
            }

            /// <summary>
            /// Method analyze request
            /// </summary>
            /// <param name="req">string req</param>
            private void Analyse(string req)
            {
                var firstIndex = req.IndexOf('?');
                if (firstIndex < 0)
                {
                    Route = req.ToLower().Trim();
                }
                else
                {
                    if (firstIndex <= 1) throw new Exception("Invalid request");

                    var tokens = req.Split(new[] {'?'}, 2, StringSplitOptions.RemoveEmptyEntries);
                    Route = tokens[0].ToLower().Trim();

                    var parameterPart = req.Substring(firstIndex + 1).Trim();
                    Parameter = new Parameter(parameterPart);
                }
            }
        }
    }
}