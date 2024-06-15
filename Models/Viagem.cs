using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class Viagem
    {
        public int IdViagem { get; set; }
        public Aeroporto AeroportoDeOrigem { get; set; }
        public Aeroporto AeroportoDeDestino { get; set; }
        public DateTime HoraDeSaida { get; set; }
        public DateTime HoraPrevistaDeChegada { get; set; }
        public List<int> PoltronasDisponiveis {get; set; }
        public List<int> PoltronasOcupadas { get; set; }

    }
}