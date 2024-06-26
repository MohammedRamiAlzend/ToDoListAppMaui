// Ignore Spelling: App

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Data
{
    public class DataBaseRequest
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
    public class DataBaseRequest<T> : DataBaseRequest
    {
        public T? Data { get; set; }
    }
}
