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
        public string ImportarDelimitado(string filePath, string delimiter)
        {
            bool resultado = true;
            string msgRetorno = string.Empty;
            int contadorLinhasSucesso = 0;
            int contadorLinhasErro = 0;
            int contadorLinhasTotais = 0;

            try
            {
                if (!File.Exists(filePath))
                    return "ERRO: Arquivo de importação não encontrado.";

                using StreamReader sr = new(filePath);

                string line = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    contadorLinhasTotais++;

                    if (!aeroportoRepository
                        .ImportarDelimitado(line, delimiter))
                    {
                        resultado = false;
                        contadorLinhasErro++;
                    }
                    else
                    {
                        contadorLinhasSucesso++;
                    }
                }
            }
            catch (Exception ex)
            {
                msgRetorno = $"ERRO: {ex.Message}";
            }

            if (resultado)
                msgRetorno += "\nDados importados com sucesso";
            else
                msgRetorno += "\nDados parcialmente importados";

            msgRetorno += $"\nTotal de linhas: {contadorLinhasTotais}";
            msgRetorno += $"\nSucesso: {contadorLinhasSucesso}";
            msgRetorno += $"\nErro: {contadorLinhasErro}";

            return msgRetorno;
        }

    }
}