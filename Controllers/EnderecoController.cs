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
        public EnderecoController()
        {
            enderecoRepository = new();
        }
        public void AdicionarEndereco(Endereco endereco)
        {
            enderecoRepository.AdicionarEndereco(endereco);
        }

        public Endereco BuscarPorId(int id)
        {
            return enderecoRepository.BuscarPorId(id);
        }
        public List<Endereco> ListarEnderecos()
        {
            return enderecoRepository.ListarEnderecos();
        }
        public void RemoverEndereco(Endereco endereco)
        {
            enderecoRepository.RemoverEndereco(endereco);
        }
    }
}