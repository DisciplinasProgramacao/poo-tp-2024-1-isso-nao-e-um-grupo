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
            string cardapio = "Cardápio:\n\n" + "Comidas: \n\n";
            int i = 1;
            foreach (ItemPedido item in ItensDoPedido)
            {
                if (item is Comida)
                {
                    cardapio += i + ". " + item.ToString() + "\n";
                    i++;
                }
            }

            i = 1;
            cardapio += "\nBebidas: \n\n";
            foreach (ItemPedido item in ItensDoPedido)
            {
                if (item is Bebida)
                {
                    cardapio += i + ". " + item.ToString() + "\n";
                    i++;
                }
            }

            return cardapio;
        }

        public ItemPedido EscolherComida(int IndexComida)
        {
            return ItensDoPedido.Where(i => i is Comida).ElementAt(IndexComida - 1);
        }

        public ItemPedido EscolherBebida(int IndexBebida)
        {
            return ItensDoPedido.Where(i => i is Bebida).ElementAt(IndexBebida - 1);
        }
    }
}