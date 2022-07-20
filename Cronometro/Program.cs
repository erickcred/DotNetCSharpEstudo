using System;

namespace Cronometro
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

            Console.WriteLine("S = Segundo (10s = 10 segundos)");
            Console.WriteLine("M = Minuto (10m = 10 minutos)");
            Console.WriteLine("H = Horas (1h = 1 hora");
            Console.WriteLine("0 = Sair");
            Console.Write("Informe o tempo para o Cronometro! ");

            
            string dados = Console.ReadLine().ToLower();

            if (dados == "0")
                System.Environment.Exit(0);
            
            int time = int.Parse(dados.Substring(0, dados.Length - 1));
            char type = char.Parse(dados.Substring(dados.Length - 1));

            switch (type)
            {
                case 's':
                    PreStart(time); break;
                case 'm':
                    PreStart(time * 60); break;
                case 'h':
                    PreStart(time * 60 * 60); break;
                default:
                    Menu(); break;
            }
        }

        public static void PreStart(int time)
        {
            Console.Clear();
            Console.WriteLine("Ready ...");
            Thread.Sleep(1000);

            Console.Clear();
            Console.WriteLine("Set ..");
            Thread.Sleep(1000);
            
            Console.Clear();
            Console.WriteLine("Go...");
            Thread.Sleep(1000);
            Start(time);
        }

        public static void Start(int time)
        {
            int currentTime = 0;

            while (currentTime != time)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                Console.WriteLine(DateTime.Now);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Cronometro Finalizado!");
            Thread.Sleep(2500);
        }
    }
}