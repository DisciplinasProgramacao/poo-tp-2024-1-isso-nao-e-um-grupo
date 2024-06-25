using POO.Classes.Cardapios;

namespace POO.Classes.Estabelecimentos
{
    public class Cafeteria : Estabelecimento
    {
        public Cafeteria(string _nome) : base(_nome, new CardapioCafeteria(), Mesa.GerarMesas())
        {
        }
    }
}
