using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalProg1.Models
{
    public class Aeroporto
    {
        public int IdAeroporto { get; set; }
        public string? NomeAeroporto { set; get; }
        public Endereco? Endereco { get; set; }
        public override string ToString()
        {
            return $"ID: {IdAeroporto}\n" 
            + $"Nome: {NomeAeroporto}\n"
            + $"Endereço: {Endereco}\n";
        }

        public string FormatarParaDelimitado()
        {
            return
                $"{IdAeroporto};"
                + $"{NomeAeroporto};"
                + $"{Endereco?.FormatarParaDelimitado()}\n";
        }
    }
}