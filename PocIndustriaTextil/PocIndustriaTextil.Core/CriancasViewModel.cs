using PocIndustriaTextil.Core.Services.Api;
using PocIndustriaTextil.Core.Teste;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Core
{
    public class CriancasViewModel
    {
        readonly static HttpClient http = new HttpClient();
        IApiService apiService;
        public ObservableCollection<Criancas> Criancas { get; set; }

        public CriancasViewModel()
        {
            Criancas = new ObservableCollection<Criancas>();
            apiService = new ApiService(http);
        }

        public async Task GetList()
        {
            try
            {
                var criancas = await apiService.GetItems<List<Criancas>>("criancas");

                foreach (var item in criancas)
                    Criancas.Add(item);
#if DEBUG
                criancas.ForEach(x => Console.WriteLine($" =====> Nome:{x.Nome}, Idade:{x.Idade}"));
#endif
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO CriancasViewModel { ex.Message }");
            }
        }
    }
}
