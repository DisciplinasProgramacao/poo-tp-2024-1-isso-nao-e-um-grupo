using POO.Classes.NovaPasta;
using System;
using System.Xml.Linq;

namespace POO.Classes
{
    public class Cardapio
    {
        public List<ItemPedido> ItensDoPedido { get; private set; }

        public Cardapio()
        {
            ItensDoPedido = new List<ItemPedido>()
                    {
                        new Bebida("Água", 3.00m),
                        new Bebida("Refrigerante orgânico", 7.00m),
                        new Bebida("Copo de suco", 7.00m),
                        new Bebida("Cerveja vegana", 9.00m),
                        new Bebida("Taça de vinho vegano", 18.00m),
                        new Comida("Moqueca de Palmito", 32.00m),
                        new Comida("Falafel Assado", 20.00m),
                        new Comida("Salada Primavera com Macarrão Konjac", 25.00m),
                        new Comida("Escondidinho de Inhame", 18.00m),
                        new Comida("Strogonoff de Cogumelos", 35.00m),
                        new Comida("Caçarola de legumes", 22.00m)
                    };
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
            return ItensDoPedido.Where(i => i is Comida).ElementAt(IndexComida-1);
        }

        public ItemPedido EscolherBebida(int IndexBebida)
        {
            return ItensDoPedido.Where(i => i is Bebida).ElementAt(IndexBebida - 1);
        }
    }
}