using System;
using System.Collections.Generic;
using System.Text;

namespace PocIndustriaTextil.Core.Utils.Responses
{
    public class GenericResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Item { get; set; }
        public List<T> Items { get; set; }
    }
}
