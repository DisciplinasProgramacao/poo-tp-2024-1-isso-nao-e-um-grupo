namespace POO.Classes
{
    public class Conta
    {
        public const decimal TAXA_DE_SERVICO = 0.1m;

        private Pedido? pedido;
        private Guid IdConta;
        public bool Aberta { get; private set; } = true;


        public Conta()
        {
            IdConta = Guid.NewGuid();
        }
        public Conta(Pedido pedido, Guid idConta)
        {
            this.pedido = pedido;
            IdConta = idConta;
        }

        public decimal CalcularTotal()
        {
            var total = pedido?.CalcularTotal() ?? 0;
            return total + total * TAXA_DE_SERVICO;
        }
        public decimal ExibirValorDividido(int TotalPessoas)
        {
            var total = CalcularTotal();
            return total / TotalPessoas;
        }

        public bool FecharConta() => Aberta = false;

        #region getsEsets

        public Guid GetContaId() => IdConta;
        public Pedido? GetPedido() => pedido;
        public void SetPedido(Pedido pedido) => this.pedido = pedido;

        #endregion
        public string GerarRelatorio(int qtdPessoas)
        {
            return $"Total: R$ {CalcularTotal()} | " + $"Total-Para-Cada-Pessoa: R$ {ExibirValorDividido(qtdPessoas)} | " +
                $"Total-De-Pessoas: {qtdPessoas}";
        }
    }
}
