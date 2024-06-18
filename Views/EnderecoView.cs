using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Controllers;

namespace ProjetoFinalProg1.Views
{
    public class EnderecoView
    {
        private EnderecoController enderecoController;
        public EnderecoView()
        {
            enderecoController = new();
            Init();
        }
        public void Init()
        {
        }
        public Endereco? CadastrarEndereco() 
        {
            Endereco endereco = new();
            
            Console.WriteLine("Rua:");
            endereco.Rua = Console.ReadLine();
            
            Console.WriteLine("Número:");
            endereco.Numero = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Bairro:");
            endereco.Bairro = Console.ReadLine();

            Console.WriteLine("Cidade:");
            endereco.Cidade = Console.ReadLine();

            Console.WriteLine("Estado:");
            endereco.Estado = Console.ReadLine();

            Console.WriteLine("País:");
            endereco.Pais = Console.ReadLine();

            Console.WriteLine("CEP:");
            endereco.CEP = Console.ReadLine();

            try 
            {
                enderecoController.AdicionarEndereco(endereco);
                Console.WriteLine("O endereço foi criado com sucesso!");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);

                return endereco;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Ocorreu um erro. Tente novamente mais tarde.");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(true);
            }

            return null;
        }
    }
}