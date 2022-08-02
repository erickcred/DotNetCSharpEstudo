using System;

namespace EditorDeTextoHTML
{
    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Screen();
            WriteOptions();
        }

        private static void Screen()
        {
            Columns();
            Row();
            Columns();
        }

        private static void Columns()
        {
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");
        }

        private static void Row()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(10, 1);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3, 3); 
            Console.WriteLine("=| Selecione uma opção |=");
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(5, 6);
            Console.WriteLine("2 - Abrir Arquivo");
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("0 - Sair");


            try
            {
                Console.SetCursorPosition(3, 9);
                Console.Write("Opção: ");
                short inputOption = short.Parse(Console.ReadLine());

                HandleMenuOption(inputOption);

            } catch (FormatException error)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(3, 10);
                Console.WriteLine("Opção Invalida! \n (Somente numeros são aceitos).");
                Thread.Sleep(2500);
                Console.Clear();
                Show();
            }
        }

        public static void HandleMenuOption(short inputOption)
        {
            switch (inputOption)
                {
                    case 1: 
                        Editor.Show();
                        break;
                    case 2: 
                        Viewer.Show();
                        break;
                    case 0:
                        Console.SetCursorPosition(3, 10);
                        Console.WriteLine("Finalizado o programa.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        System.Environment.Exit(0);
                        break;
                    default: 
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(3, 10);
                        Console.WriteLine("Selecione somente uma das \n opções acima");
                        Thread.Sleep(2500);
                        Show(); break;
                }
        }

    }
}