using System;

namespace Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Menu();
        }

        public static void Menu()
        {
            Console.Clear();

            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Divisão");
            Console.WriteLine("4 - Multiplicação");
            Console.WriteLine("0 - Sair");

            Console.WriteLine("---------------");
            Console.Write("Selecione um valor: ");
            short res = short.Parse(Console.ReadLine());

            switch (res)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Sum();
                    break;
                case 2:
                    Subtracao();
                    break;
                case 3:
                    Divisao();
                    break;
                case 4:
                    Multiplicacao();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        public static void Sum()
        {
            Console.Clear();

            Console.Write("Primeiro valor: ");
            float num1 = float.Parse(Console.ReadLine());

            Console.Write("Segundo Valor: ");
            float num2 = float.Parse(Console.ReadLine().Replace(".", ","));

            float result = num1 + num2;

            Console.WriteLine("Soma de (" + num1 + "+" + num2 + ") = " + (num1 + num2));
            Console.WriteLine("Soma de (" + num1 + "+" + num2 + ") = " + result);
            Console.WriteLine($"Soma de ({num1}+{num2}) = {num1 + num2}");
            Console.WriteLine($"Soma de ({num1}+{num2}) = {result}");
            Console.ReadKey();

            Menu();
        }

        public static void Subtracao()
        {
            Console.Clear();
            Console.Write("Primeiro valor: ");
            float num1 = float.Parse(Console.ReadLine());

            Console.Write("Segndo valor: ");
            float num2 = float.Parse(Console.ReadLine());

            float result = num1 - num2;

            Console.WriteLine($"Subtração de ({num1}-{num2}) = {result}");
            Console.ReadKey();

            Menu();
        }

        public static void Divisao()
        {
            Console.Clear();

            Console.Write("Primeiro valor: ");
            float num1 = float.Parse(Console.ReadLine());

            Console.Write("Segundo valor: ");
            float num2 = float.Parse(Console.ReadLine());

            float result = num1 / num2;

            Console.WriteLine($"Divisão de ({num1}/{num2}) = {result}");
            Console.ReadKey();

            Menu();
        }

        public static void Multiplicacao()
        {
            Console.Clear();

            Console.Write("Primeiro valor: ");
            float num1 = float.Parse(Console.ReadLine());

            Console.Write("Segundo valor: ");
            float num2 = float.Parse(Console.ReadLine());

            float result = num1 * num2;

            Console.WriteLine($"Multiplicação ({num1}*{num2}) = {result}");
            Console.ReadKey();

            Menu();
        }

    
    }
}