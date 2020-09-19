using System;
using System.Collections.Generic;
using System.Text;

namespace PocIndustriaTextil.Core.Utils.Responses
{
    public class LoginResponse
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
