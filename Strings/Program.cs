using System;

namespace Strings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            // StringGuid();
            InterpolacaoString();
        }

        public static void StringGuid()
        {
            var id = Guid.NewGuid();
            id.ToString();

            Console.WriteLine(id.ToString().Substring(0, 8));
            Console.WriteLine(new Guid(id.ToString()));
        }

        public static void InterpolacaoString()
        {
            decimal preco = 10.30m;
            string texto = "O preço é " + preco + " apenas na promoção";
            string texto1 = string.Format("O preço é {0} apenas na promoção", preco);
            string texto2 = $"O preço é {preco} aprenas na promoção";

            Console.WriteLine(texto);
            Console.WriteLine(texto1);
            Console.WriteLine(texto2);
        }
    }
}