using PocIndustriaTextil.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocIndustriaTextil.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriancasPage : ContentPage
    {
        public CriancasViewModel VM { get; set; }
        public CriancasPage()
        {
            InitializeComponent();
            BindingContext = VM = new CriancasViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await VM.GetList();
        }
    }
}