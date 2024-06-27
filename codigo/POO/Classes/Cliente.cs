namespace POO.Classes
{
    public class Cliente
    {
        private static Guid proximoIdCliente => Guid.NewGuid();
        private string nome;
        private Guid idCliente;

        public Cliente(string nome)
        {
            idCliente = proximoIdCliente;
            this.nome = nome;
        }

        public Guid GetIdCliente() => idCliente;

        public string GetNome() => nome;
    }
}