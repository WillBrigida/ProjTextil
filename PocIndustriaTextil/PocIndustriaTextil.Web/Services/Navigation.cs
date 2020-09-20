using Microsoft.AspNetCore.Components;
using PocIndustriaTextil.Core.Services.Navigation;
using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocIndustriaTextil.Web.Services
{
    public class Navigation : INavigationService
    {
        [Inject]public NavigationManager Nav { get; set; }
        public async Task NavigateBack()
        {
            Nav.NavigateTo("/criancas");
        }

        public async Task NavigateToPageAsync(string url)
        {
            Nav.NavigateTo("/criancas/novo");
        }

        public Task NavigateToPageAsync(string url, string parameterKey, string parameterValue)
        {
            throw new NotImplementedException();
        }
    }
}
