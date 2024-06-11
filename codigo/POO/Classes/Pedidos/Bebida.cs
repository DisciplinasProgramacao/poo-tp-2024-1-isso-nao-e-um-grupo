using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Classes.NovaPasta
{
    public class Bebida : ItemPedido
    {
        public Bebida(string nome, decimal preco) : base(nome, preco)
        {
        }
    }
}
