using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Repositories;

namespace ProjetoFinalProg1.Controllers
{
    public class AeroportoController
    {
        private AeroportoRepository aeroportoRepository;
        public AeroportoController()
        {
            aeroportoRepository = new();
        }
        public void AdicionarAeroporto(Aeroporto aeroporto)
        {
            aeroportoRepository.AdicionarAeroporto(aeroporto);
        }

        public void BuscarPorId(int id)
        {
            aeroportoRepository.BuscarPorId(id);
        }
        public void ListarAeroportos()
        {
            aeroportoRepository.ListarAeroportos();
        }
        public void RemoverAeroporto(Aeroporto aeroporto)
        {
            aeroportoRepository.RemoverAeroporto(aeroporto);
        }
        
    }
}