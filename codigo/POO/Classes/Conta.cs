namespace POO.Classes
{
    public class Conta
    {
        public const decimal TAXA_DE_SERVICO = 0.1m;
        private Requisicao? requisicao;
        private Pedido? pedido;
        private Guid IdConta;
        public bool Aberta { get; private set; } = true;


        public Conta()
        {
            IdConta = Guid.NewGuid();
        }
        public Conta(Requisicao? requisicao, Pedido pedido, Guid idConta)
        {
            this.requisicao = requisicao;
            this.pedido = pedido;
            IdConta = idConta;
        }

        public decimal CalcularTotal()
        {
            var total = pedido.CalcularTotal();
            return total + total * TAXA_DE_SERVICO;
        }
        public decimal ExibirValorDividido()
        {
            var total = CalcularTotal();
            return total / requisicao?.GetQuantidadeDePessoas() ?? 1;
        }

        public bool FecharConta() => Aberta = false;

        public Cliente DadosCliente() => requisicao?.GetCliente() ?? throw new Exception("Cliente não existe");

        #region getsEsets
        public Requisicao? GetRequisicao() => requisicao;
        public void SetRequisicao(Requisicao requisicao) => this.requisicao = requisicao;
        public Guid GetContaId() => IdConta;
        public Pedido? GetPedido() => pedido;
        public void SetPedido(Pedido pedido) => this.pedido = pedido;

        #endregion
        public string GerarRelatorio()
        {
            return $"Total: {CalcularTotal()} | " + $"Total-Para-Cada-Pessoa: {ExibirValorDividido()} | " + 
                $"Total-De-Pessoas: {requisicao?.GetQuantidadeDePessoas()}";
        }
        public override string ToString()
        {
            return $"{GetContaId()} | NomeCliente : {DadosCliente().GetNome()}";
        }
    }
}
