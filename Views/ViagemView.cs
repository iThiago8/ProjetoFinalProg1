using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using ProjetoFinalProg1.Controllers;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Repositories;

namespace ProjetoFinalProg1.Views
{
    public class ViagemView
    {
        private ViagemController viagemController;
        private AeronaveController aeronaveController;
        private AeroportoController aeroportoController;
        public ViagemView()
        {
            aeroportoController = new();
            aeronaveController = new();
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
            bool loop;

            do {
                Console.WriteLine("Qual o ID da aeronave que fará a viagem?");

                bool conversaoSucedida = int.TryParse(Console.ReadLine(), out int idAeronave);

                if (conversaoSucedida)
                {
                    viagem.Aeronave = aeronaveController.BuscarPorId(idAeronave);

                    if (viagem.Aeronave != null) 
                        loop = false;
                    else
                    {
                        Console.WriteLine("Não foi encontrado nenhuma aeronave com esse identificador!");
                        loop = true;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente!");
                    loop = true;
                }
            } while (loop);

            do {
                Console.WriteLine("Qual o ID do aeroporto de origem?");

                bool conversaoSucedida = int.TryParse(Console.ReadLine(), out int idAeroportoDeOrigem);

                if (conversaoSucedida)
                {
                    viagem.AeroportoDeOrigem = aeroportoController.BuscarPorId(idAeroportoDeOrigem);

                    if (viagem.AeroportoDeOrigem != null) 
                        loop = false;
                    else
                    {
                        Console.WriteLine("Não foi encontrado nenhum aeroporto com esse identificador!");
                        loop = true;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente!");
                    loop = true;
                }

            } while (loop);

            do {
                Console.WriteLine("Qual o ID do aeroporto de destino?");

                bool conversaoSucedida = int.TryParse(Console.ReadLine(), out int idAeroportoDeDestino);

                if (conversaoSucedida)
                {
                    viagem.AeroportoDeDestino = aeroportoController.BuscarPorId(idAeroportoDeDestino);

                    if (viagem.AeroportoDeDestino != null) 
                        loop = false;
                    else
                    {
                        Console.WriteLine("Não foi encontrado nenhum aeroporto com esse identificador!");
                        loop = true;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente!");
                    loop = true;
                }
            } while (loop);
            
            string formatoDateTime = "dd/MM/yyyy HH:mm";
            do {
                Console.WriteLine("Qual será a data e hora de saída? (formato: dd/MM/yyyy HH:mm)");

                bool conversaoSucedida = DateTime.TryParseExact(Console.ReadLine(), formatoDateTime,CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime horaDeSaida);

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

            do {
                Console.WriteLine("Qual será a data e hora prevista de chegada? (formato: dd/MM/yyyy HH:mm)");

                bool conversaoSucedida = DateTime.TryParseExact(Console.ReadLine(), formatoDateTime,CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime horaPrevistaDeChegada);

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
                Console.WriteLine($"Aeronave: {viagem.Aeronave.IdAeronave}");
                Console.WriteLine($"Aeropoorto de origem: {viagem.AeroportoDeOrigem.NomeAeroporto}");
                Console.WriteLine($"Aeropoorto de destino: {viagem.AeroportoDeDestino.NomeAeroporto}");
                Console.WriteLine($"Hora de saída prevista: {viagem.HoraDeSaida}");
                Console.WriteLine($"Hora de chegada prevista: {viagem.HoraPrevistaDeChegada}");

                viagemController.GeraListaPoltronas(viagem);
                int numeroPoltronasOcupadas = 0;
                int numeroPoltronasLivres = 0;
                foreach (var poltrona in viagem.Poltronas)
                {
                    if (poltrona.Livre)
                        numeroPoltronasLivres++;
                    else
                        numeroPoltronasOcupadas++;
                }

                Console.WriteLine($"Nº de Poltronas livres: {numeroPoltronasLivres}");
                Console.WriteLine($"Nº de Poltronas ocupadas: {numeroPoltronasOcupadas}");

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
                //Console.WriteLine($"Numero de poltronas: {viagem.NumeroDePoltronas}");
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