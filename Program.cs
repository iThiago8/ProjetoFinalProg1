
using ProjetoFinalProg1.Models;
using ProjetoFinalProg1.Views;

bool loop = true;
do {
    Console.WriteLine("");
    Console.WriteLine("************");
    Console.WriteLine("MENU INICIAL");
    Console.WriteLine("************");
    Console.WriteLine("");

    Console.WriteLine("1 - Aeronaves");
    Console.WriteLine("2 - Aeroportos");
    Console.WriteLine("3 - Viagens");
    Console.WriteLine("0 - SAIR");

    int escolha = -1;
    try
    {
        Console.WriteLine("Digite um número: ");
        escolha = Convert.ToInt16(Console.ReadLine());

        switch (escolha)
        {
            case 1: 
                AeronaveView aeronaveView = new();
                break;

            case 2:
                AeroportoView aeroportoView = new();
                break;
                
            case 3:
                ViagemView viagemView = new();
                break;
                
            case 0:
                Console.WriteLine("Saindo...");
                loop = false;
                break;

            default:
                Console.WriteLine("Opção inválida! Tente novamente.");
                break;
        }
    }
    catch
    {
        Console.WriteLine("Entrada inválida! Tente novamente.");
        loop = true;
    }
} while (loop);
