using System;
using System.Collections.Generic;
using System.Text;

namespace Social.Domain.Entities
{
    public class Contato : BaseEntity
    {
        public string NomeContato { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        
        public int RetornarIdade() => DataNascimento != null ? (DateTime.Now.Year - DataNascimento.Year) : 0;
        
    }
}
