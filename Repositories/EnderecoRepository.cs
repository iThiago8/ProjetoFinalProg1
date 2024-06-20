using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Data;
using ProjetoFinalProg1.Models;

namespace ProjetoFinalProg1.Repositories
{
    public class EnderecoRepository
    {
        private int GeraProximoId()
        {
            int id = 0;
            foreach (var endereco in DataSet.Enderecos)
            {
                if (endereco.IdEndereco > id)
                    id = endereco.IdEndereco;
            }

            return ++id;
        }
        public void AdicionarEndereco(Endereco endereco)
        {
            endereco.IdEndereco = GeraProximoId();
            DataSet.Enderecos.Add(endereco);
        }

        public Endereco? BuscarPorId(int? id)
        {
            foreach (var endereco in DataSet.Enderecos)
            {
                if (endereco.IdEndereco == id)
                    return endereco;
            }
            return null;
        }

        public List<Endereco> ListarEnderecos()
        {
            return DataSet.Enderecos;
        }

        public void RemoverEndereco(Endereco endereco)
        {
            DataSet.Enderecos.Remove(endereco);
        }
    }
}