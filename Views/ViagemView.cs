using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using ProjetoFinalProg1.Controllers;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Repositories;
using ProjetoFinalProg1.Utils;

namespace ProjetoFinalProg1.Views
{
    public class ViagemView
    {
        private ViagemController viagemController;
        private AeronaveController aeronaveController;
        private AeroportoController aeroportoController;
        private readonly EntradaConsole entradaConsole;
        public ViagemView()
        {
            entradaConsole = new();
            aeroportoController = new();
            aeronaveController = new();
            viagemController = new();
            Init();
        }
        public void Init()
        {

            bool loop = true;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("*****************");
                Console.WriteLine("MENU DE VIAGENS");
                Console.WriteLine("*****************");
                Console.WriteLine("");

                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("");
                Console.WriteLine("1 - Cadastrar uma nova viagem");
                Console.WriteLine("2 - Buscar uma viagem");
                Console.WriteLine("3 - Listar todas as viagens");
                Console.WriteLine("4 - Remover uma viagem");
                Console.WriteLine("5 - Exportar relatório delimitado");
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
                        
                        case 5: 
                            ExportarDelimitado();
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
            bool loop;

            do
            {
                Console.WriteLine("Qual o ID da aeronave que fará a viagem?");
                int idAeronave = entradaConsole.LerNumeroInteiro();
                viagem.Aeronave = aeronaveController.BuscarPorId(idAeronave);

                if (viagem.Aeronave != null)
                    loop = false;
                else
                {
                    Console.WriteLine("Não foi encontrado nenhuma aeronave com esse identificador!");
                    loop = true;
                }
            } while (loop);

            do
            {
                Console.WriteLine("Qual o ID do aeroporto de origem?");
                int idAeroportoDeOrigem = entradaConsole.LerNumeroInteiro();
                viagem.AeroportoDeOrigem = aeroportoController.BuscarPorId(idAeroportoDeOrigem);

                if (viagem.AeroportoDeOrigem != null)
                    loop = false;
                else
                {
                    Console.WriteLine("Não foi encontrado nenhum aeroporto com esse identificador!");
                    loop = true;
                }
            } while (loop);

            do
            {
                Console.WriteLine("Qual o ID do aeroporto de destino?");
                int idAeroportoDeDestino = entradaConsole.LerNumeroInteiro();
                viagem.AeroportoDeDestino = aeroportoController.BuscarPorId(idAeroportoDeDestino);

                if (viagem.AeroportoDeDestino != null)
                    loop = false;
                else
                {
                    Console.WriteLine("Não foi encontrado nenhum aeroporto com esse identificador!");
                    loop = true;
                }
            } while (loop);

            string formatoDateTime = "dd/MM/yyyy HH:mm";
            do
            {
                Console.WriteLine("Qual será a data e hora de saída? (formato: dd/MM/yyyy HH:mm)");

                bool conversaoSucedida = DateTime.TryParseExact(Console.ReadLine(), formatoDateTime, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime horaDeSaida);

                if (conversaoSucedida)
                {
                    viagem.HoraDeSaida = horaDeSaida;
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente!");
                    loop = true;
                }
            } while (loop);

            do
            {
                Console.WriteLine("Qual será a data e hora prevista de chegada? (formato: dd/MM/yyyy HH:mm)");

                bool conversaoSucedida = DateTime.TryParseExact(Console.ReadLine(), formatoDateTime, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime horaPrevistaDeChegada);

                if (conversaoSucedida)
                {
                    viagem.HoraPrevistaDeChegada = horaPrevistaDeChegada;
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente!");
                    loop = true;
                }
            } while (loop);

            viagem.Poltronas = viagemController.GeraListaPoltronas(viagem);

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

            Console.WriteLine("Digite o ID da viagem que deseja buscar");
            int? id = entradaConsole.LerNumeroInteiro();

            Viagem? viagem = viagemController.BuscarPorId(id);

            if (viagem != null)
            {
                Console.WriteLine(viagem.ToString());

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
                Console.WriteLine(viagem.ToString());
                Console.WriteLine("------------------------------");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey(true);
        }
        public void RemoverViagem()
        {
            Console.WriteLine("");
            Console.WriteLine("**************");
            Console.WriteLine("REMOVER VIAGEM");
            Console.WriteLine("**************");
            Console.WriteLine("");

            Console.WriteLine("Digite o id da viagem que deseja remover:");
            int id = entradaConsole.LerNumeroInteiro();

            Viagem? viagemRemover = viagemController.BuscarPorId(id);
            if (viagemRemover == null)
            {
                Console.WriteLine("Não foi encontrada nenhuma viagem com esse id!");

                Console.WriteLine("Pressione qualquer tecla para voltar ao menu de viagens...");
                Console.ReadKey(true);  
                return;
            }

            Console.WriteLine(viagemRemover.ToString());

            Console.WriteLine("Tem certeza que deseja remover a viagem acima?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            int confirmaRemocao = entradaConsole.LerNumeroInteiro();

            switch (confirmaRemocao)
            {
                case 1:
                    try
                    {
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
                    break;

                case 2:
                    Console.WriteLine("Cancelando operação...");
                    break;
                case 3:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        public void ExportarDelimitado()
        {
            try
            {
                viagemController.ExportarDelimitado();

                Console.WriteLine();
                Console.WriteLine("Arquivo exportado com sucesso!");
            }
            catch
            {
                Console.WriteLine("Houve uma falha ao exportar o arquivo. Favor tentar novamente mais tarde.");
            }
        }
    }
}