using PocIndustriaTextil.Core;
using PocIndustriaTextil.Core.Services.Api;
using PocIndustriaTextil.Core.Teste;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocIndustriaTextil.Mobile
{
    public partial class MainPage : ContentPage
    {
        public CriancasViewModel VM { get; set; }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = VM = new CriancasViewModel();
        }
    }
}
