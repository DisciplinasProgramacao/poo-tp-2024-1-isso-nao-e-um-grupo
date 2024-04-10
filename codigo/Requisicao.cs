using System;

namespace POO
{
    public class Requisicao
    {
        private static Guid proximoIdRequisicao => Guid.NewGuid();
        private Guid requisicaoId;
        private DateTime dataDeEntrada;
        private DateTime? dataSaida;
        private Cliente dadosDoCliente;
        private bool status;
        private Mesa mesa;
        private int numeroDePessoas;


        public Requisicao(int numeroDePessoas, Mesa mesa, Cliente cliente)
        {
            if (numeroDePessoas <= 0)
                throw new ArgumentException("O número de pessoas deve ser maior que zero.");
            requisicaoId = proximoIdRequisicao;
            dataDeEntrada = DateTime.Now;
            dadosDoCliente = cliente;
            status = true;
            this.mesa = mesa;
            this.numeroDePessoas = numeroDePessoas;
        }

        public Requisicao(int numeroDePessoas, Cliente cliente)
        {
            if (numeroDePessoas <= 0)
                throw new ArgumentException("O número de pessoas deve ser maior que zero.");
            requisicaoId = proximoIdRequisicao;
            dataDeEntrada = DateTime.Now;
            dadosDoCliente = cliente;
            status = true;
            this.mesa = null;
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
                throw new InvalidOperationException("A mesa já está ocupada.");

            this.mesa = mesa;
            return true;
        }

        public void FecharRequisicao()
        {
            RegistrarDataDeSaida();
            this.status = false;
            mesa.DesocuparMesa();
        }
        private void RegistrarDataDeSaida()
        {
            if (dataSaida == null)
            {
                dataSaida = DateTime.Now;
                Console.WriteLine("Data de saída registrada: " + dataSaida);
            }
            else
            {
                throw new InvalidOperationException("A requisição já foi fechada.");
            }
        }
    }
}
