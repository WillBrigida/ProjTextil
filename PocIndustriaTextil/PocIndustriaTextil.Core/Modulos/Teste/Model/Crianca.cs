using System;

namespace PocIndustriaTextil.Core.Modulos.Teste.Model
{
    public class Crianca
    {
        public int CriancaId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool RegistroAtivo { get; set; } = true;
        public DateTime? DataDesativacao { get; set; } = null;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
