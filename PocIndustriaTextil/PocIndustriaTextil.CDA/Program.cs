using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PocIndustriaTextil.Core.Services.Api;
using PocIndustriaTextil.Core.Teste;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PocIndustriaTextil.CDA
{
    class Program
    {
        private static readonly HttpClient http = new HttpClient();
      
        static async Task Main(string[] args)
        {
            try
            {
                await ProcessRepositories();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"CDA ERRO ==> {ex.Message}");
            }
        }

        private static async Task ProcessRepositories()
        {
            IApiService apiService = new ApiService(http);
            var criancas = await apiService.GetItems<List<Criancas>>( "criancas" );

            foreach (var item in criancas)
                Console.WriteLine( $"{item.Nome} {item.Idade}" );
        }
    }
}


//ref: https://www.youtube.com/watch?v=e89oghX7JXg&feature=youtu.be&ab_channel=AngelSix

//Cria uma lista de dependencia
//var services = new ServiceCollection();

//var configuratioBuilder = new ConfigurationBuilder();

//Adicionana um arquivo de configuraçao 
//configuratioBuilder.AddJsonFile("appsettings.json", optional: true);

//Constroi a configuração
////var configuration = configuratioBuilder.Build();

//Injeta a configuração no sistema de ID
//services.AddSingleton<IConfiguration>(configuration);
//services.AddScoped<IApiService, ApiService>();

//Constroi o provedor de serviços
//var provider = services.BuildServiceProvider();