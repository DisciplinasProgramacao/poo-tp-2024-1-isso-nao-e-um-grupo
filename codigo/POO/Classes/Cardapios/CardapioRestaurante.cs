using POO.Classes.NovaPasta;

namespace POO.Classes.Cardapios
{
    public class CardapioRestaurante : Cardapio
    {
        public CardapioRestaurante()
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
    }
}
