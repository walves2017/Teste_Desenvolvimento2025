using System;
using System.Linq;

class Teste_03{
    public static void Executar()
    {
        double[] faturamentoDiario = { 1000, 1500, 780, 1200, 2500, 3000, 500, 0, 0, 2100, 1800, 900, 1350, 2700, 0, 1900, 2000, 0, 0, 1600, 1400, 2900, 3100, 2800, 3200, 1000, 1700, 2300, 0, 2600 };

        var diasComFaturamento = faturamentoDiario.Where(f => f > 0).ToArray();

        double menorFaturamento = diasComFaturamento.Min();
        double maiorFaturamento = diasComFaturamento.Max();
        double mediaMensal = diasComFaturamento.Average();

        int diasAcimaDaMedia = faturamentoDiario.Count(f => f > mediaMensal);
        Console.WriteLine($"Menor faturamento diário: {menorFaturamento}");
        Console.WriteLine($"Maior faturamento diário: {maiorFaturamento}");
        Console.WriteLine($"Número de dias com faturamento acima da média mensal: {diasAcimaDaMedia}");
        Console.WriteLine("-----------------------------");
    }
}