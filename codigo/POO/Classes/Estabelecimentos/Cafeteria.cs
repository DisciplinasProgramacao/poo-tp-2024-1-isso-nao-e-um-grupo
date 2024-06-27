using POO.Classes.Cardapios;

namespace POO.Classes.Estabelecimentos
{
    public class Cafeteria : Estabelecimento
    {
        public Cafeteria(string _nome) : base(_nome, new CardapioCafeteria(), Mesa.GerarMesas()){ }

        public override bool AlocarMesa(Requisicao requisicao)
        {
            Mesa? mesa;

            mesa = ObterMesasDisponiveis(1);

            if (mesa != null)
            {
                requisicao.OcuparMesa(mesa);
                requisicoes.Add(requisicao);
                mesa?.OcuparMesa();
            }
            else
            {
                throw new Exception("Não há mesas disponíveis!");
            }

            return true;
        }

        public override Requisicao? AdicionarPedido(int numeroDaMesa, Pedido pedido)
        {
            Requisicao? requisicao = EscolherRequisicao(numeroDaMesa);

            if (requisicao == null)
            {
                throw new Exception("Não existe requisicão para esse número de mesa!");
            }

            requisicao.DefinirPedido(pedido);

            return requisicao;
        }

        public override Requisicao? RegistrarSaida(int numeroDaMesa)
        {
            return base.RegistrarSaida(numeroDaMesa);
        }
    }
}
