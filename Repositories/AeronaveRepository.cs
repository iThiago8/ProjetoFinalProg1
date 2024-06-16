using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Data;

namespace ProjetoFinalProg1.Repositories
{
    public class AeronaveRepository
    {
        private int GeraProximoId()
        {
            int id = 0;
            foreach (var aeronave in DataSet.Aeronaves)
            {
                if (aeronave.IdAeronave > id)
                    id = aeronave.IdAeronave;
            }

            return ++id;
        }
        public void AdicionarAeronave(Aeronave aeronave)
        {
            aeronave.IdAeronave = GeraProximoId();
            DataSet.Aeronaves.Add(aeronave);
        }

        public Aeronave BuscarPorId(int id)
        {
            foreach (var aeronave in DataSet.Aeronaves)
            {
                if (aeronave.IdAeronave == id)
                    return aeronave;
            }
            return null;
        }

        public List<Aeronave> ListarAeronaves()
        {
            return DataSet.Aeronaves;
        }

        public void RemoverAeronave(Aeronave aeronave)
        {
            DataSet.Aeronaves.Remove(aeronave);
        }
    }
}