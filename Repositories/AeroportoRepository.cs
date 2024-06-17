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
        public void AdicionarAeroporto(Aeroporto aeroporto)
        {
            aeroporto.IdAeroporto = GeraProximoId();
            DataSet.Aeroportos.Add(aeroporto);
        }

        public Aeroporto BuscarPorId(int id)
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
    }
}