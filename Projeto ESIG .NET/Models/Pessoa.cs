using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_ESIG.NET.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string PessoaNome { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Pais { get; set; }
        public string Usuario { get; set; }
        public string Telefone { get; set; }
        public string Data_Nascimento { get; set; } 
        public int CargoId { get; set; }
    }
}