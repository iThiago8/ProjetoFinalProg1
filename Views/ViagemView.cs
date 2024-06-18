using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Controllers;
using ProjetoFinalProg1.Models;

namespace ProjetoFinalProg1.Views
{
    public class ViagemView
    {
        private ViagemController viagemController;
        public ViagemView()
        {
            viagemController = new();
            Init();
        }
        public void Init()
        {
            Console.WriteLine("");
            Console.WriteLine("*****************");
            Console.WriteLine("MENU DE VIAGENS");
            Console.WriteLine("*****************");
            Console.WriteLine("");

            Console.WriteLine("O que deseja fazer?");

            bool loop = true;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Cadastrar uma nova viagem");
                Console.WriteLine("2 - Buscar uma viagem");
                Console.WriteLine("3 - Listar todas as viagens");
                Console.WriteLine("4 - Remover uma viagem");
                Console.WriteLine("0 - SAIR");
                Console.WriteLine("");


                int escolha;

                try
                {
                    Console.WriteLine("Digite um número: ");
                    escolha = Convert.ToInt16(Console.ReadLine());
                    switch (escolha)
                    {
                        case 1:
                            CadastrarViagem();
                            break;

                        case 2:
                            BuscarViagens();
                            break;

                        case 3:
                            ListarViagens();
                            break;

                        case 4:
                            RemoverViagem();
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
                }

            } while (loop);
        }

        public void CadastrarViagem()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("CADASTRAR VIAGEM");
            Console.WriteLine("****************");
            Console.WriteLine("");

            Viagem viagem = new();
            Console.WriteLine("Qual o numero de poltronas da viagem?");
            
            bool loop = true;
            do {
                try
                {
                    int NumeroDePoltronas = Convert.ToInt16(Console.ReadLine());
                    viagem.NumeroDePoltronas = NumeroDePoltronas;

                    loop = false;
                }
                catch
                {
                    Console.WriteLine("Entrada inválida. Tente novamente!");
                }
            } while (loop);

            try 
            {
                viagemController.AdicionarViagem(viagem);
                Console.WriteLine("A viagem foi criada com sucesso!");

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
        public void BuscarViagens()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("BUSCAR VIAGENS");
            Console.WriteLine("****************");
            Console.WriteLine("");

            bool loop = true; 
            int id = 0;
            do {
                Console.WriteLine("Digite o ID da viagem que deseja buscar");
                try
                {
                    id = Convert.ToInt16(Console.ReadLine());
                    loop = false;
                }
                catch
                {
                    Console.WriteLine("Entrada inválida! Tente novamente.");
                }
            } while (loop);

            Viagem viagem = viagemController.BuscarPorId(id);

            if (viagem != null)
            {
                Console.WriteLine($"ID da viagem: {viagem.IdViagem}");
                Console.WriteLine($"Numero de poltronas: {viagem.NumeroDePoltronas}");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true); 
            }
            else
            {
                Console.WriteLine("Não foi encontrada nenhuma viagem com esse ID");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);
            }
        }
        public void ListarViagens()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("LISTAR VIAGENS");
            Console.WriteLine("****************");
            Console.WriteLine("");

            List<Viagem> viagens = viagemController.ListarViagens();

            if (viagens == null || viagens.Count == 0)
            {
                Console.WriteLine("Não foram cadastradas nenhuma viagem!");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);
                
                return;            
            }

            foreach (var viagem in viagens)
            {
                Console.WriteLine($"ID da viagem: {viagem.IdViagem}");
                Console.WriteLine($"Numero de poltronas: {viagem.NumeroDePoltronas}");
                Console.WriteLine("------------------------------");
            }
            
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey(true);
        }
        public void RemoverViagem()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("REMOVER AERONAVE");
            Console.WriteLine("****************");
            Console.WriteLine("");

            int id = 0;
            bool loop;
            do {
                Console.WriteLine("Digite o id da viagem que deseja remover:");
                try
                {
                    id = Convert.ToInt16(Console.ReadLine());
                    loop = false;
                }
                catch 
                {
                    Console.WriteLine("Entrada inválida. Tente novamente!");
                    loop = true;
                }

            } while (loop);

            try
            {
                Viagem viagemRemover = viagemController.BuscarPorId(id);
                viagemController.RemoverViagem(viagemRemover);
                Console.WriteLine("Viagem removida com sucesso!");
                
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