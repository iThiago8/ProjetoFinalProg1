using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Data;
using ProjetoFinalProg1.Models;

namespace ProjetoFinalProg1.Repositories
{
    public class ViagemRepository
    {
        private int GeraProximoId()
        {
            int id = 0;
            foreach (var viagem in DataSet.Viagens)
            {
                if (viagem.IdViagem > id)
                    id = viagem.IdViagem;
            }

            return ++id;
        }
        public void AdicionarViagem(Viagem viagem)
        {
            viagem.IdViagem = GeraProximoId();
            DataSet.Viagens.Add(viagem);
        }

        public Viagem? BuscarPorId(int id)
        {
            foreach (var viagem in DataSet.Viagens)
            {
                if (viagem.IdViagem == id)
                    return viagem;
            }
            return null;
        }

        public List<Viagem> ListarViagens()
        {
              return DataSet.Viagens;
        }

        public void RemoverViagem(Viagem viagem)
        {
            DataSet.Viagens.Remove(viagem);
        }
    }
}