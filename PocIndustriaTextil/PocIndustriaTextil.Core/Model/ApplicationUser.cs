using Microsoft.AspNetCore.Identity;
using System;

namespace PocIndustriaTextil.Core.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string NomeCompleto { get; set; }

        public bool? RegistroAtivo { get; set; } = true;

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataAtivacao { get; set; } = DateTime.Now;

        public DateTime? DataDesativacao { get; set; } = null;
    }
}
