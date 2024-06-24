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
        public void RemoverAeronave(Aeronave aeronave)
        {
            aeronaveRepository.RemoverAeronave(aeronave);
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
        public string ImportarDelimitado(string filePath, string delimiter)
        {
            bool resultado = true;
            string msgRetorno = string.Empty;
            int contadorLinhasSucesso = 0;
            int contadorLinhasErro = 0;
            int contadorLinhasTotal = 0;

            try
            {
                if (!File.Exists(filePath))
                    return "ERRO: Arquivo de importação não encontrado.";

                using StreamReader sr = new(filePath);

                string line = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    contadorLinhasTotal++;

                    if (!aeronaveRepository
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

            msgRetorno += $"\nTotal de linhas: {contadorLinhasTotal}";
            msgRetorno += $"\nSucesso: {contadorLinhasSucesso}";
            msgRetorno += $"\nErro: {contadorLinhasErro}";

            return msgRetorno;
        }
    }
}