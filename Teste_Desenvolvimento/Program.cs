using System;

namespace Teste_Desenvolvimento
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Executar teste_01");
                Console.WriteLine("2 - Executar teste_02");
                Console.WriteLine("3 - Executar teste_03");
                Console.WriteLine("4 - Executar teste_04");
                Console.WriteLine("5 - Executar teste_05");
                Console.WriteLine("F1 - Sair");

                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.F1)
                {
                    Console.WriteLine("Saindo do programa...");
                    break;
                }

                string? input = key.KeyChar.ToString();

                if (input == "1")
                {
                    Teste_01.Executar();
                }
                else if (input == "2")
                {
                    Teste_02.Executar();
                }
                else if (input == "3")
                {
                    Teste_03.Executar();
                }
                else if (input == "4")
                {
                    Teste_04.Executar();
                }
                else if (input == "5")
                {
                    Teste_05.Executar();
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }
            }
        }
    }
}


