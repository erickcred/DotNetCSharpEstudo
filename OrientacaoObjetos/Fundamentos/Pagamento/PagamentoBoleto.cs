namespace Fundamentos.Pagamento
{
    public sealed class PagamentoBoleto : Pagamento
    {
        public PagamentoBoleto(DateTime vencimento, decimal valor) : base(vencimento, valor)
        {}

        public override void Pagar() 
        {
            Console.WriteLine("Pagando com Boleto");
        }

        public override void Pagar(string numero)
        {}

        public override void Pagar(string numero, DateTime vencimento)
        {}

    }

    // public class PagamentoAVista : PagamentoBoleto
    // {

    // }
}