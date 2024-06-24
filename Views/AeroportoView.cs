using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Controllers;

namespace ProjetoFinalProg1.Views
{
    public class AeroportoView
    {
        private AeroportoController aeroportoController;
        private EnderecoView enderecoView;
        public AeroportoView()
        {
            enderecoView = new EnderecoView();
            aeroportoController = new AeroportoController();
            this.Init();
        }
        public void Init()
        {
            Console.WriteLine("");
            Console.WriteLine("*****************");
            Console.WriteLine("MENU DE AEROPORTOS");
            Console.WriteLine("*****************");
            Console.WriteLine("");

            Console.WriteLine("O que deseja fazer?");

            bool loop = true;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Cadastrar um novo aeroporto");
                Console.WriteLine("2 - Buscar um aeroporto");
                Console.WriteLine("3 - Listar todos os aeroportos");
                Console.WriteLine("4 - Remover um aeroporto");
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
                            CadastrarAeroporto();
                            break;

                        case 2:
                            BuscarAeroportos();
                            break;

                        case 3:
                            ListarAeroportos();
                            break;

                        case 4:
                            RemoverAeroporto();
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
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Entrada inválida! Tente novamente.");
                }

            } while (loop);
        }

        public void CadastrarAeroporto()
        {
            Console.WriteLine("");
            Console.WriteLine("********************");
            Console.WriteLine("CADASTRAR AEROPORTOS");
            Console.WriteLine("********************");
            Console.WriteLine("");

            Aeroporto aeroporto = new();
            Console.WriteLine("Qual o nome do aeroporto?");
            aeroporto.NomeAeroporto = Console.ReadLine();

            aeroporto.Endereco = enderecoView.CadastrarEndereco();

            try
            {
                aeroportoController.CadastrarAeroporto(aeroporto);
                Console.WriteLine("O aeroporto foi criado com sucesso!");

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
        public void BuscarAeroportos()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("BUSCAR AEROPORTOS");
            Console.WriteLine("****************");
            Console.WriteLine("");

            bool loop = true;
            int id = 0;
            do
            {
                Console.WriteLine("Digite o ID do aeroporto que deseja buscar");
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

            Aeroporto aeroporto = aeroportoController.BuscarPorId(id);

            if (aeroporto != null)
            {
                Console.WriteLine($"ID do aeroporto: {aeroporto.IdAeroporto}");
                Console.WriteLine($"Nome do aeroporto: {aeroporto.NomeAeroporto}");
                Console.WriteLine($"Endereço do aeroporto: {aeroporto.Endereco}");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("Não foi encontrado nenhum aeroporto com esse ID");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);
            }
        }
        public void ListarAeroportos()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("LISTAR AEROPORTOS");
            Console.WriteLine("****************");
            Console.WriteLine("");

            List<Aeroporto> aeroportos = aeroportoController.ListarAeroportos();

            if (aeroportos == null || aeroportos.Count == 0)
            {
                Console.WriteLine("Não foi cadastrado nenhum aeroporto!");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);

                return;
            }

            foreach (var aeroporto in aeroportos)
            {
                Console.WriteLine($"ID do aeroporto: {aeroporto.IdAeroporto}");
                Console.WriteLine($"Nome do aeroporto: {aeroporto.NomeAeroporto}");
                Console.WriteLine($"Endereço do aeroporto: {aeroporto.Endereco}");
                Console.WriteLine("------------------------------");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey(true);
        }
        public void RemoverAeroporto()
        {
            Console.WriteLine("");
            Console.WriteLine("****************");
            Console.WriteLine("REMOVER AEROPORTO");
            Console.WriteLine("****************");
            Console.WriteLine("");

            int id = 0;
            bool loop;
            do
            {
                Console.WriteLine("Digite o id do aeroporto que deseja remover:");
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
                Aeroporto aeroportoRemover = aeroportoController.BuscarPorId(id);
                aeroportoController.RemoverAeroporto(aeroportoRemover);
                Console.WriteLine("Aeroporto removido com sucesso!");

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
        public void ExportarDelimitado()
        {
            try
            {
                aeroportoController.ExportarDelimitado();

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