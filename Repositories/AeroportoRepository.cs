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
        public void CadastrarAeroporto(Aeroporto aeroporto, bool GeraId = true)
        {
            if (GeraId)
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
        public Aeroporto? BuscarPorNome(string nome)
        {
            foreach (var aeroporto in DataSet.Aeroportos)
            {
                if (nome == aeroporto.NomeAeroporto)
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
            
            if (string.IsNullOrWhiteSpace(linha))
                return false;

            string[] data = linha.Split(delimitador);

            if (data.Count() < 1)
                return false;

            Endereco endereco = new Endereco
            {
                IdEndereco = int.Parse(data[2]), 
                Rua = data[3],
                Numero = int.Parse(data[4]),
                Bairro = data[5],
                Cidade = data[6],
                Estado = data[7],
                Pais = data[8],
                CEP = data[9],
            };

            Aeroporto aeroporto = new Aeroporto
            {
                IdAeroporto = Convert.ToInt32(data[0] == null ? 0 : data[0]),
                NomeAeroporto = data[1],
                Endereco = endereco,

            };

            CadastrarAeroporto(aeroporto, false);
            
            return true;
        }
    }
}