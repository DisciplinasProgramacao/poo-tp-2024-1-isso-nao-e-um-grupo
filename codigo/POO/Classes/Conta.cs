using POO.Classes.NovaPasta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Classes
{
    public class Conta
    {
        public const decimal TAXA_DE_SERVICO = 0.1m;
        private Requisicao? requisicao;
        private Pedido pedido;
        private Guid IdConta;
        public bool Aberta { get; private set; } = true;


        public Conta()
        {
            pedido = new Pedido();
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

        public void AdicionarRequisicao(Requisicao requisicao)
        {
            this.requisicao = requisicao;
        }

        public Guid GetContaId() => IdConta;
        public bool FecharConta => Aberta = false;
    }
}
