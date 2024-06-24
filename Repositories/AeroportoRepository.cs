using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Data;
using ProjetoFinalProg1.Models;

namespace ProjetoFinalProg1.Repositories
{
    public class AeroportoRepository
    {
        private int GeraProximoId()
        {
            int id = 0;
            foreach (var aeroporto in DataSet.Aeroportos)
            {
                if (aeroporto.IdAeroporto > id)
                    id = aeroporto.IdAeroporto;
            }

            return ++id;
        }
        public void CadastrarAeroporto(Aeroporto aeroporto)
        {
            aeroporto.IdAeroporto = GeraProximoId();
            DataSet.Aeroportos.Add(aeroporto);
        }

        public Aeroporto? BuscarPorId(int? id)
        {
            foreach (var aeroporto in DataSet.Aeroportos)
            {
                if (aeroporto.IdAeroporto == id)
                    return aeroporto;
            }
            return null;
        }

        public List<Aeroporto> ListarAeroportos()
        {
            return DataSet.Aeroportos;
        }

        public void RemoverAeroporto(Aeroporto aeroporto)
        {
            DataSet.Aeroportos.Remove(aeroporto);
        }
        
        public bool ImportarDelimitado(string linha, string delimitador)
        {
            /*
            if (string.IsNullOrWhiteSpace(linha))
                return false;

            string[] data = linha.Split(delimitador);

            if (data.Count() < 1)
                return false;

            Aeroporto viagem = new Viagem
            {
                IdViagem = Convert.ToInt32((data[0] == null ? 0 : data[0])),
                Aeronave = (data[1] == null ? AeronaveRepository.BuscarPorId(idAeronaveConvertida) : data[1]),
                EmailAddress = (data[2] == null ? string.Empty : data[2]),

            };

            AdicionarViagem(viagem, false);
            */
            return true;
        }
    }
}