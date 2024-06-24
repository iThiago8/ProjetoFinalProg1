using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalProg1.Utils
{
    public class ManipuladoresDeArquivos
    {
        private const string diretorio = @"C:\Users\411730\Documents\DocumentosDelimitados";
        public static void ExportarDelimitado(string nomeArquivo, string conteudoArquivo)
        {
            string caminhoArquivo = @$"{diretorio}\{nomeArquivo}";

            if (!Directory.Exists(diretorio))  
                Directory.CreateDirectory(diretorio);

            using StreamWriter streamWriter = File.CreateText(caminhoArquivo);
            streamWriter.Write(conteudoArquivo);

        }
    }
}