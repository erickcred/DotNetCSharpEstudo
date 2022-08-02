using System;
using System.Text;

namespace EditorDeTextoHTML
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            Console.WriteLine("Modo Editor");
            Start();
        }

        private static void Start()
        {
            StringBuilder file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(System.Environment.NewLine);

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.Clear();

            Console.WriteLine("Gostaria de Salvar o arquivo? \nS - Sim | N - Não");
            char optionSave = Convert.ToChar(Console.ReadLine().ToLower());

            switch (optionSave)
            {
                case 's':
                    Save(file);
                    break;
                case 'n':
                    Console.WriteLine("O arquivo não foi salvo \nProcesso Finalizado, voltando para o Menu");
                    Thread.Sleep(2500);
                    Menu.Show();
                    break;
                default: 
                    Show();
                    break;
            }
        }

        private static void Save(StringBuilder file)
        {
            Console.Clear();
            Console.WriteLine("Informe o caminho para salvar o arquivo: \nCaso não seja selecionado um local será utilizado a raiz desse projeto.");
            
            string path = Console.ReadLine();

            if (path == "")
                path = @$"{Directory.GetCurrentDirectory()}\teste.txt";

            using (StreamWriter data = new StreamWriter(path))
            {
                data.Write(file);
            }
            Console.WriteLine();

            Console.WriteLine($"Arquivo salvo com sucesso em: \n{path}");
            Console.WriteLine("Voltando para o Menu:\n");
            Thread.Sleep(5500);
            Menu.Show();
        }
    }
}