using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO
{
    public class Mesa
    {
        private static int proximaMesa = 1;
        private int capacidade;
        private int numeroDaMesa;
        private bool disponibilidade;

        public Mesa(int capacidade)
        {
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
    }
}