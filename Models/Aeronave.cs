using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public enum TipoDeAeronave 
    {
        
    }
    public class Aeronave
    {
        public int IdAeronave { get; set; }
        public TipoDeAeronave TipoDeAeronave { get; set; }
        public int NumeroDePoltronas { get; set; }

    }
}