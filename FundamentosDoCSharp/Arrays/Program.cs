using System;

namespace Arrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            Arrays();
        }

        public static void Arrays()
        {
            // Inicialização de Arrays
            var meuArray = new int[5];
            int[] meuArray1 = new int[5];
            int[] meuArray2 = new int[]{1, 2, 3, 4, 5};
            Teste[] testes = new Teste[]{new Teste()};
            testes[0] = new Teste() { Id = 100, Nome = "Fulano da Silva" };

            meuArray[0] = 10;
            Console.WriteLine(testes[0].Id);

            for (int i = 0; i < meuArray2.Length; i++)
            {
                Console.WriteLine(meuArray2[i]);
            }
            Console.WriteLine();

            foreach (var teste in testes)
            {
                Console.WriteLine(teste.Id);
                Console.WriteLine(teste.Nome);
            }
        }

        public struct Teste
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }
    }
}