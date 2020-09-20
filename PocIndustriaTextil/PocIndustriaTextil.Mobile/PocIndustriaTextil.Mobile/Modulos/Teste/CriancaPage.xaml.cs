using PocIndustriaTextil.Core;
using PocIndustriaTextil.Core.Modulos.Teste.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocIndustriaTextil.Mobile.Modulos.Teste
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriancaPage : ContentPage
    {
        public CriancaPageViewModel VM { get; set; }
        public CriancaPage()
        {
            InitializeComponent();
            BindingContext = VM = Container.Current.Services.GetService<CriancaPageViewModel>();//new CriancaPageViewModel();
        }
    }
}