using System;

class Teste_02
{
    public static void Executar()
    {
        Console.Write("Digite um número para verificar se pertence à sequência de Fibonacci: ");
        int numero = int.Parse(Console.ReadLine());

        if (EhFibonacci(numero))
        {
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
            Console.WriteLine("-----------------------------");
        }
        else
        {
            Console.WriteLine($"O número {numero} NÃO pertence à sequência de Fibonacci.");
            Console.WriteLine("-----------------------------");
        }
    }

    static bool EhFibonacci(int num)
    {
        if (num == 0 || num == 1) return true;

        int a = 0, b = 1, c = 0;

        while (c < num)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return c == num;
    }
}
