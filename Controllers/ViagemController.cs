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
        public ViagemController()
        {
            viagemRepository = new();
        }
        public void AdicionarViagem(Viagem viagem)
        {
            viagemRepository.AdicionarViagem(viagem);
        }

        public void GeraListaPoltronas(Viagem viagem)
        {
            viagemRepository.GeraListaPoltronas(viagem);
        }
        public Viagem BuscarPorId(int id)
        {
            return viagemRepository.BuscarPorId(id);
        }
        public List<Viagem> ListarViagens()
        {
            return viagemRepository.ListarViagens();
        }
        public void RemoverViagem(Viagem viagem)
        {
            viagemRepository.RemoverViagem(viagem);
        }
    }
}