using POO.Classes.NovaPasta;

namespace POO.Interfaces
{
    public interface ICardapio
    {
        string ExibirCardapio();
        ItemPedido EscolherItemPedido(int index);
    }
}
