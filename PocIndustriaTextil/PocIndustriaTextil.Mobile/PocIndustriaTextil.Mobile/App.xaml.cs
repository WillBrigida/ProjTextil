using Microsoft.Extensions.DependencyInjection;
using PocIndustriaTextil.Core;
using PocIndustriaTextil.Core.Modulos.Teste.ViewModel;
using PocIndustriaTextil.Core.Services.Navigation;
using PocIndustriaTextil.Mobile.Modulos.Acesso;
using PocIndustriaTextil.Mobile.Modulos.Teste;
using PocIndustriaTextil.Mobile.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocIndustriaTextil.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            services.AddSingleton<INavigationService, Navigation>();
            services.AddTransient<CriancaListaPageViewModel>();
            services.AddTransient<CriancaPageViewModel>();

            var serviceProvider = services.BuildServiceProvider(validateScopes: true);
            var scope = serviceProvider.CreateScope();
            Container.Current.Services = serviceProvider;

            MainPage = new NavigationPage(new CriancaListaPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
