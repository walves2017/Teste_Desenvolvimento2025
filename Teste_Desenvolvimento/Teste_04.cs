using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;

class Teste_04
{
    public static void Executar()
    {
        Console.WriteLine("Escolha a fonte de dados:");
        Console.WriteLine("1 - JSON");
        Console.WriteLine("2 - XML");
        Console.WriteLine("3 - Ambos");
        Console.WriteLine("-----------------------------");
        string? escolha = Console.ReadLine();

        List<double> faturamentoJson = new List<double>();
        List<double> faturamentoXml = new List<double>();

        if (escolha == "1" || escolha == "3")
        {
            string jsonPath = "dados.json";
            faturamentoJson = CarregarFaturamentoJson(jsonPath);
            Console.WriteLine($"Dados JSON carregados: {faturamentoJson.Count} registros.");
        }

        if (escolha == "2" || escolha == "3")
        {
            string xmlPath = "dados.xml";
            faturamentoXml = CarregarFaturamentoXml(xmlPath);
            Console.WriteLine($"Dados XML carregados: {faturamentoXml.Count} registros.");
        }

        var faturamentoTotal = faturamentoJson.Concat(faturamentoXml).ToList();
        var faturamentoValido = faturamentoTotal.Where(f => f > 0).ToList();

        if (faturamentoValido.Any())
        {
            double menorFaturamento = faturamentoValido.Min();
            double maiorFaturamento = faturamentoValido.Max();
            double mediaMensal = faturamentoValido.Average();
            int diasAcimaMedia = faturamentoTotal.Count(f => f > mediaMensal);

            Console.WriteLine($"Menor faturamento diário: {menorFaturamento:F2}");
            Console.WriteLine($"Maior faturamento diário: {maiorFaturamento:F2}");
            Console.WriteLine($"Número de dias acima da média mensal: {diasAcimaMedia}");
            Console.WriteLine("-----------------------------");
        }
        else
        {
            Console.WriteLine("Não há dados de faturamento válidos.");
            Console.WriteLine("-----------------------------");
        }

        var faturamentoEstados = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        double totalFaturamentoEstados = faturamentoEstados.Values.Sum();

        Console.WriteLine("\nPercentual de representação de cada estado:");
        foreach (var estado in faturamentoEstados)
        {
            double percentual = (estado.Value / totalFaturamentoEstados) * 100;
            Console.WriteLine($"{estado.Key}: {percentual:F2}%");
        }
    }

    static List<double> CarregarFaturamentoJson(string filePath)
    {
        List<double> valores = new List<double>();
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            var dados = JsonConvert.DeserializeObject<List<Faturamento>>(jsonData);
            valores = dados.Select(d => d.Valor).ToList();
        }
        else
        {
            Console.WriteLine($"Arquivo JSON não encontrado: {filePath}");
            Console.WriteLine("-----------------------------");
        }
        return valores;
    }

    static List<double> CarregarFaturamentoXml(string filePath)
    {
        List<double> valores = new List<double>();
        if (File.Exists(filePath))
        {
            XDocument xmlData = XDocument.Load(filePath);
            valores = xmlData.Descendants("row")
                             .Select(x => (double)x.Element("valor"))
                             .ToList();
        }
        else
        {
            Console.WriteLine($"Arquivo XML não encontrado: {filePath}");
            Console.WriteLine("-----------------------------");
        }
        return valores;
    }
}

class Faturamento
{
    public int Dia { get; set; }
    public double Valor { get; set; }
}



