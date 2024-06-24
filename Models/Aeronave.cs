using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalProg1.Models
{
    public class Aeronave
    {
        public int IdAeronave { get; set; }
        public int NumeroDePoltronas { get; set; }
        public override string ToString()
        {
            return $"ID: {IdAeronave}\n"
                + $"Número de poltronas: {NumeroDePoltronas}\n";
        }
        public string FormatarParaDelimitado()
        {
            return
                $"{IdAeronave};"
                + $"{NumeroDePoltronas}\n";
        }
    }
}