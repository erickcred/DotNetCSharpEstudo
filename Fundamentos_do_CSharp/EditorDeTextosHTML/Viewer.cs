using System;
using System.Text;
using System.Text.RegularExpressions;

namespace EditorDeTextoHTML
{
    public class Viewer
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            
            Console.WriteLine("Visualizador.");
            Start();
        }

        private static void Replace(StreamReader data)
        {
            Regex strong = new Regex(
                @"<\s*strong[^>]*>(.*?)<\s*/\s*strong>"
            );

            string[] words = data.ToString().Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(words[i].Substring(
                        words[i].IndexOf('>') + 1,
                        ((words[i].LastIndexOf('<') - 1) - words[i].LastIndexOf('>'))
                    ));
                    Console.Write(" ");
                } else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(words[i]);
                }
            }
        }

        private static void Start()
        {
            Console.WriteLine("Iforme o caminho do arquivo");
            string path = Console.ReadLine();

            using (StreamReader file = new StreamReader(path))
            {
                Console.Clear();

                Regex strong = new Regex(
                    @"<\s*strong[^>]*>(.*?)<\s*/\s*strong>"
                );

                string[] words = file.ReadToEnd().ToString().Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (strong.IsMatch(words[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            ((words[i].LastIndexOf('<') - 1) - words[i].IndexOf('>'))
                        ));
                        Console.Write(" ");
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(words[i]);
                        Console.Write(" ");
                    }
                }

                Console.ReadKey();
                Menu.Show();
            }
        }
    }
}