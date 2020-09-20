using Microsoft.Extensions.DependencyInjection;
using PocIndustriaTextil.Core;
using PocIndustriaTextil.Core.Modulos.Teste.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocIndustriaTextil.Mobile.Modulos.Teste
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriancaListaPage : ContentPage
    {
        public CriancaListaPageViewModel VM { get; set; }
        public CriancaListaPage()
        {
            InitializeComponent();
            BindingContext = VM = Container.Current.Services.GetRequiredService<CriancaListaPageViewModel>();//new CriancaListaPageViewModel();
        }

        protected override async void OnAppearing()
        {
            await VM.GetList();
            base.OnAppearing();
        }
    }
}