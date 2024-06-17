using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Controllers;

namespace ProjetoFinalProg1.Views
{
    public class AeronaveView
    {
        private AeronaveController aeronaveController;

        public AeronaveView()
        {
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
            Console.WriteLine("Qual o numero de poltronas da aeronave?");
            
            bool loop = true;
            do {
                try
                {
                    int NumeroDePoltronas = Convert.ToInt16(Console.ReadLine());
                    aeronave.NumeroDePoltronas = NumeroDePoltronas;

                    loop = false;
                }
                catch
                {
                    Console.WriteLine("Entrada inválida. Tente novamente!");
                }
            } while (loop);

            try 
            {
                aeronaveController.AdicionarAeronave(aeronave);
                Console.WriteLine("A aeronave foi criada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Ocorreu um erro. Tente novamente mais tarde.");
            }
        }
        public void BuscarAeronaves()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("BUSCAR AERONAVES");
            Console.WriteLine("****************");
            Console.WriteLine("");

            bool loop = true; 
            int id = 0;
            do {
                Console.WriteLine("Digite o ID da aeronave que deseja buscar");
                try
                {
                    id = Convert.ToInt16(Console.ReadLine());
                    loop = false;
                }
                catch
                {
                    Console.WriteLine("Algo deu errado! Tente novamente.");
                }
            } while (loop);

            Aeronave aeronave = aeronaveController.BuscarPorId(id);

            if (aeronave != null)
            {
                Console.WriteLine($"ID da aeronave: {aeronave.IdAeronave}");
                Console.WriteLine($"Numero de poltronas: {aeronave.NumeroDePoltronas}");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true); 
            }
            else
            {
                Console.WriteLine("Não foi encontrada nenhuma aeronave com esse ID");
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
                return;            
            }

            foreach (var aeronave in aeronaves)
            {
                aeronave.ToString();
            }
        }
        public void RemoverAeronave()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("REMOVER AERONAVE");
            Console.WriteLine("****************");
            Console.WriteLine("");

            bool loop = true;
            do {
                int IdAeronave;
                Console.WriteLine("Digite o id da aeronave que deseja remover:");
                try
                {
                    IdAeronave = Convert.ToInt16(Console.ReadLine());
                    //Aeronave aeronaveRemover = aeronaveController.BuscarPorId(IdAeronave);

                    Console.WriteLine("");
                }
                catch 
                {
                    Console.WriteLine("Entrada inválida. Tente novamente!");
                    loop = true;
                }

            } while (loop);
        }

    }
}