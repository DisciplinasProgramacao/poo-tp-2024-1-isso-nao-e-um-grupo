using POO.Classes.Cardapios;

namespace POO.Classes.Estabelecimentos
{
    public class Restaurante : Estabelecimento
    {

        #region Atributos

        private Queue<Requisicao> filaDeEspera;

        #endregion

        #region Construtor

        public Restaurante(string nome) : base(nome, new CardapioRestaurante(), Mesa.GerarMesas())
        {
            filaDeEspera = new Queue<Requisicao>();
        }

        #endregion

        #region Métodos Públicos

        public override bool AlocarMesa(Requisicao requisicao)
        {
            Mesa? mesa;

            if (!VerificarNumeroDePessoas(requisicao.GetQuantidadeDePessoas()))
            {
                throw new InvalidOperationException("Não há mesas para essa quantidade de pessoas!");
            }

            mesa = ObterMesasDisponiveis(requisicao.GetQuantidadeDePessoas());

            if (mesa != null)
            {
                requisicao.OcuparMesa(mesa);
                requisicoes.Add(requisicao);
                mesa?.OcuparMesa();
            }
            else
            {
                filaDeEspera.Enqueue(requisicao);
                return false;
            }

            return true;
        }

        public override Requisicao AdicionarPedido(int numeroDaMesa, Pedido pedido)
        {
            Requisicao? requisicao = EscolherRequisicao(numeroDaMesa);

            if (requisicao == null)
            {
                throw new Exception("Não existe Requisicao para esse número de mesa!");
            }

            requisicao.DefinirPedido(pedido);
            return requisicao;
        }

        public override Requisicao? RegistrarSaida(int numeroDaMesa)
        {
            var response = base.RegistrarSaida(numeroDaMesa);
            ProcurarMesaParaRequisicao();
            return response;
        }

        #endregion

        #region Métodos Privados

        private void ProcurarMesaParaRequisicao()
        {
            if (!filaDeEspera.Any())
                return;

            List<Guid> idsAtendidos = new List<Guid>();

            foreach (var requisicao in filaDeEspera.ToArray())
            {
                Mesa? mesaDisponivel = ObterMesasDisponiveis(requisicao.GetQuantidadeDePessoas());
                if (mesaDisponivel != null)
                {
                    requisicao.OcuparMesa(mesaDisponivel);
                    requisicoes.Add(requisicao);
                    idsAtendidos.Add(requisicao.GetCliente().GetIdCliente());
                }
            }

            Queue<Requisicao> filaAuxiliar = new Queue<Requisicao>();

            while (filaDeEspera.Count > 0)
            {
                Requisicao requisicao = filaDeEspera.Dequeue();
                if (!idsAtendidos.Contains(requisicao.GetCliente().GetIdCliente()))
                {
                    filaAuxiliar.Enqueue(requisicao);
                }
            }

            while (filaAuxiliar.Count > 0)
            {
                filaDeEspera.Enqueue(filaAuxiliar.Dequeue());
            }
        }

        private bool VerificarNumeroDePessoas(int quantidadePessoas)
        {
            return quantidadePessoas > 0 && quantidadePessoas <= 8;
        }
        #endregion
    }
}