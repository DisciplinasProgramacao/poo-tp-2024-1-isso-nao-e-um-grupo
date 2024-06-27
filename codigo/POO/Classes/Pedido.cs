using POO.Classes.NovaPasta;

namespace POO.Classes
{
    public class Pedido
    {
        private List<ItemPedido> items;

        public Pedido()
        {
            items = new List<ItemPedido>();
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;

            foreach (ItemPedido item in items)
            {
                total += item.GetPreco();
            }

            return  total;
        }

        public void AdicionarItem(ItemPedido item)
        {
            items.Add(item);
        }
    }
}
