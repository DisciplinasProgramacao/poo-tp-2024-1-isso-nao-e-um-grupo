namespace POO.Classes
{
    public class Mesa
    {
        private static int proximaMesa = 1;
        private int capacidade;
        private int numeroDaMesa;
        private bool disponibilidade;

        public Mesa(int capacidade)
        {
            proximaMesa = proximaMesa == 11 ? 1 : proximaMesa;
            this.capacidade = capacidade;
            numeroDaMesa = proximaMesa;
            disponibilidade = true;
            proximaMesa++;

        }

        public void OcuparMesa() => disponibilidade = false;
        public void DesocuparMesa() => disponibilidade = true;
        public bool VerificarDisponibilidade(int quantidadePessoas) => disponibilidade ? quantidadePessoas <= capacidade : false;
        public int GetNumeroDaMesa() => numeroDaMesa;
        public bool GetDisponibilidade() => disponibilidade;
        public static List<Mesa> GerarMesas()
        {
            var mesas = new List<Mesa>();

            for (int i = 0; i < 4; i++)
            {
                mesas.Add(new Mesa(4));
            }

            for (int i = 0; i < 4; i++)
            {
                mesas.Add(new Mesa(6));
            }

            for (int i = 0; i < 2; i++)
            {
                mesas.Add(new Mesa(8));
            }

            return mesas;
        }
    }
}