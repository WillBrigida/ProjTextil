using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PocIndustriaTextil.Core.Services.Api;
using PocIndustriaTextil.Core;
using PocIndustriaTextil.Core.Modulos.Acesso;
using PocIndustriaTextil.Core.Modulos.Teste.ViewModel;
using PocIndustriaTextil.Core.Services.Navigation;
using PocIndustriaTextil.Web.Services;

namespace PocIndustriaTextil.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IApiService, ApiService>();
            builder.Services.AddSingleton<INavigationService, Navigation>();
            builder.Services.AddTransient<CriancasViewModel>();
            builder.Services.AddTransient<CriancaListaPageViewModel>();
            builder.Services.AddTransient<CriancaPageViewModel>();
            builder.Services.AddTransient<CadastroViewModel>();


            var host = builder.Build();
            Container.Current.Services = host.Services;

            await builder.Build().RunAsync();
        }
    }
}
