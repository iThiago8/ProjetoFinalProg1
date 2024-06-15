using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ProjetoFinalProg1.Controllers;

namespace ProjetoFinalProg1.Views
{
    public class AeronaveView
    {
        private AeronaveController aeronaveController;

        public AeronaveView()
        {
            Init();
        }

        public void Init()
        {
            Console.WriteLine("");
            Console.WriteLine("*****************");
            Console.WriteLine("MENU DE AERONAVES");
            Console.WriteLine("*****************");
            Console.WriteLine("");

            Console.WriteLine("O que deseja fazer?");

            bool loop = true;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Cadastrar uma nova aeronave");
                Console.WriteLine("2 - Buscar uma aeronave");
                Console.WriteLine("3 - Listar todas as aeronaves");
                Console.WriteLine("4 - Remover uma aeronave");
                Console.WriteLine("0 - SAIR");
                Console.WriteLine("");


                int escolha = -1;

                try
                {
                    Console.Write("Digite um número: ");
                    escolha = Convert.ToInt16(Console.ReadLine());
                    switch (escolha)
                    {
                        case 1:
                            CadastrarAeronave();
                            break;

                        case 2:
                            BuscarAeronaves();
                            break;

                        case 3:
                            ListarAeronaves();
                            break;

                        case 4:
                            RemoverAeronave();
                            break;

                        case 0:
                            Console.WriteLine("Voltando ao menu inicial..."); //Colocar um timer para sair 
                            loop = false;
                            break;

                        default:
                            Console.WriteLine("Opção inválida! Tente novamente!");
                            loop = true;
                            break;
                    }

                }
                catch
                {
                    Console.WriteLine("Entrada inválida! Tente novamente.");
                    escolha = -1;
                }

            } while (loop);
        }

        public void CadastrarAeronave()
        {
            Console.WriteLine("Menu cadastrar aeronave");
        }
        public void BuscarAeronaves()
        {
            Console.WriteLine("Menu buscar aeronaves");

        }
        public void ListarAeronaves()
        {
            Console.WriteLine("Menu listar aeronaves");

        }
        public void RemoverAeronave()
        {
            Console.WriteLine("Menu remover aeronave");

        }

    }
}