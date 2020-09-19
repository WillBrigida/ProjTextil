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

            MainPage = new CriancasPage();
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
