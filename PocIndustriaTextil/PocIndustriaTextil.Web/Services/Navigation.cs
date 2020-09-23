using Microsoft.AspNetCore.Components;
using PocIndustriaTextil.Core.Services.Navigation;
using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PocIndustriaTextil.Core;

namespace PocIndustriaTextil.Web.Services
{
    public class Navigation : INavigationService
    {
        public NavigationManager _navigation { get; }


        public Navigation(NavigationManager navigation)
        {
            _navigation = navigation;
        }
        public async Task NavigateBack()
        {
            await Task.Run(() => _navigation.NavigateTo($"/criancas"));
        }

        public async Task NavigateToPageAsync(string url)
        {
            await Task.Run(()=> _navigation.NavigateTo($"/criancas/novo"));
        }

        public Task NavigateToPageAsync(string url, string parameterKey, string parameterValue)
        {
            throw new NotImplementedException();
        }
    }
}
