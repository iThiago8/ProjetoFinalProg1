using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Repositories;

namespace ProjetoFinalProg1.Controllers
{
    public class ViagemController
    {
        private ViagemRepository viagemRepository;
        public void AdicionarViagem(Viagem viagem)
        {
            viagemRepository.AdicionarViagem(viagem);
        }

        public void BuscarPorId(int id)
        {
            viagemRepository.BuscarPorId(id);
        }
        public void ListarViagens()
        {
            viagemRepository.ListarViagens();
        }
        public void RemoverViagem(Viagem viagem)
        {
            viagemRepository.RemoverViagem(viagem);
        }
    }
}