using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Repositories;
using ProjetoFinalProg1.Utils;

namespace ProjetoFinalProg1.Controllers
{
    public class AeroportoController
    {
        private AeroportoRepository aeroportoRepository;
        public AeroportoController()
        {
            aeroportoRepository = new();
        }
        public void CadastrarAeroporto(Aeroporto aeroporto)
        {
            aeroportoRepository.CadastrarAeroporto(aeroporto);
        }

        public Aeroporto BuscarPorId(int id)
        {
            return aeroportoRepository.BuscarPorId(id);
        }
        public List<Aeroporto> ListarAeroportos()
        {
            return aeroportoRepository.ListarAeroportos();
        }
        public void RemoverAeroporto(Aeroporto aeroporto)
        {
            aeroportoRepository.RemoverAeroporto(aeroporto);
        }
        public void ExportarDelimitado()
        {

            List<Aeroporto> listaAeroportos = ListarAeroportos();

            string conteudoArquivo = string.Empty;

            foreach (var aeroporto in listaAeroportos)
                conteudoArquivo += $"{aeroporto.FormatarParaDelimitado()}";

            string nomeArquivo = $"Aeroportos_{DateTimeOffset.Now.ToUnixTimeSeconds()}.txt";

            ManipuladoresDeArquivos.ExportarDelimitado(nomeArquivo, conteudoArquivo);
        }

    }
}