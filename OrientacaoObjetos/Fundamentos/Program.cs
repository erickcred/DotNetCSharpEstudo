using System;
using Fundamentos.Pagamento;

namespace Fundamentos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Pagamento.Pagamento pg = new Pagamento.Pagamento(DateTime.Parse("10/10/2022"), 1000.30m);

            pg.DataPagamento = DateTime.Parse("10/08/2022");

            Console.WriteLine(pg.DataPagamento.ToString("dd/MM/yyyy"));
            pg.Pagar();
            pg.Pagar("10101010");
            pg.Pagar("101010", DateTime.Parse("10/10/2022"));
        }
    }
}