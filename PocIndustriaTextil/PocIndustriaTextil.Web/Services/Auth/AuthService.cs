using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PocIndustriaTextil.Core.Model.DTO;
using PocIndustriaTextil.Core.Services.Api;
using PocIndustriaTextil.Core.Utils.Responses;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Web.Services.Auth
{
    public class AuthService : IAuthService
    {
        [Inject] public IApiService ApiService { get; set; }
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<GenericResponse<UsuarioCadastroDTO>> Register(UsuarioCadastroDTO usuario)
        {
            return await ApiService.PostItem<GenericResponse<UsuarioCadastroDTO>>("register", usuario);
        }

        public async Task<LoginResponse> Login(UsuarioLoginDTO usuario)
        {
            try
            {
                var loginResult = await ApiService.PostItem<LoginResponse>("login", usuario);

                if (!loginResult.Sucess)
                    return loginResult;

                await _localStorage.SetItemAsync("authToken", loginResult.Token);
                await ((TokenAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(usuario.Login);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

                return loginResult;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
      
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await ((TokenAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}