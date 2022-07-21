using System;

namespace Strings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            // StringGuid();
            // InterpolacaoString();
            // ComparacaoString();
            // StartsWithEndsWith();
            // StringEquals();
            // StringIndex();
            MetodosAdicionais();
        }

        public static void StringGuid()
        {
            var id = Guid.NewGuid();

            Console.WriteLine(id.ToString().Substring(0, 8));
            Console.WriteLine(new Guid(id.ToString()));
        }

        public static void InterpolacaoString()
        {
            decimal preco = 10.30m;
            string texto = "O preço é " + preco + " apenas na promoção";
            string texto1 = string.Format("O preço é {0} apenas na promoção");
            string texto2 = $"O preço é {preco} apena na promoção";

            Console.WriteLine(texto);
            Console.WriteLine(texto1);
            Console.WriteLine(texto2);
        }

        public static void ComparacaoString()
        {
            Console.WriteLine("Utilizando (CompareTo, Contains)\n");
            string texto = "Testando";

            // Utilizando o ComprateTo
            Console.WriteLine($"{texto} = Testando {texto.CompareTo("Testando")}");
            Console.WriteLine($"{texto} = testando {texto.CompareTo("testando")}");

            Console.WriteLine();

            // Utilizando o Contains
            Console.WriteLine($"{texto} = Testando {texto.Contains("Testando")}");
            Console.WriteLine($"{texto} = testando {texto.Contains("testando")}");
            Console.WriteLine("\nIgnorando o caseSensitive (StringComparison.OrdinalIgnoreCase)");
            Console.WriteLine($"{texto} = testando {texto.Contains("testando", StringComparison.OrdinalIgnoreCase)}");
        }

        public static void StartsWithEndsWith()
        {
            Console.WriteLine("Utilizando (StartsWith, EndsWith)\n");
            string texto = "Testando";

            Console.WriteLine("StartsWith\n");
            Console.WriteLine($"{texto} começa com (T): {texto.StartsWith("T")}");
            Console.WriteLine($"{texto} começa com (t): {texto.StartsWith("t")}");
            Console.WriteLine($"\nIgnorando caseSensitive\n{texto} começa com (t): {texto.StartsWith("t", StringComparison.OrdinalIgnoreCase)}");

            Console.WriteLine("EndsWith\n");
            Console.WriteLine($"{texto} termina com (o): {texto.EndsWith("o")}");
            Console.WriteLine($"{texto} termina com (O): {texto.EndsWith("O")}");
            Console.WriteLine($"\nIgnorando caseSensitive\n{texto} termina com (O): {texto.EndsWith("O", StringComparison.OrdinalIgnoreCase)}");
        }

        public static void StringEquals()
        {
            Console.WriteLine("Equals\n");
            string texto = "Testando";

            Console.WriteLine($"{texto} = (Testando): {texto.Equals("Testando")}");
            Console.WriteLine($"{texto} = (testando): {texto.Equals("testando")}");
            Console.WriteLine($"\nIgnorado caseSesitive\n{texto} = (testando): {texto.Equals("testando", StringComparison.OrdinalIgnoreCase)}");
        }

        public static void StringIndex()
        {
            Console.WriteLine("IndexOf, LastIndexOf");
            string texto = "Esse texto é um teste";

            Console.WriteLine($"Primeira apresentação do (e): {texto.IndexOf("e")}");
            Console.WriteLine($"Ultima apresentação do (e): {texto.LastIndexOf("e")}");
            Console.WriteLine($"Selecionando o Segundo item da String {texto[1]}");
        }

        public static void MetodosAdicionais()
        {
            string texto = "Esse é um texto de exemplo";

            Console.WriteLine($"Texto original \n{texto}");
            Console.WriteLine();
            Console.WriteLine($"--Convertendo texto todo para Maiusculo: \n{texto.ToUpper()}");
            Console.WriteLine($"--Convertendo o texto todo para Minusculo: \n{texto.ToLower()}");
            Console.WriteLine();
            Console.WriteLine($"--Inserindo item dentro do texto: \n{texto.Insert(9, " OLA")}");
            Console.WriteLine();
            Console.WriteLine($"--Removendo item do texto: \n{texto.Remove(0, 4)}");
            Console.WriteLine($"Tamanho do texto: {texto.Length}");
        }
    }
}