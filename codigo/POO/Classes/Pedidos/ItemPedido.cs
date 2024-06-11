using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Classes.NovaPasta
{
    public abstract class ItemPedido
    {
        protected string nome;
        protected decimal preco;

        public ItemPedido(string nome, decimal preco)
        {
            this.nome = nome;
            this.preco = preco;
        }

        public string GetNome() => nome;
        public decimal GetPreco() => preco;

        public override string ToString()
        {
            return nome + " - " + "R " + preco.ToString("F2");
        }
    }
}
