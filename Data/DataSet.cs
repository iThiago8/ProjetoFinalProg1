using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;

namespace ProjetoFinalProg1.Data
{
    public class DataSet
    {
        public static List<Aeronave> Aeronaves { get; set; }
            = new List<Aeronave>();
        public static List<Aeroporto> Aeroportos { get; set; }
            = new List<Aeroporto>();
        
        public static List<Endereco> Enderecos { get; set; }
            = new List<Endereco>();

        public static List<Viagem> Viagens { get; set; }
            = new List<Viagem>();
    }
}