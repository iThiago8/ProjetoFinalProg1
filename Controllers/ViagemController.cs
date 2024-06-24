using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Repositories;
using ProjetoFinalProg1.Utils;

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

        public List<Poltrona> GeraListaPoltronas(Viagem viagem)
        {
            return viagemRepository.GeraListaPoltronas(viagem);
        }
        public Viagem? BuscarPorId(int? id)
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
        public void ExportarDelimitado()
        {
            List<Viagem> listaViagens = ListarViagens();

            string conteudoArquivo = string.Empty;

            foreach (var viagem in listaViagens)
                conteudoArquivo += $"{viagem.FormatarParaDelimitado()}";

            string nomeArquivo = $"Viagens_{DateTimeOffset.Now.ToUnixTimeSeconds()}.txt";

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

                    if (!viagemRepository
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