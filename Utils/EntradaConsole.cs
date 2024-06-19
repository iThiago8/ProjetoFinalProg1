using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalProg1.Utils
{
    public class EntradaConsole
    {
        public int LerNumeroInteiro()
        {
            bool conversaoSucedida;
            int numero;
            do {
                conversaoSucedida = int.TryParse(Console.ReadLine(), out numero);

                if (!conversaoSucedida)
                    Console.WriteLine("Entrada inválida! Tente novamente.");

            } while (!conversaoSucedida);

            return numero;
        }
    }
}