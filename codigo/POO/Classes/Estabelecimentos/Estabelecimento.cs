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

        public Estabelecimento(string _nome, Cardapio _cardapio, List<Mesa> _mesas)
        {
            nome = _nome;
            cardapio = _cardapio;
            mesas = _mesas;
        }

        public string Nome
        {
            get { return nome; }
        }

        public string ExibirCardapio()
        {
            return cardapio.ExibirCardapio();
        }

        public ItemPedido EscolherBebida(int index)
        {
            return cardapio.EscolherBebida(index);
        }

        public ItemPedido EscolherComida(int index)
        {
            return cardapio.EscolherComida(index);
        }

        public bool VerificarExistenciaMesasDisponiveis()
        {
            return mesas.Find(m => m.GetDisponibilidade()) != null;
        }

        public Mesa? ObterMesasDisponiveis(int quantidadePessoas)
        {
            return mesas.Find(m => m.VerificarDisponibilidade(quantidadePessoas));
        }
    }
}
