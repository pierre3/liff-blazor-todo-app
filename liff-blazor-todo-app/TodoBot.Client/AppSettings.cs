using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBot.Client
{
    public class AppSettings
    {
        public string LiffId { get; set; }
        public string LiffIdForDebug { get; set; }
        public FunctionSettings FunctionSettings { get; set; }
    }

    public class FunctionSettings
    {
        public string BaseUrl { get; set; }
        public string CreateTodoKey { get; set; }
        public string UpdateTodoKey { get; set; }
        public string GetTodoListKey { get; set; }
        public string GetTodoKey { get; set; }
        public string DeleteTodoKey { get; set; }
    }
}
