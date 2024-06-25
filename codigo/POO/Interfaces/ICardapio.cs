using POO.Classes.NovaPasta;

namespace POO.Interfaces
{
    public interface ICardapio
    {
        string ExibirCardapio();
        ItemPedido EscolherBebida(int index);
        ItemPedido EscolherComida(int index);
    }
}
