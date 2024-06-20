using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ProjetoFinalProg1.Utils;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Controllers;

namespace ProjetoFinalProg1.Views
{
    public class AeronaveView
    {
        private AeronaveController aeronaveController;
        private EntradaConsole entradaConsole;
        public AeronaveView()
        {
            entradaConsole = new();
            aeronaveController = new();
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
                    Console.WriteLine("Digite um número: ");
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
            Console.WriteLine("");
            Console.WriteLine("*******************");
            Console.WriteLine("CADASTRAR AERONAVES");
            Console.WriteLine("*******************");
            Console.WriteLine("");

            Aeronave aeronave = new();
            Console.WriteLine("Qual o número de poltronas da aeronave?");
            int numeroDePoltronas = entradaConsole.LerNumeroInteiro();
            aeronave.NumeroDePoltronas = numeroDePoltronas;

            try 
            {
                aeronaveController.AdicionarAeronave(aeronave);
                Console.WriteLine("A aeronave foi criada com sucesso!");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Ocorreu um erro. Tente novamente mais tarde.");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);
            }
        }
        public void BuscarAeronaves()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("BUSCAR AERONAVES");
            Console.WriteLine("****************");
            Console.WriteLine("");

            Console.WriteLine("Digite o ID da aeronave que deseja buscar");
            int id = entradaConsole.LerNumeroInteiro();

            Aeronave aeronave = aeronaveController.BuscarPorId(id);

            if (aeronave != null)
            {
                Console.WriteLine(aeronave.ToString());

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true); 
            }
            else
            {
                Console.WriteLine("Não foi encontrada nenhuma aeronave com esse ID");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);
            }
        }
        public void ListarAeronaves()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("LISTAR AERONAVES");
            Console.WriteLine("****************");
            Console.WriteLine("");

            List<Aeronave> aeronaves = aeronaveController.ListarAeronaves();

            if (aeronaves == null || aeronaves.Count == 0)
            {
                Console.WriteLine("Não foram cadastradas nenhuma aeronave!");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);
                
                return;            
            }

            foreach (var aeronave in aeronaves)
            {
                Console.WriteLine($"ID da aeronave: {aeronave.IdAeronave}");
                Console.WriteLine($"Numero de poltronas: {aeronave.NumeroDePoltronas}");
                Console.WriteLine("------------------------------");
            }
            
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey(true);
        }
        public void RemoverAeronave()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("REMOVER AERONAVE");
            Console.WriteLine("****************");
            Console.WriteLine("");

            int id = entradaConsole.LerNumeroInteiro();

            try
            {
                Aeronave aeronaveRemover = aeronaveController.BuscarPorId(id);
                aeronaveController.RemoverAeronave(aeronaveRemover);
                Console.WriteLine("Aeronave removida com sucesso!");
                
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true); 
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro. Tente novamente mais tarde.");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);
            }
        }

    }
}