using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO
{
    public class Cliente
    {
        private static Guid proximoIdCliente = Guid.NewGuid();
        private Guid idCliente;

        public Cliente()
        {
            idCliente = proximoIdCliente;
            proximoIdCliente = Guid.NewGuid();
        }
        public Guid ConsultarIdCliente() => idCliente;
    }
}