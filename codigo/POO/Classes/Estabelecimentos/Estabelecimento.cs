using POO.Classes.Cardapios;
using POO.Classes.NovaPasta;
using POO.Interfaces;

namespace POO.Classes.Estabelecimentos
{
    public abstract class Estabelecimento : ICardapio
    {
        protected const int NUMERO_DE_MESAS = 10;

        protected List<Mesa> mesas = new List<Mesa>();
        protected Cardapio cardapio;
        protected string nome;
        protected List<Requisicao> requisicoes = new List<Requisicao>();

        public Estabelecimento(string _nome, Cardapio _cardapio, List<Mesa> _mesas)
        {
            nome = _nome;
            cardapio = _cardapio;
            mesas = _mesas;
        }

        public string ExibirCardapio()
        {
            return cardapio.ExibirCardapio();
        }

        public ItemPedido EscolherItemPedido(int index)
        {
            return cardapio.EscolherItemPedido(index);
        }

        public abstract bool AlocarMesa(Requisicao requisicao);

        public virtual Requisicao? RegistrarSaida(int numeroDaMesa)
        {
            var requisicao = EscolherRequisicao(numeroDaMesa);

            if (requisicao != null)
            {
                requisicao.FecharRequisicao();
                requisicao.FecharConta();

                return requisicao;
            }
            throw new Exception("Não existe requisição para esse número de mesa!");
        }

        public abstract Requisicao AdicionarPedido(int numeroDaMesa, Pedido pedido);

        public string RequisicoesAtivas()
        {
            var requisicoesComMesa = requisicoes.Where(r => r.EstaSendoAtendida);

            string relatorio = "";

            foreach (var requisicao in requisicoesComMesa)
            {
                relatorio += "\n" + requisicao.GerarRelatorioDaRequisicao();
            }

            return relatorio;
        }

        protected Requisicao? EscolherRequisicao(int numeroDaMesa)
        {
            return requisicoes.Find(r => r.GetNumeroDaMesa() == numeroDaMesa && r.GetNumeroDaMesa() != 0);
        }

        protected Mesa? ObterMesasDisponiveis(int quantidadePessoas)
        {
            return mesas.Find(m => m.VerificarDisponibilidade(quantidadePessoas));
        }
    }
}
