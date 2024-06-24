using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Data;
using ProjetoFinalProg1.Models;

namespace ProjetoFinalProg1.Repositories
{
    public class ViagemRepository
    {
        private AeronaveRepository? aeronaveRepository;
        private AeroportoRepository? aeroportoRepository;

        public ViagemRepository()
        {
            aeronaveRepository = new();
            aeroportoRepository = new();
        }

        private int GeraProximoId()
        {
            int id = 0;
            foreach (var viagem in DataSet.Viagens)
            {
                if (viagem.IdViagem > id)
                    id = viagem.IdViagem;
            }

            return ++id;
        }
        public void AdicionarViagem(Viagem viagem, bool gerarId = true)
        {
            viagem.IdViagem = GeraProximoId();
            DataSet.Viagens.Add(viagem);
        }

        public List<Poltrona> GeraListaPoltronas(Viagem viagem)
        {
            List<Poltrona> poltronas = [];
            for (int i = 1; i <= viagem.Aeronave.NumeroDePoltronas; i++)
            {
                Poltrona poltrona = new()
                {
                    IdPoltrona = i,
                    Tipo = (i % 2 == 0) ? TipoPoltrona.Janela : TipoPoltrona.Corredor,
                    Livre = true
                };
                poltronas.Add(poltrona);
            }

            return poltronas;
        }

        public Viagem? BuscarPorId(int? id)
        {
            foreach (var viagem in DataSet.Viagens)
            {
                if (viagem.IdViagem == id)
                    return viagem;
            }
            return null;
        }

        public List<Viagem> ListarViagens()
        {
              return DataSet.Viagens;
        }

        public void RemoverViagem(Viagem viagem)
        {
            DataSet.Viagens.Remove(viagem);
        }
        
        public bool ImportarDelimitado(string linha, string delimitador)
        {
            if (string.IsNullOrWhiteSpace(linha))
                return false;

            string[] data = linha.Split(delimitador);

            Console.WriteLine("------ Carregando dados");
            Console.WriteLine(data);

            if (data.Count() < 1)
                return false;


            if (data[1] == null 
            || data [2] == null
            || data [3] == null
            || data [4] == null
            || data [5] == null
            
            )
                return false; 

            Console.WriteLine("------ Dados válidos");
            
            int idAeronaveConvertida = int.Parse(data[1]);

            Aeronave? a = aeronaveRepository?.BuscarPorId(idAeronaveConvertida);
            Console.WriteLine($"------ Aeronave {idAeronaveConvertida} {a?.IdAeronave}");

            Aeroporto? ao = aeroportoRepository?.BuscarPorNome(data[2]);
            Console.WriteLine($"------ Aeroporto Origem Id: {data[2]} {ao?.NomeAeroporto}");

            Aeroporto? ad = aeroportoRepository?.BuscarPorNome(data[3]);
            Console.WriteLine($"------ Aeroporto Destino id: {data[3]} {ad?.ToString()}");

            Viagem viagem = new Viagem
            {
                IdViagem = Convert.ToInt32(data[0] == null ? 0 : data[0]),
                Aeronave = aeronaveRepository?.BuscarPorId(idAeronaveConvertida),
                AeroportoDeOrigem = aeroportoRepository?.BuscarPorNome(data[2]),
                AeroportoDeDestino = aeroportoRepository?.BuscarPorNome(data[3]),
                
                HoraDeSaida = Convert.ToDateTime(data[4]),
                HoraPrevistaDeChegada = Convert.ToDateTime(data[5]),
            };

            Console.WriteLine("------ Objeto construído");

            if (viagem.Aeronave == null
                || viagem.AeroportoDeOrigem == null
                || viagem.AeroportoDeDestino == null
            )
                return false;

            Console.WriteLine("------ Viagem válida");
            
            viagem.Poltronas = GeraListaPoltronas(viagem);

            Console.WriteLine("------ Poltronas associadas");

            AdicionarViagem(viagem, false);

            Console.WriteLine("------ Viagem registrada");

            return true;
        }
        
    }
}