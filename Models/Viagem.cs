using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        public List<Poltrona> Poltronas { get; set; }
            = new();

        public string FormatarParaDelimitado()
        {
            int numeroPoltronasOcupadas = 0;
            int numeroPoltronasLivres = 0;
            foreach (var poltrona in Poltronas)
            {
                if (poltrona.Livre)
                    numeroPoltronasLivres++;
                else
                    numeroPoltronasOcupadas++;
            }

            return 
                $"{IdViagem};"
                + $"{Aeronave?.IdAeronave};"
                + $"{AeroportoDeOrigem?.NomeAeroporto};"
                + $"{AeroportoDeDestino?.NomeAeroporto};"
                + $"{HoraDeSaida};"
                + $"{HoraPrevistaDeChegada};"
                + $"{numeroPoltronasLivres};"
                + $"{numeroPoltronasOcupadas}";
        }
        public override string ToString()
        {
            int numeroPoltronasOcupadas = 0;
            int numeroPoltronasLivres = 0;
            foreach (var poltrona in Poltronas)
            {
                if (poltrona.Livre)
                    numeroPoltronasLivres++;
                else
                    numeroPoltronasOcupadas++;
            }

            return
                $"ID da viagem: {IdViagem}\n"
                + $"Aeronave: {Aeronave?.IdAeronave}\n"
                + $"Aeropoorto de origem: {AeroportoDeOrigem?.NomeAeroporto}\n"
                + $"Aeropoorto de destino: {AeroportoDeDestino?.NomeAeroporto}\n"
                + $"Hora de saída prevista: {HoraDeSaida}\n"
                + $"Hora de chegada prevista: {HoraPrevistaDeChegada}\n"
                + $"Nº de Poltronas livres: {numeroPoltronasLivres}\n"
                + $"Nº de Poltronas ocupadas: {numeroPoltronasOcupadas}\n";
        }
    }
}