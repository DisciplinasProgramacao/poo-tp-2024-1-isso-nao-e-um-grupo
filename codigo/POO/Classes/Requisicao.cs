using System;

namespace POO.Classes
{
    public class Requisicao
    {
        private DateTime dataDeEntrada;
        private DateTime? dataSaida;
        private Cliente dadosDoCliente;
        private Mesa? mesa;
        private int numeroDePessoas;

        public Requisicao(Cliente cliente, Mesa mesa, int numeroDePessoas)
        {
            dataDeEntrada = DateTime.Now;
            dadosDoCliente = cliente;
            this.mesa = mesa;
            this.numeroDePessoas = numeroDePessoas;
        }

        public Requisicao(Cliente cliente, int numeroDePessoas)
        {
            dataDeEntrada = DateTime.Now;
            dadosDoCliente = cliente;
            mesa = null;
            this.numeroDePessoas = numeroDePessoas;
        }

        public int GetQuantidadeDePessoas()
        {
            return numeroDePessoas;
        }

        public Cliente GetCliente()
        {
            return dadosDoCliente;
        }

        public bool OcuparMesa(Mesa mesa)
        {
            if (mesa != null)
            {
                throw new InvalidOperationException("A mesa já está ocupada.");
            }

            this.mesa = mesa;
            this.mesa?.OcuparMesa();
            return true;
        }

        public void FecharRequisicao()
        {
            RegistrarDataDeSaida();
            if (mesa != null)
            {
                mesa.DesocuparMesa();
            }
        }

        private void RegistrarDataDeSaida()
        {
            if (dataSaida == null)
            {
                dataSaida = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("A requisição já foi fechada.");
            }
        }
    }
}