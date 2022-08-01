namespace Fundamentos.Pagamento
{
    public class Pagamento
    {
        // Variaveis -> Propriedades
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }

        private DateTime dataPagamento;
        public DateTime DataPagamento
        {
            get { return dataPagamento; }
            set { dataPagamento = value; }
        }

        public string NumeroBoleto;

        public Pagamento(DateTime vencimento, decimal valor)
        {
            Vencimento = vencimento;
            Valor = valor;
        }

        // Funções -> Metodos
        public virtual void Pagar()
        {
            Console.WriteLine("Pagar");
        }

        public virtual void Pagar(string numero) 
        {
            Console.WriteLine("Pagar Cartão");
        }

        public virtual void Pagar(string numero, DateTime vencimento)
        {
            this.Pagar();
            Console.WriteLine("Pagar Boleto");
        }

        public virtual void Pagar(string numero, DateTime vencimento, bool pagarAposVencimento = false)
        {
            Console.WriteLine($"Pagar após o vencimento {pagarAposVencimento}");
        }

        private void ConsultarSaldoCartao(string numeroCartao)
        {

        }

        
    }
}