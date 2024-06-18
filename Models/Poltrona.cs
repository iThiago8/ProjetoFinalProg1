using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalProg1.Models
{
    public enum TipoPoltrona 
    {
        Janela,
        Corredor
    }
    public class Poltrona
    {

        public int IdPoltrona { get; set; }
        public TipoPoltrona Tipo { get; set; }
        public bool Ocupada { get; set; }
    }
}