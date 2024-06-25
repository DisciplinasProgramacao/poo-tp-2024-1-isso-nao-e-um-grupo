using POO.Classes.NovaPasta;

namespace POO.Classes.Cardapios
{
    public class CardapioCafeteria : Cardapio
    {
        public CardapioCafeteria()
        {
            ItensDoPedido = new List<ItemPedido>()
            {
                new Comida("Não de queijo", 5.00m),
                new Comida("Bolinha de cogumelo", 7.00m),
                new Comida("Rissole de palmito", 7.00m),
                new Comida("Coxinha de carne de jaca", 8.00m),
                new Comida("Fatia de queijo de caju", 9.00m),
                new Comida("Biscoito amanteigado", 3.00m),
                new Comida("Cheesecake de frutas vermelhas", 15.00m),
                new Bebida("Água", 3.00m),
                new Bebida("Copo de suco", 7.00m),
                new Bebida("Café espresso orgânico", 6.00m)
            };
        }
    }
}
