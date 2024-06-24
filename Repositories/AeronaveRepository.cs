using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Data;
using System.Net.Mail;

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
        public void AdicionarAeronave(Aeronave aeronave, bool gerarId = true)
        {
            if (gerarId)
                aeronave.IdAeronave = GeraProximoId();
            
            DataSet.Aeronaves.Add(aeronave);
        }

        public Aeronave? BuscarPorId(int? id)
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

        public bool ImportarDelimitado(string linha, string delimitador)
        {
            if (string.IsNullOrWhiteSpace(linha))
                return false;

            string[] data = linha.Split(delimitador);

            if (data.Count() < 1)
                return false;
            string v = data[0];
            Aeronave aeronave = new Aeronave
            {
                IdAeronave = Convert.ToInt32((data[0] == null ? 0 : data[0])),
                NumeroDePoltronas = Convert.ToInt32(data[1]),
            };

            AdicionarAeronave(aeronave, false);

            return true;
        }
    }
}