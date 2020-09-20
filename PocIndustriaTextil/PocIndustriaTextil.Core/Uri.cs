using System;
using System.Collections.Generic;
using System.Text;

namespace PocIndustriaTextil.Core
{
    public static class UriBase
    {
        const string Base = "http://152.67.46.122:80/";
        //const string Base = "https://localhost:44368/";
        //const string Base = "http://localhost:8080/";
        //const string Base = "http://10.0.2.2:8080/";
        const string ApiVersao = "api/v1/";

        public static string Uri => $"{Base}{ApiVersao}";
    }
}
