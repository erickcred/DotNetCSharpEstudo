using System;
using System.Globalization;

namespace Moedas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            // TiposParaMoedas();
            // FormatandoMoedas();
            ArredondarValores();

        }

        public static void TiposParaMoedas()
        {
            decimal valor = 10.25m;
            
            Console.WriteLine(valor);
        }

        public static void FormatandoMoedas()
        {
            decimal valor = 10536.25m;

            CultureInfo enUs = new CultureInfo("en-US");
            CultureInfo local = CultureInfo.CurrentCulture;

            Console.WriteLine($"Brasil: {valor.ToString(CultureInfo.CreateSpecificCulture("pt-BR"))}");
            Console.WriteLine($"Estados Unidos: {valor.ToString("C", enUs)}");
            Console.WriteLine($"Local: {valor.ToString(local)}");
            Console.WriteLine($"Formataçào da maquina: {valor.ToString("C")}");
            Console.WriteLine($"Mostrando somente o numero sem Cifrão PtBr: {valor.ToString("N", local)}");
            Console.WriteLine($"Mostrando somente o numero sem Cifrão Us: {valor.ToString("N", enUs)}");
        }

        public static void ArredondarValores()
        {
            decimal valor = 10.45m;

            decimal absoluto = Math.Abs(valor);
            decimal arredondar = Math.Round(valor);
            decimal paracima = Math.Ceiling(valor);
            decimal parabaixo = Math.Floor(valor);

            Console.WriteLine($"valor original: {valor}");
            Console.WriteLine();

            Console.WriteLine($"valor absoluto: {absoluto.ToString("C")}");
            Console.WriteLine($"valor arredondado: {arredondar.ToString("C")}");
            Console.WriteLine($"valor para cima: {paracima.ToString("C")}");
            Console.WriteLine($"valor para baixo: {parabaixo.ToString("C")}");
        }
    }
}