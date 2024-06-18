using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalProg1.Models
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string? Rua { get; set; }
        public int Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public string? CEP { get; set; }
        public override string ToString()
        {
            return $"{Rua}, numero {Numero} - {Bairro}, {Cidade}, {Pais} - {CEP}";
        }
    }
}