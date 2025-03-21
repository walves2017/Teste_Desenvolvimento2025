using System;

class Teste_05
{
    public static void Executar()
    {
        Console.Write("Digite uma string para inverter: ");
        Console.WriteLine("-----------------------------");
        string input = Console.ReadLine();

        string inverted = InverterString(input);

        Console.WriteLine($"String invertida: {inverted}");
        Console.WriteLine("-----------------------------");
    }

    static string InverterString(string str)
    {
        char[] caracteres = new char[str.Length];

        for (int i = 0; i < str.Length; i++)
        {
            caracteres[i] = str[str.Length - 1 - i];
        }
        return new string(caracteres);
    }
}
