using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Repositories;
using ProjetoFinalProg1.Utils;

namespace ProjetoFinalProg1.Controllers
{
    public class AeronaveController
    {
        private AeronaveRepository aeronaveRepository;
        public AeronaveController()
        {
            aeronaveRepository = new();
        }
        public void AdicionarAeronave(Aeronave aeronave)
        {
            aeronaveRepository.AdicionarAeronave(aeronave);
        }
        public Aeronave BuscarPorId(int id)
        {
            return aeronaveRepository.BuscarPorId(id);
        }
        public List<Aeronave> ListarAeronaves()
        {
            return aeronaveRepository.ListarAeronaves();
        }

        public void ExportarDelimitado()
        {
            List<Aeronave> listaAeronaves = ListarAeronaves();

            string conteudoArquivo = string.Empty;

            foreach (var aeronave in listaAeronaves)
                conteudoArquivo += $"{aeronave.FormatarParaDelimitado()}";

            string nomeArquivo = $"Aeronaves_{DateTimeOffset.Now.ToUnixTimeSeconds()}.txt";

            ManipuladoresDeArquivos.ExportarDelimitado(nomeArquivo, conteudoArquivo);
        }
        public void RemoverAeronave(Aeronave aeronave)
        {
            aeronaveRepository.RemoverAeronave(aeronave);
        }
    }
}