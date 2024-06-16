using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Repositories;

namespace ProjetoFinalProg1.Controllers
{
    public class EnderecoController
    {
        private EnderecoRepository enderecoRepository;
        public void AdicionarEndereco(Endereco endereco)
        {
            enderecoRepository.AdicionarEndereco(endereco);
        }

        public void BuscarPorId(int id)
        {
            enderecoRepository.BuscarPorId(id);
        }
        public void ListarEnderecos()
        {
            enderecoRepository.ListarEnderecos();
        }
        public void RemoverEndereco(Endereco endereco)
        {
            enderecoRepository.RemoverEndereco(endereco);
        }
    }
}