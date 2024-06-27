using POO.Classes.NovaPasta;
using POO.Interfaces;

namespace POO.Classes.Cardapios
{
    public class Cardapio : ICardapio
    {
        protected List<ItemPedido> ItensDoPedido { get; set; }

        public Cardapio()
        {
            ItensDoPedido = new List<ItemPedido>();
        }

        public string ExibirCardapio()
        {
            string cardapio = "\nCardápio\n\n";
            int i = 1;
            foreach (ItemPedido item in ItensDoPedido)
            {
                cardapio += i + ". " + item.ToString() + "\n";
                i++;
            }

            return cardapio;
        }

        public ItemPedido EscolherItemPedido(int IndexComida)
        {
            return ItensDoPedido.ElementAt(IndexComida - 1);
        }
    }
}