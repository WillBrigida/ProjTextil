using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Core.Services.Api
{
    public interface IApiService
    {
        Task<T> GetItems<T>(string uri);

        Task<T> GetItem<T>(string uri);

        Task<T> PutItem<T>(string uri, object item);

        Task<T> PostItem<T>(string uri, object item);

        Task<T> DeleteItem<T>(string uri, object item);


    }

    public class ApiService : IApiService
    {
        readonly HttpClient _http;

        public ApiService(HttpClient httpClient) { _http = httpClient; }


        public async Task<T> GetItem<T>(string uri)
        {
            return await _http.GetFromJsonAsync<T>($"{UriBase.Uri}{uri}");
        }

        public async Task<T> GetItems<T>(string uri)
        {
            return await _http.GetFromJsonAsync<T>($"{UriBase.Uri}{uri}");
        }

        public async Task<T> PostItem<T>(string uri, object item)
        {
            return await GetPostResponse<T>($"{UriBase.Uri}{uri}", item);
        }

        public async Task<T> PutItem<T>(string uri, object item)
        {
            return await GetPutResponse<T>($"{UriBase.Uri}{uri}", item);
        }


        public async Task<T> DeleteItem<T>(string uri, object item)
        {
            return await GetPutResponse<T>($"{UriBase.Uri}{uri}", item);
        }

        async Task<T> GetPostResponse<T>(string uri, object item)
        {
            var loginAsJson = JsonSerializer.Serialize(item);
            var response = await _http.PostAsync(uri, new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        async Task<T> GetPutResponse<T>(string uri, object item)
        {
            var loginAsJson = JsonSerializer.Serialize(item);
            var response = await _http.PutAsync(uri, new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
