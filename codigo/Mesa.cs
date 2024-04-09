using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO
{
    public class Mesa
    {
        private static proximaMesa = 1;
        private int capacidade;
        private int numeroDaMesa;
        public int NumeroDaMesa => numeroDaMesa;
        private bool disponibilidade;

        public Mesa(int capacidade)
        {
            this.capacidade = capacidade;
            numeroDaMesa = proximaMesa;
            disponibilidade = true;
            proximaMesa++;
        }

        public void DefinirDisponibilidade(bool disponibilidade) => this.disponibilidade = disponibilidade;
        public bool EstahDisponivel(int QtndPessoas) => disponibilidade ? QtndPessoas <= capacidade : false;
    }
}