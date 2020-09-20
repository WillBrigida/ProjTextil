using System;
using System.Collections.Generic;
using System.Text;

namespace PocIndustriaTextil.Core
{
    public class Container
    {
        public static Container Current { get; } = new Container();
        public IServiceProvider Services { get; set; }

        private Container()
        {

        }
    }
}
