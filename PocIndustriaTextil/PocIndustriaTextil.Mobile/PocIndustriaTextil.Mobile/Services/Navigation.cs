using PocIndustriaTextil.Core.Services.Navigation;
using System;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Mobile.Services
{
    public class Navigation : INavigationService
    {
        public async Task NavigateBack()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavigateToPageAsync(string url)
        {
            await App.Current.MainPage.Navigation.PushAsync(new PocIndustriaTextil.Mobile.Modulos.Teste.CriancaPage());
        }

        public Task NavigateToPageAsync(string url, string parameterKey, string parameterValue)
        {
            throw new NotImplementedException();
        }
    }
}
