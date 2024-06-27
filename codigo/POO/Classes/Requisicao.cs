namespace POO.Classes
{
    public class Requisicao
    {
        private DateTime dataDeEntrada;
        private DateTime? dataSaida;
        private Cliente dadosDoCliente;
        private Mesa? mesa;
        private int numeroDePessoas = 1;
        private Conta conta;
        public bool EstaSendoAtendida { get; private set; }

        public Requisicao(Cliente cliente, Mesa mesa, int numeroDePessoas, Conta? conta = null)
        {
            dataDeEntrada = DateTime.Now;
            dadosDoCliente = cliente;
            mesa.OcuparMesa();
            this.mesa = mesa;
            this.numeroDePessoas = numeroDePessoas;
            this.conta = conta != null ? conta : new Conta();
            EstaSendoAtendida = false;
        }

        public Requisicao(Cliente cliente, int numeroDePessoas, Conta? conta = null)
        {
            dataDeEntrada = DateTime.Now;
            dadosDoCliente = cliente;
            mesa = null;
            this.numeroDePessoas = numeroDePessoas;
            this.conta = conta != null ? conta : new Conta();
        }

        public int GetQuantidadeDePessoas()
        {
            return numeroDePessoas;
        }

        public Cliente GetCliente()
        {
            return dadosDoCliente;
        }

        public int GetNumeroDaMesa()
        {
            return mesa?.GetNumeroDaMesa() ?? 0;
        }

        public bool OcuparMesa(Mesa mesa)
        {
            if (this.mesa != null)
            {
                throw new InvalidOperationException("A mesa já está ocupada.");
            }

            this.mesa = mesa;
            this.mesa?.OcuparMesa();
            EstaSendoAtendida = true;

            return true;
        }

        public void FecharRequisicao()
        {
            RegistrarDataDeSaida();

            if (mesa != null)
            {
                mesa.DesocuparMesa();
                mesa = null;
            }

            EstaSendoAtendida = false;
        }

        public decimal ExibirValorTotal()
        {
            return conta.CalcularTotal();
        }

        public decimal ExibirValorDividido()
        {
            return conta.ExibirValorDividido(this.numeroDePessoas);
        }

        public bool FecharConta()
        {
            return conta.FecharConta();
        }

        public void DefinirPedido(Pedido pedido)
        {
            conta.SetPedido(pedido);
        }

        private void RegistrarDataDeSaida()
        {
            if (dataSaida == null)
            {
                dataSaida = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("A requisição já foi fechada.");
            }
        }

        private string MesaAlocada()
        {
            return mesa != null ? $"Mesa {mesa.GetNumeroDaMesa()}" : "Sem mesa alocada";
        }

        public string GerarRelatorioDaRequisicao()
        {
            return $"Nome: {dadosDoCliente.GetNome()} " + "|" + $" MesaAlocada: {MesaAlocada()}";
        }

        public string RelatorioConta()
        {
            return conta.GerarRelatorio(this.GetQuantidadeDePessoas());
        }
    }
}