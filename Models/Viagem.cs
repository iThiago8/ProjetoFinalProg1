using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalProg1.Models
{
    public class Viagem
    {
        public int IdViagem { get; set; }
        public Aeronave? Aeronave { get; set; }
        public Aeroporto? AeroportoDeOrigem { get; set; }
        public Aeroporto? AeroportoDeDestino { get; set; }
        public DateTime HoraDeSaida { get; set; }
        public DateTime HoraPrevistaDeChegada { get; set; }
        public List<Poltrona>? Poltronas {get; set; } = new();

        public Viagem(int idViagem, Aeronave aeronave, Aeroporto aeroportoOrigem, Aeroporto aeroportoDestino, DateTime horaSaida, DateTime horaPrevistaChegada)
        {
            IdViagem = idViagem;
            Aeronave = aeronave;
            AeroportoDeOrigem = aeroportoOrigem;
            AeroportoDeDestino = aeroportoDestino;
            HoraDeSaida = horaSaida;
            HoraPrevistaDeChegada = horaPrevistaChegada;
            Poltronas = new List<Poltrona>();

            for (int i = 1; i < aeronave.NumeroDePoltronas; i++)
            {
                Poltrona poltrona = new()
                {
                    IdPoltrona = i,
                    Tipo = i % 2 == 0 ? TipoPoltrona.Janela : TipoPoltrona.Corredor,
                    Ocupada = false
                };
            }
        }
    }
}